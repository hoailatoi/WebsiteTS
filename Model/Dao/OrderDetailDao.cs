using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        QLWebsiteTSEntities4 cf = null;
        public OrderDetailDao()    //khởi tạo OrderDetailDao khởi tạo luôn biến db
        {
            cf = new QLWebsiteTSEntities4();
        }
        public bool Insert(CTDATHANG chitiet)
        {
            try
            {
                cf.CTDATHANG.Add(chitiet);
                cf.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
