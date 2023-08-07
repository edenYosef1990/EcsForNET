namespace ConsoleApp4;

public class ArchType
{

}

public class ArchTypeHashingCacheNode
{
    #region Ctor
    public ArchTypeHashingCacheNode(Guid cachedGuid)
    {
        _chechedGuid = cachedGuid;
        _followingComponentsNodes = new Dictionary<Guid, ArchTypeHashingCacheNode>();
    }

    #endregion

    public Guid GetCachedGuid(Guid[] componentsSequenceGuids, int index)
    {
        if (index > componentsSequenceGuids.Length - 1) return _chechedGuid;

        if (_followingComponentsNodes.TryGetValue(componentsSequenceGuids[index], out var node))
        {
            return node.GetCachedGuid(componentsSequenceGuids, index + 1);
        }


        var new_node = new ArchTypeHashingCacheNode(componentsSequenceGuids.HashingGuidsVector(0, index));
        _followingComponentsNodes.Add(componentsSequenceGuids[index],new_node);
        return new_node.GetCachedGuid(componentsSequenceGuids, index + 1);
    }

    #region Private Fields

    private readonly Guid _chechedGuid;
    private readonly Dictionary<Guid,ArchTypeHashingCacheNode> _followingComponentsNodes;

    #endregion
}

public class ArchTypeHashingCache
{
    public ArchTypeHashingCache()
    {
        _headerComponentsNode = new ArchTypeHashingCacheNode(Guid.Empty);
    }

    public Guid GetHashFromSortedVector(Guid[] componentsSequenceGuidsVector)
    => _headerComponentsNode.GetCachedGuid(componentsSequenceGuidsVector, 0);

    #region Private fields

    private readonly ArchTypeHashingCacheNode _headerComponentsNode;

    #endregion
}


