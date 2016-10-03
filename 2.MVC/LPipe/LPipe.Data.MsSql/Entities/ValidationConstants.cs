namespace LPipe.Data.MsSql.Entities
{
    /// <summary>
    /// Database validation constraints
    /// </summary>
    internal static class ValidationConstants
    {
        public const int EMPTY_DATABASE_ID_VALUE = 0;

        public static class Material
        {
            public const int MAX_NAME_LENGTH = 60;
        }
    }
}