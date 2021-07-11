using System;
using System.Threading.Tasks;

namespace Foundations.Boundaries
{
    public class DomainDrivenCarService
    {
        readonly IRepository<RichCarAggregate> repository;

        public DomainDrivenCarService(IRepository<RichCarAggregate> repository)
        {
            this.repository = repository;
        }

        public async Task Bid(Guid id, int amount, Guid bidderId)
        {
            var car = await repository.Get(id);

            car.Bid(amount, bidderId);

            await repository.Update(id, car);
        }
    }

    public class RichCarAggregate
    {
        State state = State.Biddable;
        Guid bidder;

        public void Bid(int amount, Guid bidderId)
        {
            Ensure(State.Biddable);

            if (amount > Amount)
            {
                Amount = amount;
                bidder = bidderId;
            }

            throw new ArgumentException("Bid is to low", nameof(amount));
        }

        void Ensure(State requested)
        {
            if (requested != state)
            {
                throw new InvalidOperationException(
                    $"The operation cannot be performed as the current state is {state} while the {requested} is required to perform it");
            }
        }

        public int Amount { private set; get; }
    }
}