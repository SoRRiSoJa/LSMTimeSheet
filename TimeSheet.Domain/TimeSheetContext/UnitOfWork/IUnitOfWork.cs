namespace TimeSheet.Domain.TimeSheetContext.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        bool Commit();
        void Rollback();
    }
}
