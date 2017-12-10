using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contractorss.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Contractor> contract, int? contr, string nameMaterial)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            contract.Insert(0, new Contractor { NameCompany = "Все", ContractorId = 0 });
            Contractors = new SelectList(contract, "ContractorId", "NameCompany", contr);
            SelectedContr = contr;
            SelectedName = nameMaterial;
        }
        public SelectList Contractors { get; private set; } // список компаний
        public int? SelectedContr { get; private set; }   // выбранная компания
        public string SelectedName { get; private set; }    // введенное имя
    }
}
