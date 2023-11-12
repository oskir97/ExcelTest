using CommonLibraryProjects.Exceptions.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ExcelTest.EFC.DataContexts.Guards
{
    public static class DataContextGuards
    {
        public static async ValueTask SaveChanges(DbContext context)
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DatabaseException(ex.InnerException?.Message ?? ex.Message, ex.Entries.Select(e => e.Entity.GetType().Name).ToList());
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex.Message);
            }
        }
    }
}
