using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewsModel
{
    class FoodViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UrlTitle { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string CateName { get; set; }

        public string Image { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
    }
}
