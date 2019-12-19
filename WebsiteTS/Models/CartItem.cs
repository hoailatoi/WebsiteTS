using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace WebsiteTS.Models
{
    [Serializable]
    public class CartItem
    {
        public TS Monan { set; get; }
        public int SoLuong { set; get; }
    }
}