using System;

namespace Foundations.TypedId
{
    public class CostId : GuidId<CostId>
    {
        public CostId(Guid value) : base(value) { }
    }
}