namespace ConsoleApp4;

public static class HashingExtensions
{
    public static Guid HashingGuidsVector(this Guid[] guids, int startIdx, int endIdx)
    {
        Guid XorGuids(Guid guid1, Guid guid2)
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

        var result = Guid.Empty;
        for (int i = startIdx; i <= endIdx; i++)
        {
            result = XorGuids(result, guids[i]);
        }
        return result;
    }
}
