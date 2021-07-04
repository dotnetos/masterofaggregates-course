using System;
using NUnit.Framework;

namespace Foundations.TypedId
{
    public class RecordIdTests
    {
        public record CarId(Guid Value);

        public record CostId(Guid Value);

        [Test]
        public void Equality()
        {
            var carId1 = new CarId(Guid.NewGuid());
            var carId1b = new CarId(carId1.Value);

            var carId2 = new CarId(Guid.NewGuid());

            var costId = new CostId(carId1.Value);

            // same entity
            Assert.AreEqual(carId1, carId1b);

            // different real entities
            Assert.AreNotEqual(carId1, carId2);

            // same entity, different parts of a model - same value
            Assert.AreEqual(carId1.Value, costId.Value);

            // but different entities
            Assert.AreNotEqual(carId1, costId);
        }
    }
}