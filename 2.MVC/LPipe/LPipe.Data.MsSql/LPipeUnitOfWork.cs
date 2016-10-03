namespace LPipe.Data.MsSql
{
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    using LPipe.Data.Contracts;
    using LPipe.Data.MsSql.Context;

    public class LPipeUnitOfWork : IUnitOfWork
    {
        private readonly LPipeEntities _context;

        public LPipeUnitOfWork()
        {
            _context = new LPipeEntities();
            ((IObjectContextAdapter)_context).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }

        internal LPipeEntities Context
        {
            get { return this._context; }
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        public Task CommitAsync()
        {
            return this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
