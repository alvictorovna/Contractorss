using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class TechnicalEquipment
    {
        public int TechnicalEquipmentId { get; set; }
        public string Denotation { get; set; }
        public string Appointment { get; set; }
        public DateTime DatePurchase { get; set; }
        public int LifetimeYear { get; set; }
        public int ContractorId { get; set; }

        public Contractor ContractorIdNavigation { get; set; }
    }
}
