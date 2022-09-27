// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> data = new List<int> { 1, 5, 2, 3, 4, 5 };

var max = GetMax(data);

var res = data.Where(x => x == max).Count();

Console.WriteLine($"{res}");

static int GetMax(List<int> arr)
{
    return arr.OrderByDescending(x => x).Max();
}