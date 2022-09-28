// https://www.hackerrank.com/challenges/the-time-in-words/problem?isFullScreen=true

Console.WriteLine("The Time in Words");

public class TimeToWordConverter
{
    private static readonly string[] _hours = new string[] {
        "midnight", "one", "two", "three",
        "four", "five", "six", "seven",
        "eight", "nine", "ten", "eleven",
        "noon", "one", "two", "three",
        "four", "five", "six", "seven",
        "eight", "nine", "ten", "eleven"
     };

    private static readonly string[] _minutes = new string[]
    {
        "five", "ten", "a quarter", "twenty", "twenty five", "half"
    };

    public static string Run(int hour, int minute)
    {
        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
        var res = TimeToWords(dt);
        return res;
    }

    static string TimeToWords(DateTime time)
    {
        string res;
        int HH = time.Hour;
        int MM = time.Minute;
        int ost = time.Minute % 5;
        bool toHour = false;

        if (ost < 3)
            MM -= ost;
        else
            MM += 5 - ost;

        if (MM > 30)
        {
            HH = (HH + 1) % 24;
            MM = 60 - MM;
            toHour = true;
        }

        if (MM != 0)
            res = _minutes[MM / 6] + " " + (toHour ? "to" : "past") + " " + _hours[HH];
        else
            res = _hours[HH] + ((HH != 0 && HH != 12) ? " o'clock" : string.Empty);

        if (HH > 0 && HH < 12)
            return res + " am";

        if (HH > 12)
            res = res + " pm";

        return res;
    }


    public static string Convert(int h, int m)
    {
        string[] nums =  {
            "zero",
            "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
            "twenty",
            "twenty one", "twenty two", "twenty three", "twenty four", "twenty five",
            "twenty six", "twenty seven", "twenty eight", "twenty nine",
        };

        if (m == 0)
        {
            if (h % 12 == 0 || h == 0)
                return $"{nums[12]} o' clock";

            return $"{nums[h]} o' clock";
        }

        else if (m == 1)
            return $"one minute past {nums[h]}";

        else if (m == 59)
            return $"one minute to {nums[(h % 12) + 1]}";

        else if (m == 15)
            return $"quarter past {nums[h]}";

        else if (m == 30)
            return $"half past {nums[h]}";

        else if (m == 45)
            return $"quarter to {nums[(h % 12) + 1]}";

        else if (m <= 30)
            return $"{nums[m]} minutes past {nums[h]}";

        else if (m > 30)
            return $"{nums[60 - m]} minutes to {nums[(h % 12) + 1]}";

        return
            string.Empty;
    }

}