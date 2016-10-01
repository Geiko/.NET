namespace LPipeManagement.Data.MsSql
{
    using System.Data.Entity.Infrastructure;
    using System.Threading.Tasks;

    using LPipe.Data.Contracts;
    using LPipe.Data.MsSql.Context;

    /// <summary>
    /// Defines Entity Framework implementation of the IUnitOfWork contract.
    /// </summary>
    internal class LPipeUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Context of the data source.
        /// </summary>
        private readonly LPipeEntities _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="LPipeUnitOfWork"/> class.
        /// </summary>
        public LPipeUnitOfWork()
        {
            _context = new LPipeEntities();
            ((IObjectContextAdapter)_context).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Gets context of the data source.
        /// </summary>
        internal LPipeEntities Context
        {
            get { return this._context; }
        }

        /// <summary>
        /// Commits all the changes.
        /// </summary>
        public void Commit()
        {
            this._context.SaveChanges();
        }

        /// <summary>
        /// Asynchronously commits all changes into the store
        /// </summary>
        /// <returns>Task to await</returns>
        public Task CommitAsync()
        {
            return this._context.SaveChangesAsync();
        }

        /// <summary>
        /// IDisposable.Dispose method implementation.
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}
