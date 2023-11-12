namespace ExcelTest.Entities.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}