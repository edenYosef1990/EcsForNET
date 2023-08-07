namespace ConsoleApp4
{
    public interface IQuery { }

    public class FunctionContainer
    {
        public FunctionContainer(Action<IQuery> systemFunction) { }
        public FunctionContainer(Action<IQuery, IQuery> systemFunction) { }
        public FunctionContainer(Action<IQuery, IQuery, IQuery> systemFunction) { }
        public FunctionContainer(Action<IQuery, IQuery, IQuery, IQuery> systemFunction) { }
        public FunctionContainer(Action<IQuery, IQuery, IQuery, IQuery, IQuery> systemFunction) { }
        public FunctionContainer(Action<IQuery, IQuery, IQuery, IQuery, IQuery, IQuery> systemFunction) { }
        public FunctionContainer(Action<IQuery, IQuery, IQuery, IQuery, IQuery, IQuery, IQuery> systemFunction) { }
    }

    public class EdenGenericClass<T,K>
    {
        public T val { get; set; }

        public EdenGenericClass(T t)
        {
            val = t;
        }
    }

    internal class Program
    {
        public void foo(int arg1, int arg2, string arg3, EdenGenericClass<int,string> arg4)
        {

        }

        private static Guid XorGuids(Guid guid1, Guid guid2)
        {
            const int BYTECOUNT = 16;
            byte[] destByte = new byte[BYTECOUNT];
            byte[] guid1Byte = guid1.ToByteArray();
            byte[] guid2Byte = guid2.ToByteArray();

            for (int i = 0; i < BYTECOUNT; i++)
            {
                destByte[i] = (byte)(guid1Byte[i] ^ guid2Byte[i]);
            }
            return new Guid(destByte);
        }

        public static Guid HashingGuidsVector(Guid[] guids, int startIdx, int endIdx)
        {
            var result = Guid.Empty;
            for (int i = startIdx; i <= endIdx; i++)
            {
                result = XorGuids(result, guids[i]);
            }
            return result;
        }

        static void Main(string[] args)
        {
            //var bla = typeof(Program)!.GetMethod("foo")!.GetParameters();
            //var myType = bla[3].ParameterType;
            //foreach (var para in bla) {
            //    Console.WriteLine(para.ParameterType.ToString());
            //    if (para.ParameterType.IsConstructedGenericType) {
            //        Console.WriteLine("generic!");
            //        foreach(var genericType in para.ParameterType.GetGenericArguments()) {
            //            Console.WriteLine("\t"+genericType.ToString());
            //        }
            //    }
            //}    
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();
            var guids = new Guid[] {guid1,guid2, guid3};
            var cache = new ArchTypeHashingCache();
            var res = cache.GetHashFromSortedVector(guids);
            var otherRes = HashingGuidsVector(new Guid[] { guid1, guid2, guid3 }, 0, 2);
            var isEqual = res.Equals(otherRes);
        }
    }
}