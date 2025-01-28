namespace Wallet.API.Models.WalletOfFamily;

public record SubWalletWriteModel : WalletWriteModel
{
    public required long ParentWalletId { get; init; }
    public List<FamilyMemberWriteModel>? FamilyMembers { get; init; }
}
