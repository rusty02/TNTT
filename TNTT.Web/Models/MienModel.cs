using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNTT.Model;

namespace TNTT.Web.Models
{
    public class MienModel
    {
        public int Id { get; set; }
        public Nullable<DateTime> StartDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }
        public Contact ChaTuyenUy { get; set; }
        public Contact ChuTich { get; set; }
        public Contact PhoQuanTri { get; set; }
        public Contact PhoNghienHuan { get; set; }
        public Nullable<int> ThuKy { get; set; }
        public Nullable<int> ThuQuy { get; set; }
        public Nullable<int> UyVienAu { get; set; }
        public Nullable<int> UyVienThieu { get; set; }
        public Nullable<int> UyVienNghia { get; set; }
        public Nullable<int> UyVienHiep { get; set; }
        public Nullable<int> UyVienKyThuat { get; set; }
        public Nullable<int> UyVienPhungVu { get; set; }
        public Nullable<int> UyVienTruyenThong { get; set; }
        public Nullable<int> UyVienGiaoTe { get; set; }
        public Nullable<int> UyVienDaiHoi { get; set; }
        public Nullable<int> UyVienBaoChi { get; set; }
        public Nullable<int> UyVienVanNghe { get; set; }
        public Nullable<int> UyVienXaHoi { get; set; }
        public Nullable<int> UyVienTaiChanh { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Status { get; set; }
    }
}