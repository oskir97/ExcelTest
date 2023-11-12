using ExcelTest.Common.Interfaces;
using ExcelTest.EFC.DataContexts;
using ExcelTest.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System.Data;

namespace ExcelTest.EFC.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services, IConfiguration configuration, string readConnectionStringName, string writeConnectionStringName)
        {
            // Configuración del contexto de lectura
            services.AddDbContext<ApplicationReadContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(readConnectionStringName);
                
                if(connectionString != null)
                    options.UseMySQL(connectionString);
            });

            // Configuración del contexto de escritura
            services.AddDbContext<ApplicationWriteContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(writeConnectionStringName);

                if (connectionString != null)
                    options.UseMySQL(connectionString);
            });

            // Configuración del contexto de migración
            services.AddDbContext<MigrationContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(writeConnectionStringName);

                if (connectionString != null)
                    options.UseMySQL(connectionString);
            });

            // Configuración de Dapper
            services.AddScoped<IDbConnection>(_ => new MySqlConnection(configuration.GetConnectionString(writeConnectionStringName)));

            // Registro de repositorio de escritura
            services.AddScoped<IWritableOrderRepository, OrderWritableRepository>();

            return services;
        }
    }
}
