using System;
using System.IO;

namespace BaseFileReader
{
    internal class CsvFileReader : BaseFileReader
    {
        public override string SupportedFormat => "CSV";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening CSV stream...");

            string[] lines = File.ReadAllLines(filePath);
            int rowCount = lines.Length;
            int columnCount = 0;

            if (rowCount > 0)
            {
                string[] firstLineCols = lines[0].Split(',');
                columnCount = firstLineCols.Length;
            }

            Console.WriteLine($" -> Detected {rowCount} rows and {columnCount} columns.");
            Console.WriteLine();

            string fullContent = File.ReadAllText(filePath);
            string preview = fullContent.Length > 100 ? fullContent.Substring(0, 100) + "..." : fullContent;

            Console.WriteLine("--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
        }
    }
}