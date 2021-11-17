using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Entities.POCOs
{
    public class Log
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public Log(DateTime createdDate, string description)
        => (CreatedDate, Description) = (createdDate, description);

        public Log(string description)
        => (Description) = (description);

    }
}
