using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class AddressEFCoreMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            
            builder.Property(a => a.ContactName)
                .HasColumnName("ContactName")
                .HasColumnType("character varying(100)") // ✅ PostgreSQL + tamanho correto (100)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(a => a.AddressLine1)
                .HasColumnName("AddressLine1")
                .HasColumnType("character varying(450)") // ✅ PostgreSQL + tamanho correto (450)
                .HasMaxLength(450)
                .IsRequired();

            
            builder.Property(a => a.CityId)
                .HasColumnName("CityId")
                .IsRequired();

            builder.Property(a => a.DistrictId)
                .HasColumnName("DistrictId")
                .IsRequired();

            
            builder.HasOne(a => a.City)
                .WithMany() // City não tem coleção de Addresses
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.District)
                .WithMany() // District não tem coleção de Addresses  
                .HasForeignKey(a => a.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasMany(a => a.Cities)
                .WithOne() // City tem relacionamento com Address?
                .HasForeignKey("AddressId") // Se City tiver AddressId
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Districts)
                .WithOne() // District tem relacionamento com Address?
                .HasForeignKey("AddressId") // Se District tiver AddressId
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasIndex(a => a.CityId)
                .HasDatabaseName("IX_Addresses_CityId");

            builder.HasIndex(a => a.DistrictId)
                .HasDatabaseName("IX_Addresses_DistrictId");

            builder.HasIndex(a => a.ContactName)
                .HasDatabaseName("IX_Addresses_ContactName");
        }
    }
}