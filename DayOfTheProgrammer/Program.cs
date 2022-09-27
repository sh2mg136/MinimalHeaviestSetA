// https://www.hackerrank.com/challenges/day-of-the-programmer/problem?isFullScreen=true

/*
Marie invented a Time Machine and wants to test it by time-traveling to visit Russia on the Day of the Programmer 
(the 256th day of the year) during a year in the inclusive range from 1700 to 2700.

From 1700 to 1917, Russia's official calendar was the Julian calendar; 
since 1919 they used the Gregorian calendar system. 
The transition from the Julian to Gregorian calendar system occurred in 1918, when the next day after January 31st was February 14th. 
This means that in 1918, February 14th was the 32nd day of the year in Russia.

In both calendar systems, February is the only month with a variable amount of days; it has 29 days during a leap year, 
and 28 days during all other years. 
In the Julian calendar, leap years are divisible by 4; in the Gregorian calendar, leap years are either of the following:
Divisible by 400.
Divisible by 4 and not divisible by 100.
Given a year, , find the date of the 256th day of that year according to the official Russian calendar during that year. 
Then print it in the format dd.mm.yyyy, where dd is the two-digit day, mm is the two-digit month, and yyyy is .  
*/

Console.WriteLine("Day of the Programmer");

public class Calc
{
    public int Year { get; private set; }

    public Calc(int year)
    {
        Year = year;
    }

    public bool IsJulian => Year < 1918;
    public bool IsGrigorian => Year >= 1918;

    public bool IsLeap
    {
        get
        {
            if (IsJulian)
                return Year % 4 == 0;
            else
                return Year % 400 == 0 && Year % 100 != 0;
        }
    }

    public string GetDate()
    {
        if (Year==1918)
        {
            // This means that in 1918, February 14th was the 32nd day of the year in Russia.
            // So there were 15 days in JAN 1918
            var febDays = 15;
            var sepDay = 256 - 215 - febDays;
            DateTime dt = new DateTime(Year, 9, sepDay);
            var res = dt.ToString("dd.MM.yyyy");
            return res;
            // return "26.09.1918";
        }
        else if (IsGrigorian)
        {
            var febDays = DateTime.DaysInMonth(Year, 2);
            var sepDay = 256 - 215 - febDays;
            DateTime dt = new DateTime(Year, 9, sepDay);
            var res = dt.ToString("dd.MM.yyyy");
            return res;
        }
        else
        {
            var febDays = IsLeap ? 29 : 28;
            var sepDay = 256 - 215 - febDays;
            DateTime dt = new DateTime(Year, 9, sepDay);
            var res = dt.ToString("dd.MM.yyyy");
            return res;
        }
    }
}