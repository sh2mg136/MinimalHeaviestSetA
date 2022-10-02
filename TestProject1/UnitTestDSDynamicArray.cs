using System.Diagnostics;

namespace TestProject1
{
    public class UnitTestDSDynamicArray
    {
        public UnitTestDSDynamicArray()
        {
        }

        [Fact]
        public void CheckDataDirectory()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "TestData", "DynamicArray");
            DirectoryInfo dir = new DirectoryInfo(path);
            Assert.True(dir.Exists);

            var filePath = Path.Combine(path, "test1.txt");
            FileInfo fileInfo = new FileInfo(filePath);
            Assert.True(fileInfo.Exists);

            var data = GetArray(fileInfo);
            Assert.NotEmpty(data);
            Assert.True(data.Count == 100000);
            var evenCount = data.Where(x => x[0] == 2).Count();
            Assert.True(evenCount > 0);

            var resultFilePath = Path.Combine(path, "result1.txt");
            FileInfo fileInfoRes = new FileInfo(resultFilePath);
            Assert.True(fileInfoRes.Exists);
            var correct = GetResult(fileInfoRes);
            Assert.NotEmpty(correct);

            int n = 100000;
            var result = DynamicArrayClass.Run(n, data);
            Debug.Assert(result.Count > 0);
            Debug.Assert(result.Count == correct.Count);
        }

        public List<List<int>> GetArray(FileInfo fileInfo)
        {
            var lines = File.ReadAllLines(fileInfo.FullName);
            List<List<int>> arr = new List<List<int>>();
            List<int> tmp = new List<int>();

            foreach (var line in lines)
            {
                tmp = new List<int>();
                var str = line.Split(" "); // , StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in str)
                {
                    int arrItem = Convert.ToInt32(s);
                    tmp.Add(arrItem);
                }
                arr.Add(new List<int>() { tmp[0], tmp[1], tmp[2] });
            }

            return arr;
        }

        public List<int> GetResult(FileInfo fileInfo)
        {
            var lines = File.ReadAllLines(fileInfo.FullName);
            List<int> tmp = new List<int>();

            foreach (var line in lines)
            {
                int arrItem = Convert.ToInt32(line.Trim());
                tmp.Add(arrItem);
            }
            return tmp;
        }

    }
}