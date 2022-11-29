using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace LINQFluent
{
    public class Program
    {
       private const string FileName = "test.txt";

       private const string TxtUrl1 = "http://textfiles.com/stories/roger1.txt";

       private void Main()
       {
        string[] lines;

        int numLinesGt30;
        double avgCharsInLines;
        bool anyWithMoreThan120Chars;
        IEnumerable<string> firstWordOfLineWithCharA;

        if (!File.Exists(FileName))
        {
            using HttpClient client = new HttpClient();
            string fileText = client.GetStringAsync(TxtUrl1).Result;
            File.WriteAllText(FileName, FileText);
        }

        lines = File.ReadAllLines(FileName);

        numLinesGt30 = lines.Count(s => s.Length > 30);
        Console.WriteLine($"Linhas > 30     : {numLinesGt30}");

        avgCharsInLines = lines.Average(s => s.Lenght);
        Console.WriteLine($"Média nº chars  : {avgCharsInLines:l}");

        avgWithMoreThan120Chars = lines.Any(s => s.Length > 120);
        Console.WriteLine($"Algum com + 120?  : {anyWithMoreThan120Chars}");

        firstWordOfLineWithCharA = lines
            .Where(s => s.Contains("A"))
            .Select(s => s.Trim().Split()[0].ToUpper());
        
        Console.WriteLine("Primeira palavra em maiúsculas de linhas com 'A'");
        foreach (string s in firstWordOfLineWithCharA)
        {
            Console.WriteLine($" => {s}");
        }
       }
    }
}
