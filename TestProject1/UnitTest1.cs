namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void CheckDataDirectory()
        {
            var files = SolutionBase.GetDataFiles();
            Assert.NotNull(files);
            Assert.True(files.Length > 0);
        }

        [Fact]
        public void CheckArrays()
        {
            var files = SolutionBase.GetDataFiles();
            Assert.NotNull(files);
            Assert.True(files.Length > 0);
            foreach (var file in files)
            {
                var arr = SolutionBase.GetArray(file);
                Assert.True(arr.Count > 0);
            }
        }

        [Fact]
        public void TetsCase1()
        {
            var files = SolutionBase.GetDataFiles();
            Assert.NotNull(files);
            Assert.True(files.Length > 0);
            var file = files.Where(x => x.Name.ToLower() == "data1.txt").First();
            Assert.NotNull(file);
            var arr = SolutionBase.GetArray(file);
            Assert.True(arr.Count > 0);
            List<int> result = Result.minimalHeaviestSetA(arr);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            //Assert.Equal(2, result.Count);
        }

        [Fact]
        public void TetsCase2()
        {
            var arr = new List<int>() { 3, 7, 5, 6, 2 };
            List<int> result = Result.minimalHeaviestSetA(arr);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
            Assert.Equal(2, result.Count);
            Assert.Equal((int)6, result[0]);
            Assert.Equal((int)7, result[1]);
        }
    }
}