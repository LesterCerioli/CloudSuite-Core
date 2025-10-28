using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CompanyEFCoreMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            
            builder.OwnsOne(c => c.Cnpj, cnpj =>
            {
                cnpj.Property(p => p.CnpjNumber) // ← PROPRIEDADE PÚBLICA
                    .HasColumnName("Cnpj")
                    .HasColumnType("character varying(14)")
                    .HasMaxLength(14)
                    .IsRequired();
            });

            builder.Property(c => c.FantasyName)
                .HasColumnName("FantasyName")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.RegisterName)
                .HasColumnName("RegisterName")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.AddressId)
                .HasColumnName("AddressId")
                .IsRequired();

            builder.HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasIndex(c => c.FantasyName)
                .HasDatabaseName("IX_Companies_FantasyName");

            builder.HasIndex(c => c.RegisterName)
                .HasDatabaseName("IX_Companies_RegisterName");

            builder.HasIndex(c => c.AddressId)
                .HasDatabaseName("IX_Companies_AddressId");
        }
    }
}