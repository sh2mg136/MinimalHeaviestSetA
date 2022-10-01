// DesignerPDFViewer
// https://www.hackerrank.com/challenges/designer-pdf-viewer/problem?isFullScreen=true
using System.Diagnostics;

Console.WriteLine("Designer PDF Viewer");

List<int> h = new List<int>() { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 1, 1, 5, 5, 1, 5, 2, 5, 5, 5, 5, 5, 5 };
Debug.Assert(h.Count == 26);
var res = DesignerPDFViewerSolver.designerPdfViewer(h, "torn");
Debug.Assert(res == 8);

// a-z = 97-122

public class DesignerPDFViewerSolver
{
    public static int designerPdfViewer(List<int> h, string word)
    {
        List<int> idx = new List<int>();
        foreach (var ch in word)
            idx.Add(h[ch - 97]);
        return word.Length * idx.Max();
    }
}