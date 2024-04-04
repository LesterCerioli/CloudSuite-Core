using CloudSuite.Domain.Models.PasswordGeneratorContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Mappings.EFCore.Password_Generator
{
	public class PasseordEFCoreMapping : IEntityTypeConfiguration<Password>
	{
		public void Configure(EntityTypeBuilder<Password> builder)
		{
			builder.HasKey(a => a.Id);

			builder.Property(a => a.Id)
				.HasColumnName("Id");

			builder.Property(a => a.Senha)
				.HasColumnName("senha")
				.HasColumnType("varchar(24)");

			builder.Property(a => a.CaracterNumber)
				.HasColumnName("caracter")
				.HasColumnType("int(24)")
				.IsRequired();

			builder.Property(a => a.CreatedOn)
				.HasColumnName("createdon")
				.HasColumnType("datetime2")
				.HasConversion(
					a => a.ToString(),
					v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null));
		}
	}
}
