﻿namespace LPipe.Data.Queries.Common
{
    using LPipe.Data.Contracts;

    /// <summary>
    /// Get By Id type queries parameters
    /// </summary>
    public class FindByIdCriteria : IQueryCriteria
    {
        /// <summary>
        /// Gets or sets Id of the entity to retrieve.
        /// </summary>
        public int Id { get; set; }
    }
}