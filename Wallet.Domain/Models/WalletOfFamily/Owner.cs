using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Models.WalletOfFamily;

public class Owner : Entity<long>
{
    public Owner(long id, string name) : base(id)
    {
        Name = name;
    }
    public string Name { get; set; }
}