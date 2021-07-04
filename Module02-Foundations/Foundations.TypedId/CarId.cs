using System;

namespace Foundations.TypedId
{
    public class CarId : GuidId<CarId>
    {
        public CarId(Guid value) : base(value) { }
    }
}