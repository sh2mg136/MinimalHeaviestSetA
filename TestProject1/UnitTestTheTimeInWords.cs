namespace TestProject1
{
    public class UnitTestTheTimeInWords
    {
        [Fact]
        public void TetsCase01()
        {
            // var res = TimeToWordConverter.Run(5, 45);
            var res = TimeToWordConverter.Convert(5, 45);
            Assert.Equal("quarter to six", res);
        }

        [Fact]
        public void TetsCase02()
        {
            var res = TimeToWordConverter.Convert(5, 0);
            Assert.Equal("five o' clock", res);
        }

        [Fact]
        public void TetsCase03()
        {
            var res = TimeToWordConverter.Convert(5, 1);
            Assert.Equal("one minute past five", res);
        }

        [Fact]
        public void TetsCase04()
        {
            var res = TimeToWordConverter.Convert(5, 10);
            Assert.Equal("ten minutes past five", res);
        }

        [Fact]
        public void TetsCase05()
        {
            var res = TimeToWordConverter.Convert(5, 15);
            Assert.Equal("quarter past five", res);
        }

        [Fact]
        public void TetsCase06()
        {
            var res = TimeToWordConverter.Convert(5, 30);
            Assert.Equal("half past five", res);
        }

        [Fact]
        public void TetsCase07()
        {
            var res = TimeToWordConverter.Convert(5, 45);
            Assert.Equal("quarter to six", res);
        }

        [Fact]
        public void TetsCase08()
        {
            var res = TimeToWordConverter.Convert(5, 47);
            Assert.Equal("thirteen minutes to six", res);
        }

        [Fact]
        public void TetsCase09()
        {
            var res = TimeToWordConverter.Convert(5, 28);
            Assert.Equal("twenty eight minutes past five", res);
        }

        [Fact]
        public void TetsCase10()
        {
            var res = TimeToWordConverter.Convert(12, 0);
            Assert.Equal("twelve o' clock", res);
        }

        [Fact]
        public void TetsCase11()
        {
            var res = TimeToWordConverter.Convert(12, 1);
            Assert.Equal("one minute past twelve", res);
        }


        [Fact]
        public void TetsCase20()
        {
            var res = TimeToWordConverter.Convert(24, 0);
            Assert.Equal("twelve o' clock", res);
        }

        [Fact]
        public void TetsCase21()
        {
            var res = TimeToWordConverter.Convert(0, 0);
            Assert.Equal("twelve o' clock", res);
        }
    }
}