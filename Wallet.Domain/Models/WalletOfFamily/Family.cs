using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Models.WalletOfFamily;

public class Family : Entity<long>
{
    public Family(long id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; set; }
}