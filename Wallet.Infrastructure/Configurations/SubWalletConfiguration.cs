using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletOfFamily = Wallet.Domain.Models.WalletOfFamily;

namespace Wallet.Infrastructure.Configurations
{
    internal class SubWalletConfiguration 
        : IEntityTypeConfiguration<WalletOfFamily.SubWallet>
    {
        public void Configure(EntityTypeBuilder<WalletOfFamily.SubWallet> builder)
        {
            builder.HasBaseType<WalletOfFamily.Wallet>();
            builder.HasOne(s => s.Family)
                   .WithMany()
                   .HasForeignKey("FamilyId");
            builder.HasMany(s => s.FamilyMembers)
                   .WithOne()
                   .HasForeignKey("OwnerId");
        }
    }
}
