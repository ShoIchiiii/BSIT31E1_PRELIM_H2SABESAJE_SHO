using ConsoleApp1;
using System;
using System.Collections.Generic;

namespace BaseFileReader
{
    internal class FileReaderResolver
    {
        private readonly List<IFileReader> _availableReaders;

        public FileReaderResolver()
        {
            _availableReaders = new List<IFileReader>
            {
                new TextFileReader(),
                new XmlFileReader(),
                new JsonFileReader(),
                new CsvFileReader()
            };
        }

        public IFileReader GetReaderForFormat(string format)
        {
            foreach (var reader in _availableReaders)
            {
                if (reader.SupportedFormat.Equals(format, StringComparison.OrdinalIgnoreCase))
                {
                    return reader;
                }
            }
            return null;
        }
    }
}