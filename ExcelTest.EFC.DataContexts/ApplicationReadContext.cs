using System.Reflection;
using ExcelTest.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelTest.EFC.DataContexts
{
    public class ApplicationReadContext : DbContext
    {
        public ApplicationReadContext(DbContextOptions<ApplicationReadContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders => Set<Order>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(
            ));
        }
    }
}
