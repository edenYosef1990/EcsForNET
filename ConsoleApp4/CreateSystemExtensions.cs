using System.Reflection;

namespace ConsoleApp4;

public class RetunVal
{
    public SystemQueryInfo Info { get; set; }
    public Action Action { get; set; }
}
public static class CreateSystemExtensions
{
    public static SystemQueryInfo CreateSystem<A>(Action<A> systemFunction)
    where A : Query
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

        return SystemQueryFactory.GenerateSystemQueryInfo(new Type[] { typeof(A) });
    }



    public static RetunVal CreateSystem<A, B>(Action<A, B> systemFunction)
        where A : Query
        where B : Query
    {
        var info = SystemQueryFactory.GenerateSystemQueryInfo(new Type[] { typeof(A), typeof(B) });
        return new RetunVal()
        {
            Info = info,
            Action = (() => systemFunction((A)info.Queries[0], (B)info.Queries[1]))
        };
    }

    public static void CreateSystem<A, B, C>(Action<A, B, C> systemFunction)
        where A : Query
        where B : Query
        where C : Query
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C, D>(Action<A, B, C, D> systemFunction)
        where A : Query
        where B : Query
        where C : Query
        where D : Query
    {
        var AGuid = typeof(A).GUID;
        var BGuid = typeof(B).GUID;
        var CGuid = typeof(C).GUID;
        var DGuid = typeof(D).GUID;
        var sortedGuidVector = new List<Guid> { AGuid, BGuid, CGuid, DGuid };
        sortedGuidVector.Sort();
    }

    public static void CreateSystem<A, B, C, D, E>(Action<A, B, C, D, E> systemFunction)
    where A : Query
    where B : Query
    where C : Query
    where D : Query
    where E : Query
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
    where A : Query
    where B : Query
    where C : Query
    where D : Query
    where E : Query
    where F : Query
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
    where A : Query
    where B : Query
    where C : Query
    where D : Query
    where E : Query
    where F : Query
    where G : Query
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

    public static void CreateSystem<A, B, C, D, E, F, G, H>(Action<A, B, C, D, E, F, G, H> systemFunction)
    where A : Query
    where B : Query
    where C : Query
    where D : Query
    where E : Query
    where F : Query
    where G : Query
    where H : Query
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
