using ExcelTest.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ExcelTest.EFC.DataContexts
{
    public class ApplicationWriteContext : DbContext
    {
        public ApplicationWriteContext(DbContextOptions<ApplicationWriteContext> options) : base(options)
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
