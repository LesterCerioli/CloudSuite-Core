using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class CityEFCoreMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            
            builder.ToTable("Cities");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); // ✅ Importante para PostgreSQL

            
            builder.Property(b => b.CityName)
                .HasColumnName("CityName")
                .HasColumnType("character varying(50)") // ✅ PostgreSQL
                .HasMaxLength(50)
                .IsRequired();

            
            builder.Property(b => b.StateId)
                .HasColumnName("StateId")
                .IsRequired();

            
            builder.HasOne(p => p.State)
                .WithMany()
                .HasForeignKey(p => p.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            
            builder.HasIndex(c => c.CityName)
                .HasDatabaseName("IX_Cities_CityName");

            builder.HasIndex(c => c.StateId)
                .HasDatabaseName("IX_Cities_StateId");
        }
    }
}