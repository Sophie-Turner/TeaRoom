using System;
using System.Collections.Generic;

namespace TeaCar.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Items = new HashSet<Items>();
        }

        public int CatId { get; set; }
        public string CatName { get; set; }
        public string CatInfo { get; set; }
        public string CatPicFile { get; set; }

        public virtual ICollection<Items> Items { get; set; }
    }
}
