using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class License
    {
        public int LicenseId { get; set; }
        public DateTime DateIssue { get; set; }
        public int Number { get; set; }
        public int ValidityYear { get; set; }

        public ICollection<TypesJob> TypesJobs { get; set; }
    }
}
