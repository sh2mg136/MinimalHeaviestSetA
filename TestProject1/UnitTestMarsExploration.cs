namespace TestProject1
{
    public class UnitTestMarsExploration
    {
        [Fact]
        public void TetsCase1()
        {
            MarsExploration m = new MarsExploration("SOSPOP");
            var res = m.Solve();
            Assert.Equal(2, res);
        }

        [Fact]
        public void TetsCase2()
        {
            MarsExploration m = new MarsExploration("POP");
            var res = m.Solve();
            Assert.Equal(2, res);
        }

        [Fact]
        public void TetsCase3()
        {
            MarsExploration m = new MarsExploration("SOSSPSSQSSOR");
            var res = m.Solve();
            Assert.Equal(3, res);
        }

        [Fact]
        public void TetsCase4()
        {
            MarsExploration m = new MarsExploration("SOSSOSSPSSQSSORSOSSUS");
            var res = m.Solve();
            Assert.Equal(4, res);
        }

        [Fact]
        public void TetsCase5()
        {
            MarsExploration m = new MarsExploration("SOSSOSSPSSQSSORSOSSUSD");
            var res = m.Solve();
            Assert.Equal(4, res);
        }

        [Fact]
        public void TetsCase6()
        {
            MarsExploration m = new MarsExploration("SOSSUSDD");
            var res = m.Solve();
            Assert.Equal(1, res);
        }
    }
}