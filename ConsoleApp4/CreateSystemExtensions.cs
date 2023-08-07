using System.Reflection;

namespace ConsoleApp4;

public class QueryClass<T> : IQuery
{
    public QueryClass(T val) { }
}

public interface IQuery { }
public static class CreateSystemExtensions
{
    public static void CreateSystem<A>(Action<A> systemFunction)
    where A : IQuery
    {
        var bla = systemFunction.GetMethodInfo().GetParameters();
        foreach (var para in bla)
        {
            Console.WriteLine(para.ParameterType.ToString());
            var stam = para.GetType();
            if (para.ParameterType.IsConstructedGenericType)
            {
                Console.WriteLine("generic!");
                foreach (var genericType in para.ParameterType.GetGenericArguments())
                {
                    Console.WriteLine("\t" + genericType.ToString());
                }
            }
        }
    }

    public static void CreateSystem<A, B>(Action<A, B> systemFunction)
        where A : IQuery
        where B : IQuery
    { }

    public static void CreateSystem<A, B, C>(Action<A, B, C> systemFunction)
        where A : IQuery
        where B : IQuery
        where C : IQuery
    { }

    public static void CreateSystem<A, B, C, D>(Action<A, B, C, D> systemFunction)
        where A : IQuery
        where B : IQuery
        where C : IQuery
        where D : IQuery
    { }

    public static void CreateSystem<A, B, C, D, E>(Action<A, B, C, D, E> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    { }

    public static void CreateSystem<A, B, C, D, E, F>(Action<A, B, C, D, E, F> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    where F : IQuery
    { }

    public static void CreateSystem<A, B, C, D, E, F, G, H>(Action<A, B, C, D, E, F, G> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    where F : IQuery
    where G : IQuery
    { }

    public static void CreateSystem<A, B, C, D, E, F, G ,H>(Action<A, B, C, D, E, F, G, H> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    where F : IQuery
    where G : IQuery
    where H : IQuery
    { }
}
