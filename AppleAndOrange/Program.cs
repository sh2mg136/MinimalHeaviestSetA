// https://www.hackerrank.com/challenges/apple-and-orange/problem?isFullScreen=true

Console.WriteLine("Apple and Orange");
Console.WriteLine(Environment.NewLine);

AAO aao = new AAO(7, 10, 4, 12,
    new List<int>() { 2, 3, -4 },
    new List<int>() { 3, -2, -4 });

var apl = aao.RunApples();
Console.WriteLine(apl);

public class AAO
{
    public int HouseFrom { get; private set; }
    public int HouseTo { get; private set; }
    public int A { get; private set; }
    public int B { get; private set; }
    List<int> _apples { get; set; }
    List<int> _oranges { get; set; }

    public AAO(int start, int end, int a, int b, List<int> apples, List<int> oranges)
    {
        HouseFrom = start;
        HouseTo = end;
        A = a;
        B = b;
        _apples = apples;
        _oranges = oranges;
    }

    public int RunApples()
    {
        List<Fruit> fruitList = new List<Fruit>();
        foreach (var i in _apples)
        {
            fruitList.Add(new Apple(i, A, HouseFrom, HouseTo));
        }
        int count = 0;
        foreach (var fruit in fruitList)
        {
            count += fruit.Check ? 1 : 0;
        }
        return count;
    }

    public int RunOranges()
    {
        List<Fruit> fruitList = new List<Fruit>();

        foreach (var i in _oranges)
        {
            fruitList.Add(new Orange(i, B, HouseFrom, HouseTo));
        }
        int count = 0;

        foreach (var fruit in fruitList)
        {
            int pos = fruit.Pos;
        }

        foreach (var fruit in fruitList)
        {
            count += fruit.Check ? 1 : 0;
        }
        return count;
    }

    public int Run()
    {
        List<Fruit> fruitList = new List<Fruit>();

        foreach (var i in _apples)
        {
            fruitList.Add(new Apple(i, A, HouseFrom, HouseTo));
        }

        foreach (var i in _oranges)
        {
            fruitList.Add(new Orange(i, B, HouseFrom, HouseTo));
        }

        int count = 0;
        foreach (var fruit in fruitList)
        {
            count += fruit.Check ? 1 : 0;
        }

        return count;
    }
}

public abstract class Fruit
{
    public int Distance { get; private set; }
    public int Origin { get; private set; }
    public int Start { get; private set; }
    public int End { get; private set; }
    public Location Location { get; private set; }

    public Fruit(int distance, int origin, int start, int end, Location location)
    {
        Distance = distance;
        Origin = origin;
        Start = start;
        End = end;
        Location = location;
    }

    public int Pos => Origin + Distance;

    public virtual bool Check => Pos >= Start && Pos <= End;

}

public class Apple : Fruit
{
    public Apple(int distance, int baseDistance, int start, int end)
        : base(distance, baseDistance, start, end, Location.Left)
    {

    }
}

public class Orange : Fruit
{
    public Orange(int distance, int baseDistance, int start, int end)
        : base(distance, baseDistance, start, end, Location.Right)
    {

    }
}

public enum Location { Left, Right };