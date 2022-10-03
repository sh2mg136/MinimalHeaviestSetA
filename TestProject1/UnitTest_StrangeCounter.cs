using System.Diagnostics;

namespace TestProject1
{
    public class UnitTest_StrangeCounter
    {
        [Fact]
        public void TetsCase1()
        {
            var res = StrangeCounterClass.strangeCounter(9);
            Assert.Equal(1, res);
        }

        [Fact]
        public void TetsCase2()
        {
            var res = StrangeCounterClass.strangeCounter(13);
            Assert.Equal(9, res);
        }

        [Fact]
        public void TetsCase3()
        {
            var res = StrangeCounterClass.strangeCounter(1);
            Assert.Equal(3, res);
            res = StrangeCounterClass.strangeCounter(2);
            Assert.Equal(2, res);
            res = StrangeCounterClass.strangeCounter(3);
            Assert.Equal(1, res);
            res = StrangeCounterClass.strangeCounter(4);
            Assert.Equal(6, res);
            res = StrangeCounterClass.strangeCounter(5);
            Assert.Equal(5, res);
            res = StrangeCounterClass.strangeCounter(6);
            Assert.Equal(4, res);
            res = StrangeCounterClass.strangeCounter(7);
            Assert.Equal(3, res);
            res = StrangeCounterClass.strangeCounter(8);
            Assert.Equal(2, res);
            res = StrangeCounterClass.strangeCounter(9);
            Assert.Equal(1, res);
        }

        [Fact]
        public void TetsCase4()
        {
            var res = StrangeCounterClass.strangeCounter(20);
            Assert.Equal(2, res);
            res = StrangeCounterClass.strangeCounter(15);
            Assert.Equal(7, res);
        }


        [Fact]
        public void TetsCase5()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var res = StrangeCounterClass.strangeCounter(1000000000);
            stopwatch.Stop();
            Assert.True(res > 0);
            // Assert.True(res == 44);
            Assert.True(stopwatch.ElapsedMilliseconds < 15000);
        }


    }
}