using System.Security.Cryptography;
using System.Text;
using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class UserEFCoreMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                .HasColumnName("Id");

            builder.Property(i => i.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasColumnType("boolean")
                .IsRequired();

            builder.OwnsOne(p => p.Cpf)
                            .Property(p => p.CpfNumber).HasColumnName("CPFNumber").HasMaxLength(11).IsRequired();

            builder.OwnsOne(p => p.Telephone)
                            .Property(p => p.TelephoneRegion).HasColumnName("TelephoneRegion").HasMaxLength(11).IsRequired();
                            

            builder.OwnsOne(p => p.Telephone)
                            .Property(p => p.TelephoneNumber).HasColumnName("TelephoneNumber").HasMaxLength(11).IsRequired();;

            builder.Property(i => i.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .HasPrecision(3);

            builder.Property(i => i.LatestUpdatedOn)
                .HasColumnName("LatestUpdatedOn")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .HasPrecision(3);

            builder.HasOne(v => v.Email)
                .WithMany()
                .HasForeignKey(v => v.EmailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.RefreshTokenHash)
                .HasColumnName("RefreshTokenHash")
                .HasMaxLength(50)
                .HasConversion(
                    token => HashRefreshToken(token),
                    hashedToken => hashedToken);

            builder.HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);
                
                

            
        }

        private static string HashRefreshToken(string refreshToken)
        {
            // Logic to convert refreshToken to hash (example: SHA-256)
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}