using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class AccountDao
    {
        QLWebsiteTSEntities4 cf = null;
        public AccountDao()
        {
            cf = new QLWebsiteTSEntities4();
        }
        public TAIKHOAN GetCus(string userName)
        {
            return cf.TAIKHOAN.FirstOrDefault(x => x.Username == userName);
        }
        public NHANVIEN Getnv(string userName)
        {
            return cf.NHANVIEN.FirstOrDefault(x => x.Username == userName);
        }
        public int InsertAccount(TAIKHOAN tk)
        {
            cf.TAIKHOAN.Add(tk);
            cf.SaveChanges();
            return tk.ID;

        }
        public bool UpdateAccount(TAIKHOAN tk)
        {
            try
            {
                var user = cf.TAIKHOAN.Find(tk.ID);
                user.Username = tk.Username;
                user.Dissplayname = tk.Dissplayname;
                user.Address = tk.Address;
                user.Phone = tk.Phone;
                user.TypeAccount = tk.TypeAccount;
                user.Ngaysinh = tk.Ngaysinh;
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

        public IEnumerable<TAIKHOAN> ListAccountAll(int page = 1, int pagesize = 10)
        {

            return cf.TAIKHOAN.OrderByDescending(x => x.ID).ToPagedList(page, pagesize);
        }
        public TAIKHOAN GetAccount(string username)
        {
            return cf.TAIKHOAN.SingleOrDefault(x => x.Username == username);
        }
        public TAIKHOAN ViewDetail(int id)
        {
            return cf.TAIKHOAN.Find(id);
        }
        public int Login(string name, string pass)
        {
            var kq = cf.TAIKHOAN.Count(x => x.Username == name);
            var nv = cf.NHANVIEN.Count(x => x.Username == name);

            if (kq > 0 || nv > 0)
            {
                if (kq > 0 && nv == 0)
                {
                    return 1;

                }
                else
                {
                    return 2;
                }
            }
            else return 0;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = cf.TAIKHOAN.Find(id);
                cf.TAIKHOAN.Remove(user);
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
            return cf.TAIKHOAN.Count(x => x.Username==name) > 0;
        }
        public bool Insert(TAIKHOAN customer)
        {
            try
            {
                cf.TAIKHOAN.Add(customer);
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
            var kq = cf.TAIKHOAN.SingleOrDefault(x => x.Username == name);
            if (kq == null)
                return 0;
            else
            {
                if (kq.Password == pass)
                    return 1;
                else
                    return -1;
            }
        }
        public TAIKHOAN GetCustomersByID(int id)
        {
            TAIKHOAN customer = cf.TAIKHOAN.Find(id);
            return customer;
        }
    }
}
