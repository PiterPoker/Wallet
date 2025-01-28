namespace Wallet.API.Models.WalletOfFamily
{
    public record SubWalletTransferFundsWriteModel : WalletTransferFundsWriteModel
    {
        public long FamilyMemberId { get; set; }
    }
}
