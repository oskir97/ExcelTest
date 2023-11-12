using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExcelTest.EFC.DataContexts
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<MigrationContext>
    {
        MigrationContext IDesignTimeDbContextFactory<MigrationContext>.CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<MigrationContext> optionsBuilder = new DbContextOptionsBuilder<MigrationContext>();
            string connectionString = "server=localhost;user id = ExcelTest; password = 123456; persistsecurityinfo = True; database = ExcelTest";
            optionsBuilder.UseMySQL(connectionString);
            return new MigrationContext(optionsBuilder.Options);
        }
    }
}
