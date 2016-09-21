using System;
using System.Collections.Generic;
using System.IO;

namespace CodeBlacks.BusinessRules
{
    public sealed class DirectoryReader : IDirectoryReader
    {
        public IEnumerable<string> GetFiles(string directory, string searchPattern)
        {
            return Directory.GetFiles(directory, searchPattern);
        }
    }
}
