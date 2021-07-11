using System;
using System.Threading.Tasks;

namespace Foundations.Boundaries
{
    public class AnemicCarService
    {
        readonly IRepository<AnemicCarAggregate> repository;

        public AnemicCarService(IRepository<AnemicCarAggregate> repository)
        {
            this.repository = repository;
        }

        public async Task Bid(Guid id, int amount, Guid bidderId)
        {
            var car = await repository.Get(id);

            Ensure(car, State.Biddable);
            
            if (amount > car.Amount)
            {
                car.Amount = amount;
                car.BidderId = bidderId;

                await repository.Update(id, car);

                return;
            }

            throw new ArgumentException("Bid is to low", nameof(amount));
        }

        static void Ensure(AnemicCarAggregate anemicCar, State requested)
        {
            if (requested != anemicCar.State)
            {
                throw new InvalidOperationException(
                    $"The operation cannot be performed as the current state is {anemicCar.State} while the {requested} is required to perform it");
            }
        }

        public class AnemicCarAggregate
        {
            public Guid Id { get; set; }

            public State State { get; set; }

            public int Amount { get; set; }

            public Guid BidderId { get; set; }
        }
    }
}