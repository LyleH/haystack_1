using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.BusinessRules
{
    public interface IDirectoryReader
    {
        IEnumerable<string> GetFiles(string directory, string searchPattern);
    }
}
