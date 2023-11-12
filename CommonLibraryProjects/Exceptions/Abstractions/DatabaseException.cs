using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Exceptions.Abstractions
{
    public class DatabaseException : Exception
    {
        public IReadOnlyList<string>? Entries { get; set; } = null;

        public DatabaseException()
        {
        }

        public DatabaseException(string message)
            : base(message)
        {
        }

        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DatabaseException(string message, List<string> entries)
            : base(message)
        {
            Entries = entries;
        }
    }
}
