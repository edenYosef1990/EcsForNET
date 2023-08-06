namespace ConsoleApp4;

public class Archtype
{

}

public class ArchtypeHashingChacheNode
{
    #region Ctor
    public ArchtypeHashingChacheNode(Guid lastComponentGuid, Guid cachedGuid)
    {
        LastComponentGuid = lastComponentGuid;
        _chechedGuid = cachedGuid;
        _followingComponentsNodes = new List<ArchtypeHashingChacheNode>();
    }

    #endregion

    public Guid LastComponentGuid { get; }

    public Guid getCachedGuid(Guid[] componentsSequenceGuids, int index)
    {
        if (index == componentsSequenceGuids.Length - 1) return _chechedGuid;

        var node = _followingComponentsNodes.Find(node => node.LastComponentGuid == componentsSequenceGuids[index]);

        if (node != null)
        {
            return node.getCachedGuid(componentsSequenceGuids, index + 1);
        }

        var new_node = new ArchtypeHashingChacheNode(componentsSequenceGuids[index],
            HashingGuidsVector(componentsSequenceGuids, 0, index));
        _followingComponentsNodes.Add(new_node);
        return new_node.getCachedGuid(componentsSequenceGuids, index + 1);
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

    private Guid _chechedGuid;
    private List<ArchtypeHashingChacheNode> _followingComponentsNodes;

    #endregion
}

public class ArchtypeHashingCache
{
    public ArchtypeHashingCache()
    {
        _headerComponentsNode = new ArchtypeHashingChacheNode(Guid.Empty, Guid.Empty);
    }

    public Guid GetHashFromSortedVector(Guid[] componentsSequenceGuidsVector)
    => _headerComponentsNode.getCachedGuid(componentsSequenceGuidsVector, 0);

    #region Private fields

    private ArchtypeHashingChacheNode _headerComponentsNode;

    #endregion
}


