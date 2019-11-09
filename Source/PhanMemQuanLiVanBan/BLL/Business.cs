using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
     public class Business
    {
        QLVB_database da = new QLVB_database();
        public IQueryable<SALE_NHAN_VIEN> getNhanVien()
        {
            return da.getNhanVien();
        }

        public bool themNhanVien(int id, String MaNhanVien, String TenNhanVien, String MatKhau, int idCongTy)
        {
            SALE_NHAN_VIEN nhanvien = new SALE_NHAN_VIEN();
            nhanvien.ID_NHAN_VIEN = id;
            nhanvien.MA_NHAN_VIEN = MaNhanVien;
            nhanvien.HO_TEN = TenNhanVien;
            nhanvien.MAT_KHAU = MatKhau;
            nhanvien.ID_CONG_TY = idCongTy;
            return da.insertNhanVien(nhanvien);
        }

        public bool suaNhanVien(int id, String MaNhanVien, String TenNhanVien, String MatKhau, bool NghiViec)
        {
            SALE_NHAN_VIEN nhanvien = da.searchNhanVien(id);
            if (nhanvien != null)
            {
                nhanvien.MA_NHAN_VIEN = MaNhanVien;
                nhanvien.HO_TEN = TenNhanVien;
                nhanvien.MAT_KHAU = MatKhau;
                nhanvien.NGHI_VIEC = NghiViec;
                return da.update();
            }
            else
                return false;
        }

        public bool xoaNhanVien(int id)
        {
            SALE_NHAN_VIEN nhanvien = da.searchNhanVien(id);
            if (nhanvien != null)
            {
                return da.deleteNhanVien(nhanvien);
            }
            else
                return false;
        }

        public bool timNhanVien(int id)
        {
            SALE_NHAN_VIEN nhanvien = da.searchNhanVien(id);
            if (nhanvien != null)
            {
                return true;
            }
            else
                return false;
        }
        public bool suaThongTin(int id, String MaNhanVien, String TenNhanVien, String MatKhau, bool NghiViec)
        {
            SALE_NHAN_VIEN nhanvien = da.searchNhanVien(id);
            if (nhanvien != null)
            {
                nhanvien.MA_NHAN_VIEN = MaNhanVien;
                nhanvien.HO_TEN = TenNhanVien;
                nhanvien.MAT_KHAU = MatKhau;
                nhanvien.NGHI_VIEC = NghiViec;
                return da.update();
            }
            else
                return false;
        }
    }
}
