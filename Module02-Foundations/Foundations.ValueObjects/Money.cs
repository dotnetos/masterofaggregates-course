using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Foundations.ValueObjects
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currency
    {
        PLN = 1,
        USD = 2,
        EUR =3
    }

    /// <summary>
    /// A simple value object representing an amount of money
    /// </summary>
    public record Money (decimal Value, Currency Currency)
    {
        public static Money operator +(Money a, Money b) => a.Currency != b.Currency
            ? throw new ArgumentException(
                $"You can only combine money with the same currency. The first amount is in {a.Currency} while the second in {b.Currency}")
            : new Money(a.Value + b.Value, a.Currency);

        public static Money operator -(Money a) => new(-a.Value, a.Currency);

        public static Money operator -(Money a, Money b) => a + -b;
    }

    public static class FrequentlyUsedCurrencies
    {
        public static Money PLN(this int value) => new(value, Currency.PLN);

        public static Money USD(this int value) => new(value, Currency.USD);

        public static Money EUR(this int value) => new(value, Currency.EUR);
    }
}
