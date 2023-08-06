namespace ConsoleApp4;

public class Archtype
    {
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

        public Guid HashingGuidsVector(Guid[] guids)
        {
            var result = Guid.Empty;
            foreach (var guid in guids)
            {
                result = XorGuids(result,guid);
            }
            return result;
        }
    }
