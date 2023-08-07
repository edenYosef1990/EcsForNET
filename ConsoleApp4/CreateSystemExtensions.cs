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
        //var bla = systemFunction.GetMethodInfo().GetParameters();
        //foreach (var para in bla)
        //{
        //    Console.WriteLine(para.ParameterType.ToString());
        //    var stam = para.GetType();
        //    if (para.ParameterType.IsConstructedGenericType)
        //    {
        //        Console.WriteLine("generic!");
        //        foreach (var genericType in para.ParameterType.GetGenericArguments())
        //        {
        //            Console.WriteLine("\t" + genericType.ToString());
        //        }
        //    }
        //}
    }

    public static void CreateSystem<A, B>(Action<A, B> systemFunction)
        where A : IQuery
        where B : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C>(Action<A, B, C> systemFunction)
        where A : IQuery
        where B : IQuery
        where C : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C, D>(Action<A, B, C, D> systemFunction)
        where A : IQuery
        where B : IQuery
        where C : IQuery
        where D : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var DGuid = typeof(D).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid, DGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C, D, E>(Action<A, B, C, D, E> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var DGuid = typeof(D).GUID;
        var EGuid = typeof(E).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid, DGuid, EGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C, D, E, F>(Action<A, B, C, D, E, F> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    where F : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var DGuid = typeof(D).GUID;
        var EGuid = typeof(E).GUID;
        var FGuid = typeof(F).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid, DGuid, EGuid, FGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C, D, E, F, G, H>(Action<A, B, C, D, E, F, G> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    where F : IQuery
    where G : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var DGuid = typeof(D).GUID;
        var EGuid = typeof(E).GUID;
        var FGuid = typeof(F).GUID;
        var GGuid = typeof(G).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid, DGuid, EGuid, FGuid, GGuid };
        sortedGuidVector.Sort();

    }

    public static void CreateSystem<A, B, C, D, E, F, G ,H>(Action<A, B, C, D, E, F, G, H> systemFunction)
    where A : IQuery
    where B : IQuery
    where C : IQuery
    where D : IQuery
    where E : IQuery
    where F : IQuery
    where G : IQuery
    where H : IQuery
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var DGuid = typeof(D).GUID;
        var EGuid = typeof(E).GUID;
        var FGuid = typeof(F).GUID;
        var GGuid = typeof(G).GUID;
        var HGuid = typeof(H).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid, DGuid, EGuid, FGuid, GGuid, HGuid };
        sortedGuidVector.Sort();
    }
}
