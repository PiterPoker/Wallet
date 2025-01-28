using Wallet.API.Models.Base;

namespace Wallet.API.Models.AccountOfPerson
{
    public class AddFundsToAccountWriteModel : IWriteModel
    {
        public long AccountId { get; set; }
        public decimal Amount{ get; set; } 
        public long ProfileId { get; set; }
    }
}
