using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CloudSuite.Infrastructure.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoreDbContext>
    {
        public CoreDbContext CreateDbContext(string[] args)
        {
            
            var repositoryRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../../"));
            var envPath = Path.Combine(repositoryRoot, ".env");
            
            Console.WriteLine($"Looking for .env em: {envPath}");
            Console.WriteLine($"Diretório atual: {Directory.GetCurrentDirectory()}");

            if (File.Exists(envPath))
            {
                Console.WriteLine("✅  .env not found! Load variables...");
                LoadEnvFile(envPath);
            }
            else
            {
                Console.WriteLine("❌ Arquivo .env não encontrado no caminho principal!");
                
                
                var alternativePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                if (File.Exists(alternativePath))
                {
                    Console.WriteLine("✅ Arquivo .env encontrado no projeto Infrastructure!");
                    LoadEnvFile(alternativePath);
                }
                else
                {
                    Console.WriteLine("❌ Arquivo .env não encontrado em nenhum caminho!");
                    Console.WriteLine("Tentando usar variáveis de ambiente existentes...");
                }
            }

            
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");

            
            Console.WriteLine($"DB_HOST: {dbHost ?? "NULL"}");
            Console.WriteLine($"DB_PORT: {dbPort ?? "NULL"}");
            Console.WriteLine($"DB_USER: {dbUser ?? "NULL"}");
            Console.WriteLine($"DB_NAME: {dbName ?? "NULL"}");
            Console.WriteLine($"DB_PASSWORD: {(string.IsNullOrEmpty(dbPassword) ? "NULL" : "***")}");

            
            if (string.IsNullOrEmpty(dbHost) || string.IsNullOrEmpty(dbUser) || 
                string.IsNullOrEmpty(dbPassword) || string.IsNullOrEmpty(dbName))
            {
                Console.WriteLine("⚠️  Usando valores padrão para conexão...");
                dbHost = "localhost";
                dbPort = "5432";
                dbUser = "postgres";
                dbPassword = "password";
                dbName = "cloudsuite_core";
            }

            var connectionString = $"Host={dbHost};" +
                                  $"Port={dbPort};" +
                                  $"Database={dbName};" +
                                  $"Username={dbUser};" +
                                  $"Password={dbPassword};" +
                                  "SSL Mode=Require;" +
                                  "Trust Server Certificate=true;" +
                                  "Timeout=300;" +
                                  "Command Timeout=300;" +
                                  "Pooling=true;";

            Console.WriteLine($"Connection String: {connectionString.Replace(dbPassword, "***")}");

            var optionsBuilder = new DbContextOptionsBuilder<CoreDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new CoreDbContext(optionsBuilder.Options);
        }

        private void LoadEnvFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue;

                var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    var key = parts[0].Trim();
                    var value = parts[1].Trim();

                    if (value.StartsWith("\"") && value.EndsWith("\"") && value.Length > 1)
                        value = value.Substring(1, value.Length - 2);

                    Environment.SetEnvironmentVariable(key, value);
                    Console.WriteLine($"✅ Variável carregada: {key}");
                }
            }
        }
    }
}