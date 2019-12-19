using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using System.Data;
using System.Data.SqlClient;


namespace Model.Dao
{
    public class NVDao
    {
        QLWebsiteTSEntities4 cf = null;
        public NVDao()
        {
            cf = new QLWebsiteTSEntities4();
        }
        public NHANVIEN GetCus(string userName)
        {
            return cf.NHANVIEN.FirstOrDefault(x => x.Username == userName);
        }
        public NHANVIEN Getnv(string userName)
        {
            return cf.NHANVIEN.FirstOrDefault(x => x.Username == userName);
        }
        public int InsertAccount(NHANVIEN tk)
        {
            cf.NHANVIEN.Add(tk);
            cf.SaveChanges();
            return tk.MaNV;

        }
        public bool UpdateAccount(NHANVIEN tk)
        {
            try
            {
                var user = cf.NHANVIEN.Find(tk.MaNV);
                user.Username = tk.Username;
                user.TenNhanVien = tk.TenNhanVien;
                user.DiaChiNV = tk.DiaChiNV;
                user.DienThoaiNV = tk.DienThoaiNV;
                user.Password = tk.Password;
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

        public IEnumerable<NHANVIEN> ListAccountAll(int page = 1, int pagesize = 10)
        {

            return cf.NHANVIEN.OrderByDescending(x => x.MaNV).ToPagedList(page, pagesize);
        }
        public NHANVIEN GetAccount(string username)
        {
            return cf.NHANVIEN.SingleOrDefault(x => x.Username == username);
        }
        public NHANVIEN ViewDetail(int id)
        {
            return cf.NHANVIEN.Find(id);
        }
        //public int Login(string name, string pass)
        //{
        //    var kq = cf.TAIKHOAN.Count(x => x.Username == name);
        //    var nv = cf.NHANVIEN.Count(x => x.Username == name);

        //    if (kq > 0 || nv > 0)
        //    {
        //        if (kq > 0 && nv == 0)
        //        {
        //            return 1;

        //        }
        //        else
        //        {
        //            return 2;
        //        }
        //    }
        //    else return 0;
        //}
        public bool Delete(int id)
        {
            try
            {
                var user = cf.NHANVIEN.Find(id);
                cf.NHANVIEN.Remove(user);
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
            return cf.NHANVIEN.Count(x => x.Username == name) > 0;
        }
        public bool Insert(NHANVIEN customer)
        {
            try
            {
                cf.NHANVIEN.Add(customer);
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
            var kq = cf.NHANVIEN.SingleOrDefault(x => x.Username == name);
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
        public NHANVIEN GetCustomersByID(int id)
        {
            NHANVIEN customer = cf.NHANVIEN.Find(id);
            return customer;
        }
    }
}

