using Wallet.API.Models.Base;

namespace Wallet.API.Models.AccountOfPerson;

public record AccountTransferFundsWriteModel : IWriteModel
{
    public long ProfileId { get; set; }
    public long FromAccountId { get; init; }
    public long ToWalletId { get; init; }
    public decimal Amount { get; init; }
}
