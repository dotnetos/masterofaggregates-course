using System;
using Newtonsoft.Json;

namespace Foundations.TypedId
{
    [JsonConverter(typeof(GuidPrimitiveIdNewtonsoftJsonConverter))]
    public abstract class GuidId<TId> : Id<Guid, TId> 
        where TId : Id<Guid, TId>
    {
        protected GuidId(Guid value) : base(value)
        {
        }
    }

    public interface IId<TPrimitive>
    {
        public TPrimitive Value { get; }
    }

    public abstract class Id<TPrimitive, TId> : IEquatable<TId>, IId<TPrimitive>
        where TPrimitive : IEquatable<TPrimitive>
        where TId : Id<TPrimitive, TId>
    {
        public TPrimitive Value { get; }

        protected Id(TPrimitive value)
        {
            Value = value;
        }

        #region Equality

        public bool Equals(TId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(TId)) return false;
            return Equals((TId)obj);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public static bool operator ==(Id<TPrimitive, TId> left, Id<TPrimitive, TId> right) => Equals(left, right);

        public static bool operator !=(Id<TPrimitive, TId> left, Id<TPrimitive, TId> right) => !Equals(left, right);

        #endregion
        
        public override string ToString() => $"{GetType().Name}/{Value}";
    }

    class GuidPrimitiveIdNewtonsoftJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type type) => typeof(IId<Guid>).IsAssignableFrom(type);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var id = (IId<Guid>)value;
            serializer.Serialize(writer, id.Value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var guid = serializer.Deserialize<Guid>(reader);
            return Activator.CreateInstance(objectType, new object[] { guid });
        }
    }
}
