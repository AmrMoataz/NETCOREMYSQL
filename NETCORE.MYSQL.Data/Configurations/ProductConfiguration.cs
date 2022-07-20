using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NETCORE.MYSQL.Data.Models;

namespace NETCORE.MYSQL.Data.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.Id);
			builder.Property(p => p.IsActive).HasConversion(new BoolToZeroOneConverter<Int16>()).HasColumnType("bit");
			builder.Property(p => p.Name).HasMaxLength(50);
			builder.Property(p => p.CreatedBy).HasMaxLength(50);
			builder.Property(p => p.LastModifiedBy).HasMaxLength(50);
			builder.Property(p => p.CreatedBy).IsRequired();
			builder.Property(p => p.Created).IsRequired();
			builder.Property(p => p.Name).IsRequired();
			builder.Property(p => p.Quantity).IsRequired();
			builder.Property(p => p.Cost).IsRequired();
			builder.Property(p => p.EntityId).IsRequired();
			builder.HasIndex(p => p.EntityId).IsUnique();
		}
	}
}
