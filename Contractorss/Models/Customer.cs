using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string NameCeo { get; set; }
        public string SurnameCeo { get; set; }

        public ICollection<MainObject> MainObjects { get; set; }
    }
}
