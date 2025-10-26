using CloudSuite.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CloudSuite.Services.Core.Api.Configurations
{
	public static class DatabaseConfig
	{
		public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
			var dbName = Environment.GetEnvironmentVariable("DB_NAME");

			var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword};" +
								  "SSL Mode=Require;Trust Server Certificate=true;Timeout=300;CommandTimeout=300;";

			services.AddDbContext<CoreDbContext>(options =>
				options.UseNpgsql(connectionString));
				
				



		}
	}
}
