using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class OrderDao
    {
        QLWebsiteTSEntities4 cf = null;
        public OrderDao()    //khởi tạo OrderDao khởi tạo luôn biến db
        {
            cf = new QLWebsiteTSEntities4();
        }
        public int Insert(DONDATHANG dondathang)
        {
            cf.DONDATHANG.Add(dondathang);
            cf.SaveChanges();
            return dondathang.SoDH;
        }
        public void InsertSLBan(int maTS , int soluong)
        {
            var monan = cf.TS.Find(maTS);
            monan.SoLuongBan += soluong;
            cf.SaveChanges();
        }
    }
}
