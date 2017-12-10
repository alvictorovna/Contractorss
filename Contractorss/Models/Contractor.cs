using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class Contractor
    {
        public int ContractorId { get; set; }
        public string NameCompany { get; set; }

        public ICollection<BuildingMaterial> BuildingMaterials { get; set; }
        public ICollection<MainObject> MainObjects { get; set; }
        public ICollection<TechnicalEquipment> TechnicalEquipments { get; set; }
        public ICollection<TypesJob> TypesJobs { get; set; }
    }

    public enum SortState{
        NameAs,
        NameDesc
    }
}
