using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{
    public class JsonFileReader : BaseFileReader
    {
        public override string SupportedFormat => "JSON";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening JSON stream...");

            string fullContent = File.ReadAllText(filePath);
            int rootPropertyCount = 0;

            using (JsonDocument doc = JsonDocument.Parse(fullContent))
            {
                JsonElement root = doc.RootElement;
                if (root.ValueKind == JsonValueKind.Object)
                {
                    foreach (var _ in root.EnumerateObject())
                    {
                        rootPropertyCount++;
                    }
                }
                else if (root.ValueKind == JsonValueKind.Array)
                {
                    rootPropertyCount = root.GetArrayLength();
                }
            }

            Console.WriteLine($" -> Parsed {rootPropertyCount} root properties.");
            Console.WriteLine();

            string preview = fullContent.Length > 100 ? fullContent.Substring(0, 100) + "..." : fullContent;

            Console.WriteLine("--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
        }
    }
}