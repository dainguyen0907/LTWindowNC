﻿using System;
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

        // Nhân viên==================================================================
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

        // Thông tin công ty====================================================
        public IQueryable<THONG_TIN_CONG_TY> getNThongTinChung(int id_congty)
        {
            var thongtin = from tt in qlvb.THONG_TIN_CONG_Ties where tt.ID_CONG_TY==id_congty select tt;
            return thongtin;
        }

        public THONG_TIN_CONG_TY searchCongTy(int id)
        {
            return qlvb.THONG_TIN_CONG_Ties.Where(ct => ct.ID_CONG_TY == id).FirstOrDefault();
        }

        //Loại văn bản ==============================================================
        public IQueryable<LOAI_VAN_BAN> getLoaiVanBan()
        {
            var thongtin = from lvb in qlvb.LOAI_VAN_BANs  select lvb;
            return thongtin;
        }
        public bool deleteLoaiVanBan(LOAI_VAN_BAN loaivanban)
        {
            try
            {
                qlvb.LOAI_VAN_BANs.DeleteOnSubmit(loaivanban);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public LOAI_VAN_BAN searchLoaiVanBan(int id)
        {
            return qlvb.LOAI_VAN_BANs.Where(lvb => lvb.ID_LOAI_VAN_BAN == id).FirstOrDefault();
        }

        public bool insertLoaiVanBan(LOAI_VAN_BAN loaivanban)
        {
            try
            {
                qlvb.LOAI_VAN_BANs.InsertOnSubmit(loaivanban);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Nơi ban hành====================================================================================
        public IQueryable<NOI_BAN_HANH> getNoiBanHanh()
        {
            var thongtin = from nbh in qlvb.NOI_BAN_HANHs select nbh;
            return thongtin;
        }
        public bool deleteNoiBanHanh(NOI_BAN_HANH noibanhanh)
        {
            try
            {
                qlvb.NOI_BAN_HANHs.DeleteOnSubmit(noibanhanh);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public NOI_BAN_HANH searchNoiBanHanh(int id)
        {
            return qlvb.NOI_BAN_HANHs.Where(nbh => nbh.ID_NOI_BAN_HANH == id).FirstOrDefault();
        }

        public bool insertNoiBanHanh(NOI_BAN_HANH noibanhanh)
        {
            try
            {
                qlvb.NOI_BAN_HANHs.InsertOnSubmit(noibanhanh);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Phòng ban ============================================================================
        public IQueryable<PHONG_BAN> getPhongBan()
        {
            var thongtin = from ph in qlvb.PHONG_BANs select ph;
            return thongtin;
        }
        public bool deletePhongBan(PHONG_BAN phongban)
        {
            try
            {
                qlvb.PHONG_BANs.DeleteOnSubmit(phongban);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public PHONG_BAN searchPhongBan(int id)
        {
            return qlvb.PHONG_BANs.Where(ph => ph.ID_PHONG_BAN == id).FirstOrDefault();
        }

        public bool insertPhongBan(PHONG_BAN phongban)
        {
            try
            {
                qlvb.PHONG_BANs.InsertOnSubmit(phongban);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //=Sổ văn bản=============================================================================================
        public IQueryable<SO_VAN_BAN> getSoVanBan()
        {
            var thongtin = from svb in qlvb.SO_VAN_BANs select svb;
            return thongtin;
        }
        public IQueryable<SO_VAN_BAN> getSoVanBan(bool vbden)
        {

            var thongtin = from svb in qlvb.SO_VAN_BANs where svb.LOAI_SO_DI_DEN==(vbden==true?true:false) select svb;
            return thongtin;
        }
        public IQueryable<SO_VAN_BAN> getSoVanBan(int nam)
        {
            var thongtin = from svb in qlvb.SO_VAN_BANs where svb.NAM==nam select svb;
            return thongtin;
        }
        public bool deleteSoVanBan(SO_VAN_BAN sovanban)
        {
            try
            {
                qlvb.SO_VAN_BANs.DeleteOnSubmit(sovanban);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SO_VAN_BAN searchSoVanBan(int id)
        {
            return qlvb.SO_VAN_BANs.Where(svb => svb.ID_SO_VAN_BAN == id).FirstOrDefault();
        }

        public bool insertSoVanBan(SO_VAN_BAN sovanban)
        {
            try
            {
                qlvb.SO_VAN_BANs.InsertOnSubmit(sovanban);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Danh sách văn bản đến====================================================
        public IQueryable<VanBanDenObject> getDSVanBanDen(DateTime date_from, DateTime date_to)
        {
            return (from vbd in qlvb.VAN_BAN_DENs
                    join lvb in qlvb.LOAI_VAN_BANs on vbd.ID_LOAI_VAN_BAN equals lvb.ID_LOAI_VAN_BAN
                    join nbh in qlvb.NOI_BAN_HANHs on vbd.ID_DON_VI_DEN equals nbh.ID_NOI_BAN_HANH
                    join svb in qlvb.SO_VAN_BANs on vbd.ID_SO_VAN_BAN equals svb.ID_SO_VAN_BAN
                    where vbd.NGAY_DEN >= date_from && vbd.NGAY_DEN <= date_to
                    select new VanBanDenObject { id=vbd.ID_VAN_BAN_DEN,
                                                 sovanban=svb.TEN_SO_VAN_BAN,
                                                 loaivanban=lvb.TEN_LOAI_VAN_BAN,
                                                 sokyhieu=vbd.SO_KY_HIEU,
                                                 soden=int.Parse(vbd.SO_DEN.ToString()),
                                                 ngaybanhanh=DateTime.Parse(vbd.NGAY_BAN_HANH.ToString()),
                                                 ngayden = DateTime.Parse(vbd.NGAY_DEN.ToString()),
                                                 donvigui=nbh.NOI_BAN_HANH1,
                                                 trichyeu=vbd.TRICH_YEU});

        }
        public bool deleteVanBanDen(VAN_BAN_DEN vanbanden)
        {
            try
            {
                qlvb.VAN_BAN_DENs.DeleteOnSubmit(vanbanden);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public VAN_BAN_DEN searchVanBanDen(int id)
        {
            return qlvb.VAN_BAN_DENs.Where(vbd => vbd.ID_VAN_BAN_DEN == id).FirstOrDefault();
        }

        public bool insertVanBanDen(VAN_BAN_DEN vanbanden)
        {
            try
            {
                qlvb.VAN_BAN_DENs.InsertOnSubmit(vanbanden);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getIDMaxVanBanDen()
        {
            if (qlvb.VAN_BAN_DENs.Count() == 0)
                return 0;
            var id = (from vbd in qlvb.VAN_BAN_DENs orderby vbd.ID_VAN_BAN_DEN descending select vbd.ID_VAN_BAN_DEN).First();
            return int.Parse(id.ToString());
        }

        public string[] getThietLapThongTin()
        {
            if (qlvb.THIET_LAP_THONG_TINs.Count() == 0)
                return null;
            else
            {
                THIET_LAP_THONG_TIN tt = qlvb.THIET_LAP_THONG_TINs.Select(t => t).First();
                string nguoi_ky = tt.NGUOI_KY_VAN_BAN.ToString();
                string nguoi_duyet = tt.NGUOI_DUYET_VAN_BAN.ToString();
                string nguoi_nhan = tt.NGUOI_NHAN_VAN_BAN.ToString();
                string nguoi_gui = tt.NGUOI_GUI_VAN_BAN.ToString();
                string[] c = { nguoi_ky, nguoi_gui, nguoi_duyet, nguoi_nhan };
                return c;

            }

        }
        public THIET_LAP_THONG_TIN getTLTT()
        {
            return qlvb.THIET_LAP_THONG_TINs.Select(t => t).FirstOrDefault();
        }
        //File Văn Bản đến
        public IQueryable<FILE_NAME> getfileVBDen(int id)
        {
            return qlvb.FILE_NAMEs.Where(t => t.ID_VAN_BAN_DEN == id);
        }
        public bool InsertFileVanBanDen(FILE_NAME file)
        {
            try
            {
                qlvb.FILE_NAMEs.InsertOnSubmit(file);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteFileVanBanDen(FILE_NAME file)
        {
            try
            {
                qlvb.FILE_NAMEs.DeleteOnSubmit(file);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public int getMaxIDFile()
        {
            if (qlvb.FILE_NAMEs.Count() == 0)
                return 0;
            var id = (from f in qlvb.FILE_NAMEs orderby f.ID_FILE descending select f.ID_FILE).First();
            return int.Parse(id.ToString());
        }
        public FILE_NAME searchFile(int id)
        {
            return qlvb.FILE_NAMEs.Where(t => t.ID_FILE == id).FirstOrDefault();
        }
        // Danh sách văn bản đi=============================================================
        public IQueryable<VanBanDiObject> getDSVanBanDi(DateTime date_from, DateTime date_to)
        {
            return (from vbd in qlvb.VAN_BAN_DIs
                    join lvb in qlvb.LOAI_VAN_BANs on vbd.ID_LOAI_VAN_BAN equals lvb.ID_LOAI_VAN_BAN
                    join svb in qlvb.SO_VAN_BANs on vbd.ID_SO_VAN_BAN equals svb.ID_SO_VAN_BAN
                    where vbd.NGAY_BAN_HANH >= date_from && vbd.NGAY_BAN_HANH <= date_to
                    select new VanBanDiObject
                    {
                        id = vbd.ID_VAN_BAN,
                        sovanban = svb.TEN_SO_VAN_BAN,
                        loaivanban = lvb.TEN_LOAI_VAN_BAN,
                        sokyhieu = vbd.SO_KY_HIEU,
                        sodi = int.Parse(vbd.SO_DI.ToString()),
                        ngaybanhanh = DateTime.Parse(vbd.NGAY_BAN_HANH.ToString()),
                        noinhan = vbd.NOI_NHAN,
                        trichyeu = vbd.TRICH_YEU
                    });

        }
        public bool deleteVanBanDi(VAN_BAN_DI VanBanDi)
        {
            try
            {
                qlvb.VAN_BAN_DIs.DeleteOnSubmit(VanBanDi);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        

        public VAN_BAN_DI searchVanBanDi(int id)
        {
            return qlvb.VAN_BAN_DIs.Where(vbd => vbd.ID_VAN_BAN == id).FirstOrDefault();
        }

        public bool insertVanBanDi(VAN_BAN_DI VanBanDi)
        {
            try
            {
                qlvb.VAN_BAN_DIs.InsertOnSubmit(VanBanDi);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getIDMaxVanBanDi()
        {
            if (qlvb.VAN_BAN_DIs.Count() == 0)
                return 0;
            var id = (from vbd in qlvb.VAN_BAN_DIs orderby vbd.ID_VAN_BAN descending select vbd.ID_VAN_BAN).First();
            return int.Parse(id.ToString());
        }
        //File Văn Bản đi
        public IQueryable<FILE_NAME> getfileVBDi(int id)
        {
            return qlvb.FILE_NAMEs.Where(t => t.ID_VAN_BAN_DI == id);
        }
        public bool InsertFileVanBanDi(FILE_NAME file)
        {
            try
            {
                qlvb.FILE_NAMEs.InsertOnSubmit(file);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteFileVanBanDi(FILE_NAME file)
        {
            try
            {
                qlvb.FILE_NAMEs.DeleteOnSubmit(file);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Văn bản nội bộ===============================================================================
        public IQueryable<VanBanNoiBoObject> getDSVanBanNoiBo(DateTime date_from, DateTime date_to)
        {
            return (from vbnb in qlvb.VAN_BAN_NOI_BOs
                    join lvb in qlvb.LOAI_VAN_BANs on vbnb.ID_LOAI_VAN_BAN equals lvb.ID_LOAI_VAN_BAN
                    join ph in qlvb.PHONG_BANs on vbnb.ID_PHONG_BAN_BAN_HANH equals ph.ID_PHONG_BAN
                    join phn in qlvb.PHONG_BANs on vbnb.ID_PHONG_BAN_NHAN equals phn.ID_PHONG_BAN
                    where vbnb.NGAY_BAN_HANH >= date_from && vbnb.NGAY_BAN_HANH <= date_to
                    select new VanBanNoiBoObject
                    {
                        id = vbnb.ID_VAN_BAN_NOI_BO,
                        tenvanban=vbnb.TEN_VAN_BAN,
                        loaivanban = lvb.TEN_LOAI_VAN_BAN,
                        sokyhieu = vbnb.SO_KY_HIEU,
                        ngaybanhanh = DateTime.Parse(vbnb.NGAY_BAN_HANH.ToString()),
                        phongbanhanh=ph.TEN_PHONG_BAN,
                        phongbannhan=phn.TEN_PHONG_BAN,
                        trichyeu = vbnb.TRICH_YEU
                    });

        }
        public bool deleteVanBanNoiBo(VAN_BAN_NOI_BO VanBanNoiBo)
        {
            try
            {
                qlvb.VAN_BAN_NOI_BOs.DeleteOnSubmit(VanBanNoiBo);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public VAN_BAN_NOI_BO searchVanBanNoiBo(int id)
        {
            return qlvb.VAN_BAN_NOI_BOs.Where(vbnb => vbnb.ID_VAN_BAN_NOI_BO == id).FirstOrDefault();
        }

        public bool insertVanBanNoiBo(VAN_BAN_NOI_BO VanBanNoiBo)
        {
            try
            {
                qlvb.VAN_BAN_NOI_BOs.InsertOnSubmit(VanBanNoiBo);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int getIDMaxVanBanNoiBo()
        {
            if (qlvb.VAN_BAN_NOI_BOs.Count() == 0)
                return 0;
            var id = (from vbd in qlvb.VAN_BAN_NOI_BOs orderby vbd.ID_VAN_BAN_NOI_BO descending select vbd.ID_VAN_BAN_NOI_BO).First();
            return int.Parse(id.ToString());
        }
        //File Văn Bản nội bộ
        public IQueryable<FILE_NAME> getfileVBNoiBo(int id)
        {
            return qlvb.FILE_NAMEs.Where(t => t.ID_VAN_BAN_NOI_BO == id);
        }
        public bool InsertFileVanBanNoiBo(FILE_NAME file)
        {
            try
            {
                qlvb.FILE_NAMEs.InsertOnSubmit(file);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteFileVanBanNoiBo(FILE_NAME file)
        {
            try
            {
                qlvb.FILE_NAMEs.DeleteOnSubmit(file);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Phân quyền=============================================================
        public IQueryable<PhanQuyenObject> getPhanQuyen()
        {
            var a = from mn in qlvb.MENUFORMs
                    join gb in qlvb.GROUPMENUFUNCs on mn.MENUFORMID equals (gb.MENUFORMID) into ot
                    from otnew in ot.DefaultIfEmpty()
                    select new PhanQuyenObject
                    {
                        id_quyen = mn.MENUFORMID,
                        tenquyen = mn.MENUFORMNAME,
                        truycap =otnew ==null?false:otnew.ACCESS
                    };
            return a;
        }

        public IQueryable<PhanQuyenObject> getPhanQuyen(int id_user)
        {
            var a = from gb in qlvb.GROUPMENUFUNCs
                    join mn in qlvb.MENUFORMs on gb.MENUFORMID equals (mn.MENUFORMID)
                    where gb.ID_NHAN_VIEN==id_user
                    select new PhanQuyenObject
                    {
                        id_quyen = mn.MENUFORMID,
                        tenquyen = mn.MENUFORMNAME,
                        truycap = gb.ACCESS
                    };
            return a;
        }
        public bool checkExsistPQ(int id_user)
        {
            var a = qlvb.GROUPMENUFUNCs.Select(t=>t).FirstOrDefault();
            if (a != null)
                return true;
            return false;
        }
        public bool insertQuyen(GROUPMENUFUNC q)
        {
            try
            {
                qlvb.GROUPMENUFUNCs.InsertOnSubmit(q);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteQuyen(GROUPMENUFUNC q)
        {
            try
            {
                qlvb.GROUPMENUFUNCs.DeleteOnSubmit(q);
                qlvb.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public GROUPMENUFUNC searchQuyen(int id_nv, int id_menu)
        {
            return qlvb.GROUPMENUFUNCs.Where(t => t.ID_NHAN_VIEN == id_nv && t.MENUFORMID == id_menu).FirstOrDefault();
        }
        public List<string> getquyen(int id_nv)
        {
            List<string> result=new List<string>();
            var a = (from menu in qlvb.MENUFORMs
                    join gr in qlvb.GROUPMENUFUNCs on menu.MENUFORMID equals (gr.MENUFORMID)
                    where gr.ID_NHAN_VIEN == id_nv && gr.ACCESS==true
                    select menu.MENUFORTAG).ToList();
            foreach (var c in a)
            {
                result.Add(c);
            }
            return result;
        }


    }
}
