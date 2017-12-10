using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class BuildingMaterial
    {
        public int BuildingMaterialId { get; set; }
        public string NameMaterial { get; set; }
        public int ManufacturerId { get; set; }
        public int VolumePurchaseQuantity { get; set; }
        public int ContractorId { get; set; }

        public Contractor ContractorIdNavigation { get; set; }
        public Manufacturer ManufacturerIdNavigation { get; set; }
    }


}

