using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class DistrictEFCoreMapping : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(d => d.Name)
                .HasColumnName("Name")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(d => d.Type)
                .HasColumnName("Type")
                .HasColumnType("character varying(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(d => d.Location)
                .HasColumnName("Location")
                .HasColumnType("character varying(100)")
                .HasMaxLength(100)
                .IsRequired();

           
            builder.HasMany(d => d.Cities)
                .WithOne(c => c.District) // City deve ter propriedade District
                .HasForeignKey(c => c.DistrictId)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasIndex(d => d.Name)
                .HasDatabaseName("IX_Districts_Name");

            builder.HasIndex(d => d.Type)
                .HasDatabaseName("IX_Districts_Type");
        }
    }
}