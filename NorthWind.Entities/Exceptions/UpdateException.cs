using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.Exceptions
{
    public class UpdateException : Exception
    {
        public IReadOnlyList<string> Entries { get; set; }
        public UpdateException() { }
        public UpdateException(string message) : base(message) { }
        public UpdateException(string message, Exception innerException)
            : base(message, innerException) { }
        public UpdateException(string title, IReadOnlyList<string> entries) : base(title)
        => Entries = entries;

    }
}
