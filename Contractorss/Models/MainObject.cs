using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class MainObject
    {
        public int MainObjectId { get; set; }
        public string NameObject { get; set; }
        public int CustomerId { get; set; }
        public int ContractorId { get; set; }
        public DateTime ConclusionContract { get; set; }
        public DateTime DeliveryObject { get; set; }
        public DateTime DateInputObject { get; set; }

        public Contractor ContractorIdNavigation { get; set; }
        public Customer CustomerIdNavigation { get; set; }
        public ICollection<ListWork> ListWork { get; set; }
    }
}
