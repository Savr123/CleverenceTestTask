using NUnit.Framework;
using Task1;

namespace TestEx
{
    public class TestEx1
    {
        [Test]
        public void CompressionTest1()
        {
            Assert.AreEqual("a3b3c4d3e2de", Compressor.Compress("aaabbbccccdddeede"));
        }
        [Test]
        public void CompressionTest2()
        {
            Assert.AreEqual("a", Compressor.Compress("a"));

        }
        [Test]
        public void CompressionTest3()
        {
            Assert.AreEqual("ab", Compressor.Compress("ab"));

        }
        [Test]
        public void CompressionTest4()
        {
            Assert.AreEqual("abc2", Compressor.Compress("abcc"));

        }
        [Test]
        public void CompressionTest5()
        {
            Assert.AreEqual("", Compressor.Compress(""));
        }
        [Test]
        public void CompressionTest6()
        {
            Assert.Catch<NullReferenceException>(() => Compressor.Compress(null)); ;
        }
        [Test]
        public void DecompressionTest1()
        {
            Assert.AreEqual("aaabbbccccdddeede", Compressor.Decompress("a3b3c4d3e2de"));
        }
        [Test]
        public void DecompressionTest2()
        {
            Assert.AreEqual("a", Compressor.Decompress("a"));

        }
        [Test]
        public void DecompressionTest3()
        {
            Assert.AreEqual("ab", Compressor.Decompress("ab"));

        }
        [Test]
        public void DecompressionTest4()
        {
            Assert.AreEqual("abcc", Compressor.Decompress("abc2"));

        }
        [Test]
        public void DecompressionTest5()
        {
            Assert.AreEqual("", Compressor.Decompress(""));
        }
        [Test]
        public void DecompressionTest6()
        {
            Assert.Catch<NullReferenceException>(() => Compressor.Decompress(null)); ;
        }

    }
}