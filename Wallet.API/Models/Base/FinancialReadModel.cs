namespace Wallet.API.Models.Base
{
    public abstract record FinancialReadModel : IReadModel<long>
    {
        public required long Id { get; init; }
        public required decimal Balance { get; init; }
        public required string Currency { get; init; }
    }
}
