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
        if (index == componentsSequenceGuids.Length - 1) return _chechedGuid;

        var node = _followingComponentsNodes[componentsSequenceGuids[index]];

        if (node != null)
        {
            return node.GetCachedGuid(componentsSequenceGuids, index + 1);
        }


        var new_node = new ArchTypeHashingCacheNode(HashingGuidsVector(componentsSequenceGuids, 0, index));
        _followingComponentsNodes.Add(componentsSequenceGuids[index],new_node);
        return new_node.GetCachedGuid(componentsSequenceGuids, index + 1);
    }

    #region Private Methods

    private Guid XorGuids(Guid guid1, Guid guid2)
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

    public Guid HashingGuidsVector(Guid[] guids, int startIdx, int endIdx)
    {
        var result = Guid.Empty;
        for (int i = startIdx; i < endIdx; i++)
        {
            result = XorGuids(result, guids[i]);
        }
        return result;
    }

    #endregion

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


