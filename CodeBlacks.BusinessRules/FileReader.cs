using System;
using System.IO;

namespace CodeBlacks.BusinessRules
{
    public sealed class FileReader : IFileReader
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
