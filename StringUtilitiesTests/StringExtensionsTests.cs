using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringUtilities;

namespace StringUtilitiesTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        private const string source = "\t\r\n ABC\t\r\n DEF \tGHI \t\r\n";

        [TestMethod]
        public void RemoveControlCharsTest()
        {
            var expected = " ABC DEF GHI ";

            var ret = source.RemoveControlChars();
            Assert.AreEqual(expected, ret);
        }

        [TestMethod]
        public void TrimExTest()
        {
            var expected = "ABC\t\r\n DEF \tGHI";

            var ret = source.TrimEx();
            Assert.AreEqual(expected, ret);
        }

        [TestMethod]
        public void TrimStartExTest()
        {
            var expected = "ABC\t\r\n DEF \tGHI \t\r\n";

            var ret = source.TrimStartEx();
            Assert.AreEqual(expected, ret);
        }

        [TestMethod]
        public void TrimEndExTest()
        {
            var expected = "\t\r\n ABC\t\r\n DEF \tGHI";

            var ret = source.TrimEndEx();
            Assert.AreEqual(expected, ret);
        }
    }
}