using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class Manufacturer
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }

        public ICollection<BuildingMaterial> BuildingMaterials { get; set; }
    }
}
