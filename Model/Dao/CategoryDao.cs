using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Model.EF;

namespace Model.Dao
{
     public class CategoryDao
    {
        QLWebsiteTSEntities4 cf = null;

        public CategoryDao()
        {
            cf = new QLWebsiteTSEntities4();
        }
        public List<TS> ListAll()
        {
            return cf.TS.ToList();
        }
        public IEnumerable<TS> ListCategoryAll(int page = 1, int pagesize = 10)
        {
            return cf.TS.OrderByDescending(x => x.MaTS).ToPagedList(page, pagesize);
        }
    }
}
