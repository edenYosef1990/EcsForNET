using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public abstract class ComponentBase
    {
        public int id;
    }

    public abstract class RelationSideBase { }
    public class SpecificRelationalSide : RelationSideBase
    {
        public int entityId;
    }

    public sealed class Everyone : RelationSideBase { }
    public sealed class Nobody : RelationSideBase { }
    public class EcsRepository
    {
        public T GetComponentForId<T>(int entityId, Guid ComponentTypeGuid) where T: ComponentBase {
           if(!ComponentsRepositroy.TryGetValue(ComponentTypeGuid, out var ComponentRepository))
            {
                throw new Exception("Invalid Type GUID!");
            }
            return (T)ComponentRepository.First(x => x.id == entityId);
        }

        public void SetComponentForId<T>(T component) where T: ComponentBase, new()
        {
            var ComponentTypeGuid = typeof(T).GUID;
            if (!ComponentsRepositroy.TryGetValue(ComponentTypeGuid, out var ComponentRepository))
            {
                ComponentsRepositroy.Add(ComponentTypeGuid,new List<ComponentBase>());
            }
            ComponentRepository!.Add(component);
        }

        public void SetRelation<R>(int leftEntity, int RightEntity)
        {
            var relationTypeGuid = typeof(R).GUID;
            if (!RelationsRepositroy.TryGetValue(relationTypeGuid, out var relationRepository))
            {
                RelationsRepositroy.Add(relationTypeGuid, new List<(int,int)>());
            }
            relationRepository!.Add((leftEntity, RightEntity));
        }

        public void QueryRelation<R>(RelationSideBase leftSide, RelationSideBase rightSide) { }

        public readonly Dictionary<Guid, List<(int, int)>> RelationsRepositroy = new Dictionary<Guid, List<(int, int)>>();
        public readonly Dictionary<Guid, List<ComponentBase>> ComponentsRepositroy = new Dictionary<Guid, List<ComponentBase>>();
    }
}
