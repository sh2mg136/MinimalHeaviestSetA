using System.Diagnostics;

namespace TestProject1
{
    public class UnitTestClimbingTheLeaderboard
    {
        private Random Rnd = new Random();

        [Fact]
        public void TetsCase1()
        {
            var ranked = new List<int> { 100, 90, 90, 80 };
            var player = new List<int> { 70, 80, 105 };
            var correct = new List<int> { 4, 3, 1 };
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            Assert.Equal(res.Count, correct.Count);
            var cmn = res.Intersect(correct).ToList();
            Assert.Equal(cmn.Count(), correct.Count);
        }

        [Fact]
        public void TetsCase2()
        {
            var ranked = new List<int> { 100, 100, 50, 40, 40, 20, 10 };
            var player = new List<int> { 5, 25, 50, 120 };
            var correct = new List<int> { 6, 4, 2, 1 };
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            Assert.Equal(res.Count, correct.Count);
            var cmn = res.Intersect(correct).ToList();
            Assert.Equal(cmn.Count(), correct.Count);
        }

        [Fact]
        public void TetsCase3()
        {
            var ranked = new List<int> { 100, 90, 90, 80, 75, 60 };
            var player = new List<int> { 50, 66, 77, 90, 120 };
            var correct = new List<int> { 6, 5, 4, 2, 1 };
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            Assert.Equal(res.Count, correct.Count);
            var cmn = res.Intersect(correct).ToList();
            Assert.Equal(cmn.Count(), correct.Count);
        }

        [Fact]
        public void TetsCase4()
        {
            var ranked = new List<int> { 100, 90, 90, 80, 75, 60 };
            var player = new List<int> { 50, 66, 77, 90, 120 };
            var correct = new List<int> { 6, 5, 4, 2, 1 };

            ranked.Clear();
            player.Clear();
            int cnt = 90000000;
            int K = 1;

            while (cnt > 1000)
            {
                K = Rnd.Next(2, 10);
                var score = cnt - 10 * K;
                cnt = score;
                ranked.Add(score);
            }

            Console.WriteLine($"ranked count: {ranked.Count}");

            cnt = 500;
            while (cnt < 5000000)
            {
                player.Add(cnt);
                K = Rnd.Next(2, 40);
                cnt += K * 10;
            }

            Console.WriteLine($"player count: {player.Count}");
            Console.WriteLine("started...");
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            sw.Stop();
            Console.WriteLine("stoped");
            Console.WriteLine(sw.Elapsed.ToString("c"));
            Console.WriteLine($"result count: {res.Count}");
            Console.WriteLine(Environment.NewLine);
            Assert.True(res.Any());
            Assert.True(sw.ElapsedMilliseconds < 10000);
        }

        [Fact]
        public void TetsCase5()
        {
            var ranked = new List<int>();
            var player = new List<int>();
            var correct = new List<int>();

            int max = 50000000;
            int cnt = max;
            var step = 100;

            while (cnt > 10)
            {
                cnt -= step;
                if (cnt <= 0) break;
                ranked.Add(cnt);
            }

            Console.WriteLine($"ranked count: {ranked.Count}");

            cnt = 150;
            while (cnt <= max)
            {
                player.Add(cnt);
                cnt += 100;
            }

            player.Add(max + 1000);

            var steps = max / step - 1;

            for (int i = steps; i > 0; i--)
            {
                correct.Add(i);
            }

            correct.Add(1);

            Console.WriteLine($"player count: {player.Count}");
            Console.WriteLine("started...");
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            sw.Stop();
            Console.WriteLine("stoped");
            Console.WriteLine(sw.Elapsed.ToString("c"));
            Console.WriteLine($"result count: {res.Count}");
            Console.WriteLine(Environment.NewLine);
            Assert.True(res.Any());

            Assert.Equal(res.Count, correct.Count);

            bool isOk = true;
            for (int i = 0; i < correct.Count; i++)
            {
                if (correct[i] != res[i])
                {
                    Debug.WriteLine($"i = {i}. {correct[i]} != {res[i]}");
                    isOk = false;
                    break;
                }
            }
            Assert.True(isOk, "WRONG RESULT");
            Assert.True(sw.ElapsedMilliseconds < 10000, "TIMEOUT");
        }

        [Fact]
        public void TetsCase6()
        {
            var ranked = new List<int> { };
            var player = new List<int> { };
            int max = 100000000;
            int score = max;
            int K;

            while (score > 100)
            {
                K = Rnd.Next(1, 8);
                score -= 10 * K;
                ranked.Add(score);
            }

            player.Add(1);
            player.Add(2);
            player.Add(3);
            player.Add(4);
            player.Add(5);
            player.Add(5);
            player.Add(6);
            player.Add(6);
            player.Add(7);
            
            player.Add(2);          // +7
            player.Add(0);          // new worst    

            player.Add(max + 2);
            player.Add(max + 4);
            player.Add(max + 4);
            player.Add(max + 6);
            player.Add(max + 8);
            player.Add(max + 8);
            player.Add(max + 8);
            player.Add(max + 9);

            player.Add(max + 8);    // second best score
            player.Add(max + 7);

            var c = ranked.Count; //
            var correct = new List<int> { 
                c + 1, c + 1, c + 1, 
                c + 1, c + 1, c + 1,
                c + 1, c + 1, c + 1,

                c + 6, // score = 2 (second worst result)
                c + 8,

                1, 1, 1, 
                1, 1, 1, 
                1, 1, 2,
                3
            };

            Console.WriteLine($"ranked count: {ranked.Count}");
            Console.WriteLine($"player count: {player.Count}");
            Console.WriteLine("started...");
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            sw.Stop();
            Console.WriteLine("stoped");
            Console.WriteLine(sw.Elapsed.ToString("c"));
            Console.WriteLine($"result count: {res.Count}");
            Console.WriteLine(Environment.NewLine);
            Assert.True(res.Any());
            Assert.True(sw.ElapsedMilliseconds < 10000);
            Assert.Equal(res.Count, correct.Count);

            bool isOk = true;
            for (int i = 0; i < correct.Count; i++)
            {
                if (correct[i] != res[i])
                {
                    Debug.WriteLine($"i = {i}. {correct[i]} != {res[i]}");
                    isOk = false;
                    break;
                }
            }
            Assert.True(isOk, "WRONG RESULT");

        }

        [Fact]
        public void TetsCase7()
        {
            var ranked = new List<int> { 1 };
            var player = new List<int> { 1 };
            var correct = new List<int> { 1 };
            var res = Solver.ClimbingLeaderboardDone(ranked, player);
            Assert.Equal(res.Count, correct.Count);
            var cmn = res.Intersect(correct).ToList();
            Assert.Equal(cmn.Count(), correct.Count);
            bool isOk = true;
            for (int i = 0; i < correct.Count; i++)
            {
                if (correct[i] != res[i])
                {
                    Debug.WriteLine($"i = {i}. {correct[i]} != {res[i]}");
                    isOk = false;
                    break;
                }
            }
            Assert.True(isOk, "WRONG RESULT");
        }

    }
}