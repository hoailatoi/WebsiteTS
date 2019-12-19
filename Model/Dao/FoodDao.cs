using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using Model.ViewsModel;
using PagedList;

namespace Model.Dao
{
    public class FoodDao
    {
        QLWebsiteTSEntities4 cf = null;
        public FoodDao()
        {
            cf = new QLWebsiteTSEntities4();
        }
        public TS GetFood(int id)
        {
            return cf.TS.Find(id);
        }
        public List<TS> ListTraSua()
        {
            return cf.TS.OrderBy(x=>x.MaTS).ToList();
        }
        public List<TS> ListFood()
        {
            return cf.TS.Where(x => x.MaTS == 1).ToList();
        }
        public List<TS> ListTS()
        {
            return cf.TS.Where(x => x.MaTS == 2).ToList();
        }
        public List<TS> ListTea()
        {
            return cf.TS.Where(x => x.MaTS == 3).ToList();
        }
        public List<TS> ListBlended()
        {
            return cf.TS.Where(x => x.MaTS == 4).ToList();
        }
        public List<TS> RelatedFood(int id)
        {
            var food = cf.TS.Find(id);
            return cf.TS.Where(x => x.MaTS != id && x.MaTS == food.MaTS).ToList();
        }
        public List<TS> OurFood(int idCategory)
        {
            return cf.TS.Where(x => x.MaTS == idCategory).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return cf.TS.Where(x => x.TenTS.Contains(keyword)).Select(x => x.TenTS).ToList();
        }
        //public List<FoodViewModel> Search(string keyword)
        //{

        //    var model = (from a in cf.ThucUong  
        //                 join b in cf.FoodCategory
        //                 on a.IDCategory equals b.ID
        //                 where a.Name.Contains(keyword)
        //                 select new
        //                 {
        //                     ID = a.ID,
        //                     CateName = b.Name,
        //                     UrlTitle = a.UrlTitle,
        //                     Price = a.Price,
        //                     Detail = a.Detail,
        //                     Description = a.Description,
        //                     Name = a.Name,
        //                     Image = a.Image,

        //                 }).AsEnumerable().Select(x => new FoodViewModel()
        //                 {
        //                     ID = x.ID,
        //                     CateName = x.Name,
        //                     UrlTitle = x.UrlTitle,
        //                     Price = x.Price,
        //                     Detail = x.Detail,
        //                     Description = x.Description,
        //                     Name = x.Name,
        //                     Image = x.Image,
        //                 });
        //    //model.OrderByDescending(x => x.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return model.ToList();
        //}
        public bool Insert(TS thucuong)
        {
            try
            {
                cf.TS.Add(thucuong);
                cf.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Update(TS model)
        {
            try
            {
                var food = cf.TS.Find(model.MaTS);
                food.MaTS = model.MaTS;
                food.TenTS = model.TenTS;
                food.DonGia = model.DonGia;
                food.HinhMinhHoa= model.HinhMinhHoa;
                food.DonViTinh = model.DonViTinh;
                food.SoLuongBan = model.SoLuongBan;
                cf.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public bool Delete(int id)
        {
            try
            {
                var food = cf.TS.Find(id);
                cf.TS.Remove(food);
                cf.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<TS> ListFoodAll(int page = 1, int pagesize = 10)
        {

            return cf.TS.OrderByDescending(x => x.MaTS).ToPagedList(page, pagesize);
        }
    }
}
