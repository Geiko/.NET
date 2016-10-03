namespace LPipe.Data.MsSql.Repositories.Specifications
{
    using LPipe.Crosscutting.Contracts.Specifications;
    using LPipe.Crosscutting.Specifications;
    //using LPipe.Crosscutting.Specifications;
    using LPipe.Data.MsSql.Entities;

    /// <summary>
    /// Specifies Team storage requirements
    /// </summary>
    public class MaterialStorageSpecification : ISpecification<MaterialEntity>
    {
        /// <summary>
        /// Verifies that entity matches specification
        /// </summary>
        /// <param name="entity"> The entity to test </param>
        /// <returns> Results of the match </returns>
        public bool IsSatisfiedBy(MaterialEntity entity)
        {
            var name = new ExpressionSpecification<MaterialEntity>(t =>
                                !string.IsNullOrEmpty(t.Name)
                                && t.Name.Length < ValidationConstants.Material.MAX_NAME_LENGTH);
            
            return name.IsSatisfiedBy(entity);
        }
    }
}