// https://www.hackerrank.com/challenges/arrays-ds/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("DataSructures Arrays-DS");

List<int> list = new List<int>() { 1, 4, 3, 2 };
var res = DataSructures_ArraysDS_Solver.reverseArray(list);
Debug.Assert(res != null);

List<List<int>> arr = new List<List<int>>()
{
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,1,0,0,0,0 },
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,0,0,0,0,0 },
    new List<int>(){ 0,0,0,0,0,0 },
    new List<int>(){ 0,0,0,0,0,0 },
};

var ires = DS2DArray.hourglassSum(arr);
Debug.Assert(ires == 7);


arr = new List<List<int>>()
{
    new List<int>(){ -9, -9, -9,  1, 1, 1 },
    new List<int>(){  0, -9,  0,  4, 3, 2 },
    new List<int>(){ -9, -9, -9,  1, 2, 3 },
    new List<int>(){  0,  0,  8,  6, 6, 0 },
    new List<int>(){  0,  0,  0, -2, 0, 0 },
    new List<int>(){  0,  0,  1,  2, 4, 0 },
};

ires = DS2DArray.hourglassSum(arr);
Debug.Assert(ires == 28);


arr = new List<List<int>>()
{
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,1,0,0,0,0 },
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,0,2,4,4,0 },
    new List<int>(){ 0,0,0,2,0,0 },
    new List<int>(){ 0,0,1,2,4,0 },
};

ires = DS2DArray.hourglassSum(arr);
Debug.Assert(ires == 19);


arr = new List<List<int>>()
{
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,1,0,0,0,0 },
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,0,2,4,6,5 },
    new List<int>(){ 0,0,0,2,3,8 },
    new List<int>(){ 0,0,1,9,7,15 },
};

ires = DS2DArray.hourglassSum(arr);
Debug.Assert(ires == 49);


arr = new List<List<int>>()
{
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,1,0,0,0,0 },
    new List<int>(){ 1,1,1,0,0,0 },
    new List<int>(){ 0,0,2,4,6,5 },
    new List<int>(){ 0,0,0,2,3,8 },
    new List<int>(){ 0,0,1,9,7,-1 },
};

ires = DS2DArray.hourglassSum(arr);
Debug.Assert(ires == 33);


arr = new List<List<int>>()
{
    new List<int>(){ -1, -1,  0, -9, -2, -2},
    new List<int>(){ -2, -1, -6, -8, -2, -5},
    new List<int>(){ -1, -1, -1, -2, -3, -4},
    new List<int>(){ -1, -9, -2, -4, -4, -5},
    new List<int>(){ -7, -3, -3, -2, -9, -9},
    new List<int>(){ -1, -3, -1, -2, -4, -5},
};

ires = DS2DArray.hourglassSum(arr);
Debug.Assert(ires == -6);


/// <summary>
///
/// </summary>
internal class DataSructures_ArraysDS_Solver
{
    public static List<int> reverseArray(List<int> a)
    {
        List<int> result = new List<int>();

        for (int i = a.Count - 1; i >= 0; i--)
        {
            result.Add(a[i]);
        }

        return result;
    }
}

/// <summary>
///
/// </summary>
internal class DS2DArray
{
    public static int hourglassSum(List<List<int>> arr)
    {
        var sum = 0;
        var max = int.MinValue;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                if (sum > max) max = sum;
            }
        }

        return max;
    }
}