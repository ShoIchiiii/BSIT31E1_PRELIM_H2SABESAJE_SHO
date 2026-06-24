using System;
using System.IO;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class XmlFileReader : BaseFileReader
    {
        public override string SupportedFormat => "XML";

        protected override void ParseContent(string filePath)
        {
            Console.WriteLine(" -> Opening XML stream...");

            XDocument doc = XDocument.Load(filePath);
            string rootName = doc.Root?.Name.LocalName ?? "Unknown";

            int descendantCount = 0;
            foreach (var _ in doc.Descendants())
            {
                descendantCount++;
            }

            Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");
            Console.WriteLine();

            string fullContent = doc.ToString();
            string preview = fullContent.Length > 100 ? fullContent.Substring(0, 100) + "..." : fullContent;

            Console.WriteLine("--- First 100 Characters ---");
            Console.WriteLine(preview);
            Console.WriteLine("----------------------------");
        }
    }
}