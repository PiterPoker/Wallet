using Wallet.Domain.SeedWork;

namespace Wallet.Domain.Models.WalletOfFamily;

public class Owner(long id, string name) : Entity<long>(id)
{
    public string Name { get; set; } = name;
}