namespace ConsoleApp4;

public class ArchType
{
    public List<byte> Data { get; set; } = new List<byte>(); // TODO: for future optimizations , could use keep memory pool
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

    public Guid GetCachedGuid(Guid[] componentsSequenceSortedGuids, int index)
    {
        if (index > componentsSequenceSortedGuids.Length - 1) return _chechedGuid;

        if (_followingComponentsNodes.TryGetValue(componentsSequenceSortedGuids[index], out var node))
        {
            return node.GetCachedGuid(componentsSequenceSortedGuids, index + 1);
        }


        var new_node = new ArchTypeHashingCacheNode(componentsSequenceSortedGuids.HashingGuidsVector(0, index));
        _followingComponentsNodes.Add(componentsSequenceSortedGuids[index],new_node);
        return new_node.GetCachedGuid(componentsSequenceSortedGuids, index + 1);
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

    public Guid GetHashFromSortedVector(Guid[] componentsSequenceGuidsSortedVector)
    => _headerComponentsNode.GetCachedGuid(componentsSequenceGuidsSortedVector, 0);

    #region Private fields

    private readonly ArchTypeHashingCacheNode _headerComponentsNode;

    #endregion
}

public class ArchTypeQuery
{
    public List<byte>? Data { get; set; }
}


public class ArchTypeDataStorage
{
    private Dictionary<Guid, ArchType> _archtypesDataDict;
    private ArchTypeHashingCache _archTypeHashingCache;

    public ArchTypeDataStorage(ArchTypeHashingCache archTypeHashingCache)
    {
        _archTypeHashingCache = archTypeHashingCache;
        _archtypesDataDict = new Dictionary<Guid, ArchType>();
    }

    public ArchTypeQuery GetQueryForArchType(Guid[] archTypeComponentsGuidsSortedVector)
    {
        var hash = _archTypeHashingCache
            .GetHashFromSortedVector(archTypeComponentsGuidsSortedVector);
        if (!_archtypesDataDict.TryGetValue(hash, out var archtypeData)){
            _archtypesDataDict.Add(hash, new ArchType());
        }
        var data = archtypeData.Data;
        return new ArchTypeQuery { Data = data };
    }
}