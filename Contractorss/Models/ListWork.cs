using System;
using System.Collections.Generic;

namespace Contractorss
{
    public partial class ListWork
    {
        public int ListWorkId { get; set; }
        public int TypesJobId { get; set; }
        public int? MainObjectId { get; set; }

        public MainObject MainObjectIdNavigation { get; set; }
        public TypesJob TypesJobIdNavigation { get; set; }
    }
}
