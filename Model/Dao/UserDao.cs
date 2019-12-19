using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data.SqlClient;
namespace Model.Dao
{
    public class UserDao
    {
        QLWebsiteTSEntities4 cf = null;
        public UserDao()
        {
            cf = new QLWebsiteTSEntities4();
        }
        public QUANTRIVIEN GetCus(string userName)
        {
            return cf.QUANTRIVIEN.FirstOrDefault(x => x.TenDNQTV == userName);
        }
        public int InsertAccount(QUANTRIVIEN tk)
        {
            cf.QUANTRIVIEN.Add(tk);
            cf.SaveChanges();
            return tk.MaQuanTri;

        }
        public bool UpdateAccount(QUANTRIVIEN tk)
        {
            try
            {
                var user = cf.QUANTRIVIEN.Find(tk.MaQuanTri);
                user.TenDNQTV = tk.TenDNQTV;
                user.TenQuanTri = tk.TenQuanTri;
                user.DiaChiQTV = tk.DiaChiQTV;
                user.DienThoaiQTV = tk.DienThoaiQTV;
                user.QuyenQTV = tk.QuyenQTV;
                user.NgaySinhQTV = tk.NgaySinhQTV;
                cf.SaveChanges();
                return true;
            }
            catch (Exception)

            {
                return false;
            }
        }

        public object GetAccount(object userName)
        {
            throw new NotImplementedException();
        }

        public object Login(object userName, object p)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<QUANTRIVIEN> ListAccountAll(int page = 1, int pagesize = 10)
        {

            return cf.QUANTRIVIEN.OrderByDescending(x => x.MaQuanTri).ToPagedList(page, pagesize);
        }
        public QUANTRIVIEN GetAccount(string username)
        {
            return cf.QUANTRIVIEN.SingleOrDefault(x => x.TenDNQTV == username);
        }
        public QUANTRIVIEN ViewDetail(int id)
        {
            return cf.QUANTRIVIEN.Find(id);
        }
        public int Login(string name, string pass)
        {
            var kq = cf.QUANTRIVIEN.Count(x => x.TenDNQTV == name && x.MatKhauDNQTV == pass);
            if (kq > 0)
            {
                return 1;
            }
            else return 0;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = cf.QUANTRIVIEN.Find(id);
                cf.QUANTRIVIEN.Remove(user);
                cf.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CheckUserName(string name)
        {
            return cf.QUANTRIVIEN.Count(x => x.TenDNQTV == name) > 0;
        }
        public bool Insert(QUANTRIVIEN customer)
        {
            try
            {
                cf.QUANTRIVIEN.Add(customer);
                cf.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int LoginCus(string name, string pass)
        {
            var kq = cf.QUANTRIVIEN.SingleOrDefault(x => x.TenDNQTV == name);
            if (kq == null)
                return 0;
            else
            {
                if (kq.MatKhauDNQTV == pass)
                    return 1;
                else
                    return -1;
            }
        }
        public QUANTRIVIEN GetCustomersByID(int id)
        {
            QUANTRIVIEN customer = cf.QUANTRIVIEN.Find(id);
            return customer;
        }
    }
}
