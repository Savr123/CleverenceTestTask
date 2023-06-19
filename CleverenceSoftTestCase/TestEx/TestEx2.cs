using NUnit.Framework;
using Task2;

namespace TestEx
{
    public class TestEx2
    {
        [Test] 
        public void Test()
        {
            Assert.AreEqual(
                Task2.Program.SpiralCounterclockwise(new int[,] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 } }),
                new int[] { 1, 6, 11, 12, 13, 14, 15, 10, 5, 4, 3, 2, 7, 8, 9 }
            );
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(Program.SpiralCounterclockwise(new int[,] { { 1, 2, 3, 4 } }), new int[] { 1, 2, 3, 4 });
        }
        [Test]
        public void Test3()
        {
            Assert.AreEqual(Program.SpiralCounterclockwise(new int[,] { { } }), new int[] { });
        }
        [Test]
        public void Test4()
        {
            Assert.Catch<NullReferenceException>(() => Program.SpiralCounterclockwise(null));
        }
    }
}
