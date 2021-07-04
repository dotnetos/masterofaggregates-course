namespace Foundations.TypedId
{
    public class Cost
    {
        public CostId Id { get; set; }

        // TODO: bad smell, price as int?
        public int Price { get; set; }

        // TODO: bad smell, currency as string?
        public string Currency { get; set; }

        // TODO: why all the setters?
    }
}