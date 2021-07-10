using System;
using System.Threading.Tasks;

namespace Foundations.TypedId
{
    public class BidderId : GuidId<BidderId>
    {
        public BidderId(Guid value) : base(value) { }
    }

    public interface IBidService
    {
        Task Bid(BidderId bidder, CarId car);

        Task Bid(Guid bidder, Guid car);
    }
}