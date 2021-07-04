using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Foundations.TypedId
{
    public class IdTests
    {
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


        [Test]
        public void Deserialize()
        {
            var id = new Guid("4B2F59FC-9DA4-4A96-8FA6-4AF646C1B3A9");
            var payload = $"{{ 'Id': '{id}'}}";
            var car = JsonConvert.DeserializeObject<Car>(payload);

            Assert.NotNull(car);
            Assert.AreEqual(id, car.Id.Value);
        }
    }
}