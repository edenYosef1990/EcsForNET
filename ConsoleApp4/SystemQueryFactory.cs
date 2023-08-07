using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class SystemQueryInfo {
        public List<IQuery> Queries = new List<IQuery>();
    }
    public static class SystemQueryFactory
    {
        public static SystemQueryInfo GenerateSystemQueryInfo(Type[] queriesTypes)
        {
            return new SystemQueryInfo();
        }
    }
}
