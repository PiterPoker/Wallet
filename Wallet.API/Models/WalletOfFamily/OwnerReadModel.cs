using Wallet.API.Models.Base;

namespace Wallet.API.Models.WalletOfFamily
{
    public record OwnerReadModel : IReadModel<long>
    {
        public required long Id { get; init; }
        public string? Name { get; init; }
    }
}
