namespace TestProject1
{
    public class UnitTestDayOfTheProgrammer
    {
        [Fact]
        public void TetsCase1()
        {
            Calc c = new Calc(1984);
            var res = c.GetDate();
            Assert.Equal("12.09.1984", res);
        }

        [Fact]
        public void TetsCase2()
        {
            Calc c = new Calc(2017);
            var res = c.GetDate();
            Assert.Equal("13.09.2017", res);
        }

        [Fact]
        public void TetsCase3()
        {
            Calc c = new Calc(1812);
            var res = c.GetDate();
            Assert.Equal("12.09.1812", res);
        }

        [Fact]
        public void TetsCase4()
        {
            Calc c = new Calc(1800);
            var res = c.GetDate();
            Assert.Equal("12.09.1800", res);
        }

        [Fact]
        public void TetsCase5()
        {
            Calc c = new Calc(1918);
            var res = c.GetDate();
            Assert.Equal("26.09.1918", res);
        }
    }
}