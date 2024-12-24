using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.Models.WalletOfFamily;

namespace Wallet.Infrastructure.Configurations
{
    internal class OwnerConfiguration 
        : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
