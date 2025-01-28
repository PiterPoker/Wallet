using Wallet.API.Models.Base;

namespace Wallet.API.Models.WalletOfFamily;

/// <summary> 
/// Запрос для перевода средств между кошельками. 
/// </summary>
public record WalletTransferFundsWriteModel : IWriteModel
{
    public long FromWalletId { get; init; }
    public long ToWalletId { get; init; }
    public decimal Amount { get; init; }
}
