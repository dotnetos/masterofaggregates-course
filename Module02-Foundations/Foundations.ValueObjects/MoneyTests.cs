using System;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Foundations.ValueObjects
{
    public class MoneyTests
    {
        [Test]
        public void Arithmetic()
        {
            Assert.AreEqual(3.PLN(), 1.PLN() + 2.PLN());

            Assert.AreEqual(2.PLN(), 3.PLN() - 1.PLN());

            Assert.Throws<ArgumentException>(() =>
            {
                var _ = 1.USD() + 2.EUR();
            });
        }

        [Test]
        public void JsonSerialize()
        {
            var expected = 1.PLN();
            var text = JsonConvert.SerializeObject(expected);

            Console.WriteLine(text);

            Assert.AreEqual(expected, JsonConvert.DeserializeObject<Money>(text));
        }
    }
}