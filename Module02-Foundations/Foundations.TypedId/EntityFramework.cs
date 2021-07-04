using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Foundations.TypedId
{
    public class EntityFramework
    {
        public class IdValueConverter : ValueConverter<CarId, Guid>
        {
            public IdValueConverter(ConverterMappingHints mappingHints = null)
                : base(id => id.Value,            // id -> primitive
                    value => new CarId(value),    // primitive -> id  
                    mappingHints)
            {
            }
        }
    }
}