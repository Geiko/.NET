namespace LPipe.Data.Queries.Material
{
    using LPipe.Data.Contracts;

    public class UniqueMaterialCriteria : IQueryCriteria
    {
        public string Name { get; set; }

        public int? EntityId { get; set; }
    }
}