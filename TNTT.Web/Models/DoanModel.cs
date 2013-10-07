using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNTT.Web.Models
{
    public class DoanModel
    {
        public int Id { get; set; }
        public int MienId { get; set; }
        public string mienName { get; set; }
        public Nullable<int> LienDoanId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Nullable<int> ChaTuyenUy { get; set; }
        public Nullable<int> DoanTruong { get; set; }
        public Nullable<int> PhoQuanTri { get; set; }
        public Nullable<int> PhoNghienHuan { get; set; }
        public Nullable<int> ThuKy { get; set; }
        public Nullable<int> ThuQuy { get; set; }
        public string Website { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Status { get; set; }
        public string ParishName { get; set; }
    }
}