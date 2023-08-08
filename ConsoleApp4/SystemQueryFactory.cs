namespace ConsoleApp4
{
    public class SystemQueryInfo
    {
        public List<Query> Queries = new List<Query>();
    }
    public static class SystemQueryFactory
    {
        public static SystemQueryInfo GenerateSystemQueryInfo(Type[] queriesTypes)
        {
            return new SystemQueryInfo();
        }
    }
}
