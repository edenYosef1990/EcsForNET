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

        static void Main(string[] args)
        {
            var bla = typeof(Program)!.GetMethod("foo")!.GetParameters();
            var myType = bla[3].ParameterType;
            foreach (var para in bla) {
                Console.WriteLine(para.ParameterType.ToString());
                if (para.ParameterType.IsConstructedGenericType) {
                    Console.WriteLine("generic!");
                    foreach(var genericType in para.ParameterType.GetGenericArguments()) {
                        Console.WriteLine("\t"+genericType.ToString());
                    }
                }
            }    
        }
    }
}