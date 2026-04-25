using System;

namespace Level5_DDD
{
    // 265. Unit of Work Pattern.
    // It coordinates the writing out of changes. If you update the Worker table 
    // and the Payroll table, Unit of Work ensures both succeed or both fail together.

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }

    public class SiteUnitOfWork : IUnitOfWork
    {
        public void Commit() => Console.WriteLine("[UnitOfWork] All changes persisted to DB in one transaction.");
        public void Rollback() => Console.WriteLine("[UnitOfWork] Transaction failed. All changes rolled back.");
        public void Dispose() { }
    }

    class Program
    {
        static void Main()
        {
            using var uow = new SiteUnitOfWork();
            // Perform multiple repository actions...
            uow.Commit();
        }
    }
}