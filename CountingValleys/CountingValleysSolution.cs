namespace CountingValleys
{
    /// <summary>
    ///
    /// </summary>
    internal class CountingValleysSolution
    {
        public static int countingValleys(int steps, string path)
        {
            var result = 0;
            int cnt = 0;
            int dir = 0;

            foreach (var ch in path)
            {
                switch (ch)
                {
                    case 'U':
                        cnt++;
                        if (cnt == 0)
                        {
                            if (dir < 0) result++;
                            dir = 0;
                        }
                        else if (cnt > 1)
                        {
                            dir = 1;
                        }
                        break;

                    case 'D':
                        cnt--;
                        if (cnt == 0)
                        {
                            dir = 0;
                        }
                        else if (cnt < 0)
                        {
                            dir = -1;
                        }
                        break;

                    default:
                        break;
                }
            }

            return result;
        }
    }
}