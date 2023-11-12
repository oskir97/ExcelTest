using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibraryProjects.Exceptions.Abstractions
{
    public class ProblemDetails
    {
        public string? Type { get; set; } = null;

        public int? Status { get; set; } = null;

        public string? Title { get; set; } = null;

        public string? Detail { get; set; } = null;

        public IDictionary<string, object> Extensions { get; set; } = new Dictionary<string, object>();

        public string? TraceId { get; set; } = null;

    }
}
