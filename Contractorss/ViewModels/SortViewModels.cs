using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contractorss.ViewModels
{
    public enum SortBuild
    {
        nameASC,
        nameDSC,
        manufacASC,
        manufacDSC,
        voluemASC,
        voluemDSC,
        contracASC,
        contracDSC
    }
    public class SortViewModels
    {
        public SortBuild BuildNameSort { get; private set; }    // значение для сортировки по университету
        public SortBuild ManufacSort { get; set; }
        public SortBuild VolumSort { get; set; }
        public SortBuild ContractSort { get; set; }
        public SortBuild Current { get; private set; }// текущее значение сортировки

        public SortViewModels(SortBuild sortBuild)
        {
            BuildNameSort = sortBuild == SortBuild.nameASC ? SortBuild.nameDSC : SortBuild.nameASC;
            ManufacSort = sortBuild == SortBuild.manufacASC ? SortBuild.manufacDSC : SortBuild.manufacDSC;
            VolumSort = sortBuild == SortBuild.voluemASC ? SortBuild.voluemDSC : SortBuild.voluemASC;
            ContractSort = sortBuild == SortBuild.contracASC ? SortBuild.contracDSC : SortBuild.contracASC;
            Current = sortBuild;
        }
       



    }
}
