using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Helpers.Test
{
    [TestClass]
    public class StringLibraryTest
    {
        [TestMethod]
        public void CutStringTest()
        {
            string strCut = "Hello World, This is a test sentence";
            int intChar = 15;

            var expected = "Hello World,...";//
            var actual = StringLibrary.CutString(strCut, intChar);
            Assert.AreEqual(expected, actual);

            
        }

        [TestMethod]
        public void CutStringUnicodeTest()
        {
            string strcut = "안녕하세요. 부경대학교입니다.";
            int intchar = 9;

            var expected = "안녕하세요....";
            var actual = StringLibrary.CutStringUnicode(strcut, intchar);
            Assert.AreEqual(expected, actual);

        }

    }
}
