using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class TypesJob
    {
        public int TypesJobId { get; set; }
        public string Name { get; set; }
        public int LicenseId { get; set; }
        public int ContractorId { get; set; }
        public decimal Price { get; set; }

        public Contractor ContractorIdNavigation { get; set; }
        public License LicenseIdNavigation { get; set; }
        public ICollection<ListWork> ListWork { get; set; }
    }
}
