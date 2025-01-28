using Wallet.API.Models.Base;

namespace Wallet.API.Models.WalletOfFamily;

public record OwnerWriteModel : IWriteModel
{
    public long Id { get; set; }
    public required string Name { get; init; }
}
