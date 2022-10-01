using System.Diagnostics;

namespace TestProject1
{
    public class UnitTestHakerRankEncryption
    {
        [Fact]
        public void TetsCase1()
        {
            var res = HakerRankEncryptionSolver.Run("haveaniceday");
            Assert.Equal("hae and via ecy", res);
        }

        [Fact]
        public void TetsCase2()
        {
            var res = HakerRankEncryptionSolver.Run("feedthedog");
            Assert.Equal("fto ehg ee dd", res);
        }

        [Fact]
        public void TetsCase3()
        {
            var res = HakerRankEncryptionSolver.Run("chillout");
            Assert.Equal("clu hlt io", res);
        }
    }
}