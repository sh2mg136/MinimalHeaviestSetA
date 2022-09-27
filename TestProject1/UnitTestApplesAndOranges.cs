namespace TestProject1
{
    public class UnitTestApplesAndOranges
    {
        [Fact]
        public void TetsCase1()
        {
            AAO aao = new AAO(7, 10, 4, 12, new List<int>() { 2, 3, -4 }, new List<int>() { 3, -2, -4 });
            var res = aao.Run();
            Assert.Equal(3, res);
        }

        [Fact]
        public void TetsCase2()
        {
            AAO aao = new AAO(7, 10, 4, 12, new List<int>() { 2, 3, -4 }, new List<int>() { 3, -2, -4 });
            var apl = aao.RunApples();
            var orn = aao.RunOranges();
            Assert.Equal(1, apl);
            Assert.Equal(2, orn);
        }

        [Fact]
        public void TetsCase3()
        {
            AAO aao = new AAO(1, 2, 0, 3, new List<int>() { 1, 2, 3, 4 }, new List<int>() { 3, -1, -2 });

            var apl = aao.RunApples();
            var orn = aao.RunOranges();
            Assert.Equal(2, apl);
            Assert.Equal(2, orn);
        }
    }
}