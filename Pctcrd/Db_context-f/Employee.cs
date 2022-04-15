using System;
using System.Collections.Generic;

#nullable disable

namespace Pctcrd.Db_context-f
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long? MbN0 { get; set; }
        public int? Salary { get; set; }
    }
}
