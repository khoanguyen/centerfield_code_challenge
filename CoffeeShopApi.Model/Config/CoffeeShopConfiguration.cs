using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApi.Model.Config
{
    internal class CoffeeShopConfiguration : IEntityTypeConfiguration<CoffeeShop>
    {
        public void Configure(EntityTypeBuilder<CoffeeShop> builder)
        {
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            
            builder.Property(c => c.Timestamp)
                .IsConcurrencyToken()
                .HasColumnType("Timestamp");

            builder.Property(c => c.Name).HasMaxLength(200);

            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ModifiedDate)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
