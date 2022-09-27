namespace TestProject1
{
    public class UnitTestGradingStudents
    {
        [Fact]
        public void TetsCase1()
        {
            var res = Grading.Run(27);
            Assert.Equal(27, res);
        }

        [Fact]
        public void TetsCase2()
        {
            var res = Grading.Run(84);
            Assert.Equal(85, res);
        }

        [Fact]
        public void TetsCase3()
        {
            var res = Grading.Run(93);
            Assert.Equal(95, res);
        }

        [Fact]
        public void TetsCase4()
        {
            var res = Grading.Run(57);
            Assert.Equal(57, res);
        }

        [Fact]
        public void TetsCase5()
        {
            List<int> list = new List<int>() { 73, 67, 38, 33 };
            List<int> expected = new List<int>() { 75, 67, 40, 33 };
            List<int> output = Grading.RunAll(list);
            Assert.Equal(4, output.Count);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void TetsCase6()
        {
            List<int> list = new List<int>() { 0, 67, 38, 33, 99, 100 };
            List<int> expd = new List<int>() { 0, 67, 40, 33, 100, 100 };
            List<int> output = Grading.RunAll(list);
            Assert.Equal(6, output.Count);
            Assert.Equal(expd, output);
        }

    }
}