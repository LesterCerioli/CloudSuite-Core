using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CountryEFCoreMapping : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.CountryName)
                .HasColumnName("CountryName")
                .HasColumnType("character varying(450)") // PostgreSQL
                .HasMaxLength(450)
                .IsRequired();

            builder.Property(d => d.Code3)
                .HasColumnName("Code")
                .HasColumnType("character varying(3)") // PostgreSQL + corrected length
                .HasMaxLength(3) // Code3 should be 3 characters
                .IsRequired();

            
            builder.Property(d => d.IsBillingEnabled)
                .HasColumnName("IsBillingEnabled")
                .HasColumnType("boolean") // PostgreSQL boolean
                .IsRequired(false);

            builder.Property(d => d.IsShippingEnabled)
                .HasColumnName("IsShippingEnabled")
                .HasColumnType("boolean") // PostgreSQL boolean
                .IsRequired(false);

            builder.Property(d => d.IsCityEnabled)
                .HasColumnName("IsCityEnabled")
                .HasColumnType("boolean") // PostgreSQL boolean
                .IsRequired(false);

            builder.Property(d => d.IsZipCodeEnabled)
                .HasColumnName("IsZipCodeEnabled")
                .HasColumnType("boolean") // PostgreSQL boolean
                .IsRequired(false);

            builder.Property(d => d.IsDistrictEnabled)
                .HasColumnName("IsDistrictEnabled")
                .HasColumnType("boolean") // PostgreSQL boolean
                .IsRequired(false);

            
            builder.HasMany(c => c.States)
                .WithOne(s => s.Country) // State deve ter propriedade Country
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasIndex(c => c.CountryName)
                .HasDatabaseName("IX_Countries_CountryName");

            builder.HasIndex(c => c.Code3)
                .HasDatabaseName("IX_Countries_Code3");
        }
    }
}