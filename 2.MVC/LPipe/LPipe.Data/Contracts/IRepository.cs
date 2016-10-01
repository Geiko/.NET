namespace LPipe.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets unit of work for data store.
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}