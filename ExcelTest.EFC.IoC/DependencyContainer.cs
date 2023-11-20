using ExcelTest.Common.Interfaces;
using ExcelTest.EFC.DataContexts;
using ExcelTest.EFC.Repositories;
using ExcelTest.EFC.DataContexts.DbConnection;
using ExcelTest.EFC.Repositories.Queries;
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

            // Configuración del contexto de migración
            services.AddDbContext<MigrationContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(writeConnectionStringName);

                if (connectionString != null)
                    options.UseMySQL(connectionString);
            });

            // Configuración de Dapper

            services.AddSingleton<IDbConnectionFactory>(provider =>
            {
                return new DbConnectionFactory(configuration, readConnectionStringName, writeConnectionStringName);
            });

            // Registro de repositorio de escritura
            services.AddScoped<IWritableOrdersRepository, OrdersWritableRepository>();

            // Registro de repositorio de lectura
            services.AddScoped<IReadableOrdersRepository, OrdersReadableRepository>();

            //GraphQL
            services.AddScoped<OrdersQuery>();

            services.AddGraphQL();

            services.AddGraphQLServer().AddQueryType<OrdersQuery>();

            return services;
        }
    }
}
