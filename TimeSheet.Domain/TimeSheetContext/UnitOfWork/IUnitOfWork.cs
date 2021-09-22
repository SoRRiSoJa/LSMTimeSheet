namespace TimeSheet.Domain.TimeSheetContext.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
