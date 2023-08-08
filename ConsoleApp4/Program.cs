namespace ConsoleApp4
{

    public class Bla<T> : Query
    {
        public Bla(T t) { }
    }
    public interface GenericInteface { }

    public class EdenGenericClass<T, K> : GenericInteface
    {
        public T val { get; set; }

        public EdenGenericClass(T t)
        {
            val = t;
        }
    }

    public struct CompA
    {
        int a;
        int b;
    }

    public struct CompB
    {
        int a;
        int b;
    }

    internal class Program
    {
        public void foo(int arg1, int arg2, string arg3, GenericInteface arg4)
        {

        }

        static void Main(string[] args)
        {
            //CreateSystemExtensions.CreateSystem(((Bla<int> a) => { }));
            CreateSystemExtensions.CreateSystem(((ComponentsQuery<CompA,CompB> a) => { }));

            //var guid1 = Guid.NewGuid();
            //var guid2 = Guid.NewGuid();
            //var guid3 = Guid.NewGuid();
            //var guids = new Guid[] { guid1, guid2, guid3 };
            //var cache = new ArchTypeHashingCache();
            //var res = cache.GetHashFromSortedVector(guids);
            //var otherRes = new Guid[] { guid1, guid2, guid3 }.HashingGuidsVector(0, 2);
            //var isEqual = res.Equals(otherRes);
        }
    }
}