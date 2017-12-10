using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contractorss.ViewModels
{
    public class BuildingViewModel
    {
        public IEnumerable<BuildingMaterial> BuildingMaterials { get; set; }
        public IEnumerable<Contractor> Contractor { get; set; }
        //Свойство для навигации по страницам
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        //Свойство для сортировки
        public SortViewModels SortViewModel { get; set; }
    }
}
