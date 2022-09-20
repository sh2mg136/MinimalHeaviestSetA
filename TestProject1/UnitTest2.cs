using System.Diagnostics;

namespace TestProject1
{
    public class UnitTest2
    {
        [Fact]
        public void TetsCase1()
        {
            List<int> data = new List<int>() { 20, 13, 8, 9 };
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var res = SolutionBase.GetHeaviestPackage(data);
            stopwatch.Stop();
            Assert.True(res == 50);
            Assert.True(stopwatch.ElapsedMilliseconds < 3000);

            //Assert.NotNull(files);
            //Assert.True(files.Length > 0);
            //var file = files.Where(x => x.Name.ToLower() == "data1.txt").First();
            //Assert.NotNull(file);
            //var arr = SolutionBase.GetArray(file);
            //Assert.True(arr.Count > 0);
            //List<int> result = Result.minimalHeaviestSetA(arr);
            //Assert.NotNull(result);
            //Assert.True(result.Count > 0);
            //Assert.Equal(2, result.Count);
        }

        [Fact]
        public void TetsCase2()
        {
            var files = SolutionBase.GetDataFiles();
            Assert.NotNull(files);
            Assert.True(files.Length > 0);
            var file = files.Where(x => x.Name.ToLower() == "data3.txt").First();
            Assert.NotNull(file);
            var arr = SolutionBase.GetArray(file);
            Assert.True(arr.Count > 0);

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var res = SolutionBase.GetHeaviestPackage(arr);
            stopwatch.Stop();
            Assert.True(res > 0);
            Assert.True(stopwatch.ElapsedMilliseconds < 3000);

            //Assert.NotNull(files);
            //Assert.True(files.Length > 0);
            //var file = files.Where(x => x.Name.ToLower() == "data1.txt").First();
            //Assert.NotNull(file);
            //var arr = SolutionBase.GetArray(file);
            //Assert.True(arr.Count > 0);
            //List<int> result = Result.minimalHeaviestSetA(arr);
            //Assert.NotNull(result);
            //Assert.True(result.Count > 0);
            //Assert.Equal(2, result.Count);
        }


        [Fact]
        public void TetsCase3()
        {
            var files = SolutionBase.GetDataFiles();
            Assert.NotNull(files);
            Assert.True(files.Length > 0);
            Stopwatch stopwatch = Stopwatch.StartNew();
            foreach (var file in files)
            {
                stopwatch.Reset();
                var arr = SolutionBase.GetArray(file);
                Assert.True(arr.Count > 0);
                stopwatch.Start();
                var res = SolutionBase.GetHeaviestPackage(arr);
                stopwatch.Stop();
                Assert.True(res > 0);
                Assert.True(stopwatch.ElapsedMilliseconds < 3000);
            }
        }

    }
}