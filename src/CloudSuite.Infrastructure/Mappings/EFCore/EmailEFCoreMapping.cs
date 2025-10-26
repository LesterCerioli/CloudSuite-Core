using CloudSuite.Domain.Enums;
using CloudSuite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSuite.Infrastructure.Mappings.EFCore
{
    public class EmailEFCoreMapping : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Id)
                .HasColumnName("Id");

            builder.Property(f => f.Subject)
                .HasColumnName("Subject")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(f => f.Body)
                .HasColumnName("Body")
                .HasMaxLength(450)
                .IsRequired();
            builder.Property(f => f.Sender)
                .HasColumnName("Sender")
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(f => f.Recipient)
                .HasColumnName("Recipient")
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(f => f.SentDate)
                .HasColumnName("SentDate")
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .HasPrecision(3);
                
            builder.Property(f => f.IsRead)
                .HasColumnName("IsRead")
                .HasColumnType("boolean");
            builder.Property(f => f.SendAttempts)
                .HasColumnName("SendAttempts")
                .HasColumnType("int(2)");

            
            builder.Property(f => f.CodeErrorEmail)
                .HasColumnName("CodeErrorEmail")
                .HasColumnType("int")
                .IsRequired()
                .HasDefaultValue(CodeErrorEmail.None);
            
        }
    }
}