// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Text;

Console.WriteLine("Caesar's Cipher");
Console.WriteLine(Environment.NewLine);

CaesarCipher cipher = new CaesarCipher("abcdefghijklmnopqrstuvwxyz", 3);
var res = cipher.Execute();
Console.WriteLine(cipher.Input);
Console.WriteLine(res);
Console.WriteLine(Environment.NewLine);

cipher = new CaesarCipher("There's-a-stratman-wainting-in-the-sky", 3);
res = cipher.Execute();
Console.WriteLine(cipher.Input);
Console.WriteLine(res);
Console.WriteLine(Environment.NewLine);

cipher = new CaesarCipher("middle-Outz", 2);
res = cipher.Execute();
Console.WriteLine(cipher.Input);
Console.WriteLine(res);
Console.WriteLine(Environment.NewLine);

var reafVal = Console.ReadKey();

/// <summary>
/// 
/// </summary>
class CaesarCipher
{
    public string Input { get; private set; }
    uint K = 3;

    const string alfaStr = "abcdefghijklmnopqrstuvwxyz";
    char[] alfaChr = alfaStr.ToCharArray();
    readonly uint LEN = 0;

    public CaesarCipher(string input, uint shift)
    {
        Input = input;
        K = shift;
        LEN = (uint)alfaChr.Length;
    }

    uint GetCharNum(char ch)
    {
        var ch2 = ch.ToString().ToLower();
        if (!alfaStr.Contains(ch2))
            return 404;
        return (uint)alfaStr.IndexOf(ch2);
    }

    char Capitalize(char ch)
    {
        if (ch >= 97 && ch <= 122)
            return (char)((int)ch - 32);
        return ch;
    }

    char GetNewChar(char ch)
    {
        uint i = GetCharNum(ch);
        if (i > 100) return ch;
        bool isCapitalized = !char.IsLower(ch);
        uint new_k = i + K;
        if (new_k >= LEN)
        {
            new_k = new_k % LEN;
        }
        return isCapitalized ? Capitalize(alfaChr[new_k]) : alfaChr[new_k];
    }

    public string Execute()
    {
        if (string.IsNullOrWhiteSpace(Input))
            return string.Empty;

        StringBuilder sb = new StringBuilder();
        foreach (var ch in Input)
        {
            sb.Append(GetNewChar(ch));
        }
        return sb.ToString();
    }
}