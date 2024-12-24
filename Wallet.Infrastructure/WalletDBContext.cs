using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Models.AccountOfPerson;
using Wallet.Infrastructure.Configurations;
using Models = Wallet.Domain.Models.WalletOfFamily;

namespace Wallet.Infrastructure;

public class WalletDBContext : DbContext
{
    public DbSet<Models.Family> Families { get; set; }
    public DbSet<Models.Owner> Owners { get; set; }
    public DbSet<Models.Wallet> Wallets { get; set; }
    public DbSet<Models.SubWallet> SubWallets { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public WalletDBContext(DbContextOptions<WalletDBContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FamilyConfiguration());
        modelBuilder.ApplyConfiguration(new OwnerConfiguration());
        modelBuilder.ApplyConfiguration(new WalletConfiguration());
        modelBuilder.ApplyConfiguration(new SubWalletConfiguration());
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }
}
