namespace TestProject1
{
    public class UnitTestTimeConvert
    {
        [Fact]
        public void TetsCase0()
        {
            var s = "06:40:03AM";
            var res = TConverter.Run(s);
            Assert.Equal("06:40:03", res);
        }

        [Fact]
        public void TetsCase1()
        {
            var s = "07:05:45PM";
            var res = TConverter.Run(s);
            Assert.Equal("19:05:45", res);
        }

        [Fact]
        public void TetsCase2()
        {
            var res = TConverter.Run("-12:00:00AM");
            Assert.Equal("00:00:00", res);
        }

        [Fact]
        public void TetsCase3()
        {
            var res = TConverter.Run("-12:00:00PM");
            Assert.Equal("12:00:00", res);
        }

        [Fact]
        public void TetsCase4()
        {
            var res = TConverter.Run("-12:01:00AM");
            Assert.Equal("23:59:00", res);
        }

        [Fact]
        public void TetsCase5()
        {
            var res = TConverter.Run("-12:00:00PM");
            Assert.Equal("12:00:00", res);
        }

        [Fact]
        public void TetsCase6()
        {
            var res = TConverter.Run("12:05:39AM");
            Assert.Equal("00:05:39", res);
        }

        [Fact]
        public void TetsCase7()
        {
            var res = TConverter.Run("12:45:54PM");
            Assert.Equal("12:45:54", res);
        }

        

    }
}