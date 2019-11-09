using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class QLVB_database
    {
        QLVBDataContext qlvb = new QLVBDataContext();
        public QLVBDataContext getDataContext()
        {
            return qlvb;
        }
        public IQueryable<SALE_NHAN_VIEN> getNhanVien()
        {
            var nhanvien=from nv in qlvb.SALE_NHAN_VIENs where nv.ID_NHAN_VIEN>0 select nv;
            return nhanvien;
        }

        public bool insertNhanVien(SALE_NHAN_VIEN nhanvien)
        {
            try
            {
                qlvb.SALE_NHAN_VIENs.InsertOnSubmit(nhanvien);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool update()
        {
            try
            {
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNhanVien(SALE_NHAN_VIEN nhanvien)
        {
            try
            {
                qlvb.SALE_NHAN_VIENs.DeleteOnSubmit(nhanvien);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SALE_NHAN_VIEN searchNhanVien(int id)
        {
            return qlvb.SALE_NHAN_VIENs.Where(nv => nv.ID_NHAN_VIEN == id).FirstOrDefault();
        }
    }
}
