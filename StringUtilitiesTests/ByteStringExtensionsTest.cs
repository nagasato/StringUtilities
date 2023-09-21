using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringUtilities;

namespace StringUtilitiesTests
{
    [TestClass]
    public class ByteStringExtensionsTest
    {
        public ByteStringExtensionsTest()
        {
#if NET
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif
        }

        [TestMethod]
        public void FixedByteSplit()
        {
            var source1 = "1壱45弐890";
            var expected1 = new string[]
            {
                "1",
                "壱",
                "45",
                "弐",
                "89",
                "0"
            };

            var encoding = Encoding.GetEncoding("Shift_JIS");
            var ret1 = source1.FixedByteSplit(2, encoding).ToArray(); // Shift_JIS
            for(var i = 0; i < expected1.Length; i++)
            {
                Assert.AreEqual(expected1[i], ret1[i]);
            }
        }

        [TestMethod]
        public void PadByteLeftTest()
        {
            // TODO: Dictionaryに書き換える ( [key]expected -> [value]ret )
            var source1 = "愛";
            var expected1 = new string[]
            {
                "愛",    // byteLength=0
                "愛",    // byteLength=1
                "愛",    // byteLength=2
                " 愛",   // byteLength=3
                "  愛",  // byteLength=4
            };

            var encoding = Encoding.GetEncoding("Shift_JIS");
            var ret1 = Enumerable.Range(0, expected1.Length).Select(i => source1.PadByteLeft(i, encoding)).ToArray();
            for (var i = 0; i < expected1.Length; i++)
            {
                Assert.AreEqual(expected1[i], ret1[i]);
            }
        }

        [TestMethod]
        public void PadByteRightTest()
        {
            var source1 = "愛";
            var expected1 = new string[]
            {
                "愛",    // byteLength=0
                "愛",    // byteLength=1
                "愛",    // byteLength=2
                "愛 ",   // byteLength=3
                "愛  ",  // byteLength=4
            };

            var encoding = Encoding.GetEncoding("Shift_JIS");
            var ret1 = Enumerable.Range(0, expected1.Length).Select(i => source1.PadByteRight(i, encoding)).ToArray();
            for (var i = 0; i < expected1.Length; i++)
            {
                Assert.AreEqual(expected1[i], ret1[i]);
            }
        }
    }
}
