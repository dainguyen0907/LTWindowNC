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
        public List<SALE_NHAN_VIEN> getNhanVien()
        {
            return da.getNhanVien().ToList();
        }
         //Nhân viên===================-==========================================
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
        public bool DoiMatKhau(int id, string matkhau)
        {
            SALE_NHAN_VIEN nhanvien = da.searchNhanVien(id);
            if (nhanvien != null)
            {
                nhanvien.MAT_KHAU = matkhau;
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
        public bool timNhanVien(string taikhoan)
        {
            SALE_NHAN_VIEN nhanvien = da.searchTaiKhoan(taikhoan);
            if (nhanvien != null)
            {
                return true;
            }
            else
                return false;
        }
         //Công ty======================================================
        public List<THONG_TIN_CONG_TY> getThongTinChung(int id)
        {
            return da.getNThongTinChung(id).ToList();
        }

        public bool suaThongTin(int id, String[] thongtin)
        {
            THONG_TIN_CONG_TY congty = da.searchCongTy(id);
            if (congty != null)
            {
                congty.TEN_CONG_TY = thongtin[0];
                congty.DIA_CHI = thongtin[1];
                congty.DIEN_THOAI = thongtin[2];
                congty.FAX = thongtin[3];
                congty.WEBSITE = thongtin[4];
                congty.EMAIL = thongtin[5];
                congty.MA_SO_THUE = thongtin[6];
                congty.LINH_VUC = thongtin[7];
                congty.MO_TA = thongtin[8];
                return da.update();
            }
            else
                return false;
        }
         // Loại văn bản==================================================================
        public List<LOAI_VAN_BAN> getLoaiVanBan()
        {
            return da.getLoaiVanBan().ToList();
        }

        public bool xoaLoaiVanBan(int id)
        {
            LOAI_VAN_BAN loaivanban = da.searchLoaiVanBan(id);
            if (loaivanban != null)
            {
                return da.deleteLoaiVanBan(loaivanban);
            }
            else
                return false;
        }
        public bool timLoaiVanBan(int id)
        {
            LOAI_VAN_BAN loaivanban = da.searchLoaiVanBan(id);
            if (loaivanban != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool themLoaiVanBan(int id, String MaLoai, String TenLoai, String MoTa)
        {
            LOAI_VAN_BAN loaivanban = new LOAI_VAN_BAN();
            loaivanban.ID_LOAI_VAN_BAN = id;
            loaivanban.TEN_LOAI_VAN_BAN = TenLoai;
            loaivanban.MA_LOAI_VAN_BAN = MaLoai;
            loaivanban.MO_TA = MoTa;
            return da.insertLoaiVanBan(loaivanban);
        }

        public bool suaLoaiVanBan(int id, String MaLoai, String tenLoai, String MoTa)
        {
            LOAI_VAN_BAN loaivanban = da.searchLoaiVanBan(id);
            if (loaivanban != null)
            {
                loaivanban.MA_LOAI_VAN_BAN = MaLoai;
                loaivanban.TEN_LOAI_VAN_BAN = tenLoai;
                loaivanban.MO_TA = MoTa;
                return da.update();
            }
            else
                return false;
        }
         // Nơi ban hành====================================================
        public List<NOI_BAN_HANH> getNoiBanHanh()
        {
            return da.getNoiBanHanh().ToList();
        }

        public bool xoaNoiBanHanh(int id)
        {
            NOI_BAN_HANH noibanhanh = da.searchNoiBanHanh(id);
            if (noibanhanh!= null)
            {
                return da.deleteNoiBanHanh(noibanhanh);
            }
            else
                return false;
        }
        public bool timNoiBanHanh(int id)
        {
            NOI_BAN_HANH noibanhanh = da.searchNoiBanHanh(id);
            if (noibanhanh != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool themNoiBanHanh(int id, String TenNBH, String MoTa)
        {
            NOI_BAN_HANH noibanhanh = new NOI_BAN_HANH();
            noibanhanh.ID_NOI_BAN_HANH = id;
            noibanhanh.NOI_BAN_HANH1 = TenNBH;
            noibanhanh.MO_TA = MoTa;
            return da.insertNoiBanHanh(noibanhanh);
        }

        public bool suaNoiBanHanh(int id, String TenNBH,  String MoTa)
        {
            NOI_BAN_HANH noibanhanh = da.searchNoiBanHanh(id);
            if (noibanhanh != null)
            {
                noibanhanh.NOI_BAN_HANH1 = TenNBH;
                noibanhanh.MO_TA = MoTa;
                return da.update();
            }
            else
                return false;
        }

         //Phòng ban =====================================================
        public List<PHONG_BAN> getPhongBan()
        {
            return da.getPhongBan().ToList();
        }

        public bool xoaPhongBan(int id)
        {
            PHONG_BAN PhongBan = da.searchPhongBan(id);
            if (PhongBan != null)
            {
                return da.deletePhongBan(PhongBan);
            }
            else
                return false;
        }
        public bool timPhongBan(int id)
        {
            PHONG_BAN PhongBan = da.searchPhongBan(id);
            if (PhongBan != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool themPhongBan(int id, String TenPB)
        {
            PHONG_BAN PhongBan = new PHONG_BAN();
            PhongBan.ID_PHONG_BAN = id;
            PhongBan.TEN_PHONG_BAN = TenPB;
            return da.insertPhongBan(PhongBan);
        }

        public bool suaPhongBan(int id, String TenPB)
        {
            PHONG_BAN PhongBan = da.searchPhongBan(id);
            if (PhongBan != null)
            {
                PhongBan.TEN_PHONG_BAN = TenPB;
                return da.update();
            }
            else
                return false;
        }
         // Sổ văn bản=====================================================================================
        public List<SO_VAN_BAN> getsovanban()
        {
            return da.getSoVanBan().ToList();
        }
        public List<SO_VAN_BAN> getsovanban(bool vbden)
        {
            return da.getSoVanBan(vbden).ToList();
        }
        public List<SO_VAN_BAN> getsovanban(int nam)
        {
            return da.getSoVanBan(nam).ToList();
        }
        public bool xoasovanban(int id)
        {
            SO_VAN_BAN sovanban = da.searchSoVanBan(id);
            if (sovanban != null)
            {
                return da.deleteSoVanBan(sovanban);
            }
            else
                return false;
        }
        public bool timsovanban(int id)
        {
            SO_VAN_BAN sovanban = da.searchSoVanBan(id);
            if (sovanban != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool themsovanban(int id, String TenSVB,bool loai,int nam)
        {
            SO_VAN_BAN sovanban = new SO_VAN_BAN();
            sovanban.ID_SO_VAN_BAN = id;
            sovanban.TEN_SO_VAN_BAN = TenSVB;
            sovanban.NAM = nam;
            sovanban.LOAI_SO_DI_DEN = loai;
            return da.insertSoVanBan(sovanban);
        }

        public bool suasovanban(int id, String TenSVB,bool loai,int nam)
        {
            SO_VAN_BAN sovanban = da.searchSoVanBan(id);
            if (sovanban != null)
            {
                sovanban.TEN_SO_VAN_BAN = TenSVB;
                sovanban.LOAI_SO_DI_DEN = loai;
                sovanban.NAM = nam;
                return da.update();
            }
            else
                return false;
        }
         // Văn bản đến======================================================================
        public List<VanBanDenObject> getvanbanden(DateTime date_from, DateTime date_to)
        {
            return da.getDSVanBanDen(date_from,date_to).ToList();
        }
        public bool xoavanbanden(int id)
        {
            VAN_BAN_DEN vanbanden = da.searchVanBanDen(id);
            if (vanbanden != null)
            {
                return da.deleteVanBanDen(vanbanden);
            }
            else
                return false;
        }
        public bool timvanbanden(int id)
        {
            VAN_BAN_DEN vanbanden = da.searchVanBanDen(id);
            if (vanbanden != null)
            {
                return true;
            }
            else
                return false;
        }
        public VAN_BAN_DEN timthongtinvanbanden(int id)
        {
            VAN_BAN_DEN vanbanden = da.searchVanBanDen(id);
            if (vanbanden != null)
            {
                return vanbanden;
            }
            else
                return null;
        }
        public int getMaxIDVanBanDen()
        {
            return da.getIDMaxVanBanDen();
        }
        public bool ThemVanBanDen(int[] id, String[] thongtin, DateTime[]ngaythang)
        {
            VAN_BAN_DEN vbd = new VAN_BAN_DEN();
            vbd.ID_VAN_BAN_DEN = id[0];
            vbd.ID_SO_VAN_BAN = id[1];
            vbd.ID_LOAI_VAN_BAN = id[2];
            vbd.ID_DON_VI_DEN = id[3];
            vbd.SO_KY_HIEU=thongtin[0];
            vbd.SO_DEN = int.Parse(thongtin[1]);
            vbd.NGAY_BAN_HANH = ngaythang[0];
            vbd.NGAY_DEN = ngaythang[1];
            vbd.TRICH_YEU = thongtin[2];
            vbd.GHI_CHU = thongtin[3];
            vbd.NGUOI_NHAN_VAN_BAN = thongtin[4];
            vbd.NGUOI_KY_VAN_BAN = thongtin[5];
            vbd.NGUOI_DUYET_VAN_BAN = thongtin[6];
            vbd.SO_TRANG = thongtin[7];
            return da.insertVanBanDen(vbd);

        }
        public bool SuaVanBanDen(int _id, int[] id, String[] thongtin, DateTime[] ngaythang)
        {
            VAN_BAN_DEN vbd = da.searchVanBanDen(_id);
            if (vbd != null)
            {
                vbd.ID_SO_VAN_BAN = id[0];
                vbd.ID_LOAI_VAN_BAN = id[1];
                vbd.ID_DON_VI_DEN = id[2];
                vbd.SO_KY_HIEU = thongtin[0];
                vbd.SO_DEN = int.Parse(thongtin[1]);
                vbd.NGAY_BAN_HANH = ngaythang[0];
                vbd.NGAY_DEN = ngaythang[1];
                vbd.TRICH_YEU = thongtin[2];
                vbd.GHI_CHU = thongtin[3];
                vbd.NGUOI_NHAN_VAN_BAN = thongtin[4];
                vbd.NGUOI_KY_VAN_BAN = thongtin[5];
                vbd.NGUOI_DUYET_VAN_BAN = thongtin[6];
                vbd.SO_TRANG = thongtin[7];
                return da.update();
            }
            return false;
        }
        public string[] getThietLapThongTin()
        {
            return da.getThietLapThongTin();
        }
         //File Van Ban Den
        public List<FILE_NAME> getFileVBDen(int id)
        {
            return da.getfileVBDen(id).ToList();
        }
         
        public bool ThemFileVBDen(int idvbd,string path)
        {
            FILE_NAME file = new FILE_NAME();
            file.ID_FILE = da.getMaxIDFile() + 1;
            file.TEN_TAI_LIEU = path;
            string[] s = path.Split('\\');
            file.TEN_FILE = s[s.Length - 1];
            file.MO_RONG_FILE = path.Substring(path.Length-3);
            file.ID_VAN_BAN_DEN = idvbd;
            return da.InsertFileVanBanDen(file);
        }
        public bool XoaFileVBDen(int id)
        {
            FILE_NAME f=da.searchFile(id);
            return da.DeleteFileVanBanDen(f);
        }
         // Danh sách văn bản đi======================================
        public List<VanBanDiObject> getVanBanDi(DateTime date_from, DateTime date_to)
        {
            return da.getDSVanBanDi(date_from, date_to).ToList();
        }
        public bool xoaVanBanDi(int id)
        {
            VAN_BAN_DI VanBanDi = da.searchVanBanDi(id);
            if (VanBanDi != null)
            {
                return da.deleteVanBanDi(VanBanDi);
            }
            else
                return false;
        }
        public bool timVanBanDi(int id)
        {
            VAN_BAN_DI VanBanDi = da.searchVanBanDi(id);
            if (VanBanDi != null)
            {
                return true;
            }
            else
                return false;
        }
        public VAN_BAN_DI timthongtinVanBanDi(int id)
        {
            VAN_BAN_DI VanBanDi = da.searchVanBanDi(id);
            if (VanBanDi != null)
            {
                return VanBanDi;
            }
            else
                return null;
        }
        public int getMaxIDVanBanDi()
        {
            return da.getIDMaxVanBanDi();
        }
        public bool SuaVanBanDi(int _id, int[] id, String[] thongtin, DateTime ngaybanhanh)
        {
            VAN_BAN_DI vbd = da.searchVanBanDi(_id);
            if (vbd != null)
            {
                vbd.ID_SO_VAN_BAN = id[0];
                vbd.ID_LOAI_VAN_BAN = id[1];
                vbd.SO_KY_HIEU = thongtin[0];
                vbd.SO_DI = int.Parse(thongtin[1]);
                vbd.NGAY_BAN_HANH = ngaybanhanh;
                vbd.TRICH_YEU = thongtin[2];
                vbd.GHI_CHU = thongtin[3];
                vbd.NGUOI_GUI_VAN_BAN = thongtin[4];
                vbd.NGUOI_KY_VAN_BAN = thongtin[5];
                vbd.NGUOI_DUYET_VAN_BAN = thongtin[6];
                vbd.SO_TRANG = thongtin[7];
                vbd.SO_LUONG_BAN = int.Parse(thongtin[8]);
                vbd.NOI_NHAN = thongtin[9];
                return da.update();
            }
            return false;
        }
        public bool ThemVanBanDi(int[] id, String[] thongtin, DateTime ngaybanhanh)
        {
            VAN_BAN_DI vbd = new VAN_BAN_DI();
            vbd.ID_VAN_BAN = id[0];
            vbd.ID_SO_VAN_BAN = id[1];
            vbd.ID_LOAI_VAN_BAN = id[2];
            vbd.SO_KY_HIEU = thongtin[0];
            vbd.SO_DI = int.Parse(thongtin[1]);
            vbd.NGAY_BAN_HANH = ngaybanhanh;
            vbd.TRICH_YEU = thongtin[2];
            vbd.GHI_CHU = thongtin[3];
            vbd.NGUOI_GUI_VAN_BAN = thongtin[4];
            vbd.NGUOI_KY_VAN_BAN = thongtin[5];
            vbd.NGUOI_DUYET_VAN_BAN = thongtin[6];
            vbd.SO_TRANG = thongtin[7];
            vbd.SO_LUONG_BAN = int.Parse(thongtin[8]);
            vbd.NOI_NHAN = thongtin[9];
            return da.insertVanBanDi(vbd);

        }
        //File Van Ban Di
        public List<FILE_NAME> getFileVBDi(int id)
        {
            return da.getfileVBDi(id).ToList();
        }
        public bool ThemFileVBDi(int idvbd, string path)
        {
            FILE_NAME file = new FILE_NAME();
            file.ID_FILE = da.getMaxIDFile() + 1;
            file.TEN_TAI_LIEU = path;
            string[] s = path.Split('\\');
            file.TEN_FILE = s[s.Length - 1];
            file.MO_RONG_FILE = path.Substring(path.Length - 3);
            file.ID_VAN_BAN_DI = idvbd;
            return da.InsertFileVanBanDi(file);
        }
        public bool XoaFileVBDi(int id)
        {
            FILE_NAME f = da.searchFile(id);
            return da.DeleteFileVanBanDi(f);
        }
        // Danh sách văn bản nội bộ======================================
        public List<VanBanNoiBoObject> getVanBanNoiBo(DateTime date_from, DateTime date_to)
        {
            return da.getDSVanBanNoiBo(date_from, date_to).ToList();
        }
        public bool xoaVanBanNoiBo(int id)
        {
            VAN_BAN_NOI_BO VanBanNoiBo = da.searchVanBanNoiBo(id);
            if (VanBanNoiBo != null)
            {
                return da.deleteVanBanNoiBo(VanBanNoiBo);
            }
            else
                return false;
        }
        public bool timVanBanNoiBo(int id)
        {
            VAN_BAN_NOI_BO VanBanNoiBo = da.searchVanBanNoiBo(id);
            if (VanBanNoiBo != null)
            {
                return true;
            }
            else
                return false;
        }
        public int getMaxIDVanBanNoiBo()
        {
            return da.getIDMaxVanBanNoiBo();
        }
        public bool SuaVanBanNoiBo(int _id, int[] id, String[] thongtin, DateTime ngaybanhanh)
        {
            VAN_BAN_NOI_BO vbd = da.searchVanBanNoiBo(_id);
            if (vbd != null)
            {
                vbd.ID_LOAI_VAN_BAN = id[0];
                vbd.ID_PHONG_BAN_BAN_HANH = id[1];
                vbd.ID_PHONG_BAN_NHAN = id[2];
                vbd.SO_KY_HIEU = thongtin[0];
                vbd.TEN_VAN_BAN = thongtin[1];
                vbd.NGAY_BAN_HANH = ngaybanhanh;
                vbd.TRICH_YEU = thongtin[2];
                vbd.GHI_CHU = thongtin[3];
                vbd.NGUOI_NHAN_VAN_BAN = thongtin[4];
                vbd.NGUOI_KY_VAN_BAN = thongtin[5];
                vbd.NGUOI_DUYET_VAN_BAN = thongtin[6];
                vbd.NGAY_BAN_HANH = ngaybanhanh;
                return da.update();
            }
            return false;
        }
        public bool ThemVanBanNoiBo(int[] id, String[] thongtin, DateTime ngaybanhanh)
        {
            VAN_BAN_NOI_BO vbd = new VAN_BAN_NOI_BO();
            vbd.ID_VAN_BAN_NOI_BO = id[0];
            vbd.ID_LOAI_VAN_BAN = id[1];
            vbd.ID_PHONG_BAN_BAN_HANH = id[2];
            vbd.ID_PHONG_BAN_NHAN = id[3];
            vbd.SO_KY_HIEU = thongtin[0];
            vbd.TEN_VAN_BAN = thongtin[1];
            vbd.NGAY_BAN_HANH = ngaybanhanh;
            vbd.TRICH_YEU = thongtin[2];
            vbd.GHI_CHU = thongtin[3];
            vbd.NGUOI_NHAN_VAN_BAN = thongtin[4];
            vbd.NGUOI_KY_VAN_BAN = thongtin[5];
            vbd.NGUOI_DUYET_VAN_BAN = thongtin[6];
            return da.insertVanBanNoiBo(vbd);

        }

        public VAN_BAN_NOI_BO timthongtinVanBanNoiBo(int id)
        {
            VAN_BAN_NOI_BO VanBanNoiBo = da.searchVanBanNoiBo(id);
            if (VanBanNoiBo != null)
            {
                return VanBanNoiBo;
            }
            else
                return null;
        }

        //File Van Ban Noi bo
        public List<FILE_NAME> getFileVBNoiBo(int id)
        {
            return da.getfileVBNoiBo(id).ToList();
        }
        public bool ThemFileVBNoiBo(int idvbd, string path)
        {
            FILE_NAME file = new FILE_NAME();
            file.ID_FILE = da.getMaxIDFile() + 1;
            file.TEN_TAI_LIEU = path;
            string[] s = path.Split('\\');
            file.TEN_FILE = s[s.Length - 1];
            file.MO_RONG_FILE = path.Substring(path.Length - 3);
            file.ID_VAN_BAN_NOI_BO = idvbd;
            return da.InsertFileVanBanNoiBo(file);
        }
        public bool XoaFileVBNoiBo(int id)
        {
            FILE_NAME f = da.searchFile(id);
            return da.DeleteFileVanBanNoiBo(f);
        }

         //Phân quyền==================================
        public List<PhanQuyenObject> getPhanQuyen(int id_user)
        {
            if (da.checkExsistPQ(id_user))
            {
                return da.getPhanQuyen(id_user).ToList();
            }
            return da.getPhanQuyen().ToList();
            
        }
             public bool ThemQuyen(int id_nv, int id_menu, bool access)
        {
            GROUPMENUFUNC mn = new GROUPMENUFUNC();
            mn.ID_NHAN_VIEN = id_nv;
            mn.MENUFORMID = id_menu;
            mn.ACCESS = access;
            return da.insertQuyen(mn);
        }
        public bool updateQuyen(int id_nv, int id_menu, bool access)
        {
            GROUPMENUFUNC mn = da.searchQuyen(id_nv, id_menu);
            mn.ACCESS = access;
            return da.update();
        }
        public bool XoaQuyen(int id_nv, int id_menu)
        {
            GROUPMENUFUNC mn = da.searchQuyen(id_nv, id_menu);
            return da.deleteQuyen(mn);
        }
        public bool checkexsistQuyen(int id_nv)
        {
            return da.checkExsistPQ(id_nv);
        }
        public List<string> getquyen(int id_nv)
        {
            return da.getquyen(id_nv);
        }
         //THIET LAP THONG TIN============================================
        public bool UpdateThongTin(string ngky, string nggui, string ngduyet, string ngnhan)
        {
            THIET_LAP_THONG_TIN tt = da.getTLTT();
            if (tt != null)
            {
                tt.NGUOI_DUYET_VAN_BAN = ngduyet;
                tt.NGUOI_GUI_VAN_BAN = nggui;
                tt.NGUOI_KY_VAN_BAN = ngky;
                tt.NGUOI_NHAN_VAN_BAN = ngnhan;
                return da.update();
            }
            return false;
        }
         //THỐNG KÊ VĂN BẢN ĐI=====================================================
        public List<VanBanDiObject> getThongKeVBDi(DateTime date_from, DateTime date_to, int[] id, string[] thongtin)
        {
            List<VanBanDiObject> result = da.getThongKeVBDi(date_from, date_to,id, thongtin).ToList();
            
            return result;
        }
         //THỐNG KÊ VĂN BẢN ĐẾN=============================================
        public List<VanBanDenObject> getThongKeVBDen(DateTime date_from, DateTime date_to, int[] id, string[] thongtin)
        {
            List<VanBanDenObject> result = da.getThongKeVBDen(date_from, date_to, id, thongtin).ToList();
            return result;
        }
         //THỐNG KÊ VĂN BẢN NỘI BỘ===========================================
        public List<VanBanNoiBoObject> getThongKeVBNB(DateTime date_from, DateTime date_to, int[] id, string[] thongtin)
        {
            List<VanBanNoiBoObject> result = da.getThongKeVBNB(date_from, date_to, id, thongtin).ToList();
            return result;
        }
    }
}
