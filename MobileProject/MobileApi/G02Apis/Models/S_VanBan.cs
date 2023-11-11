//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace G02Apis.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class S_VanBan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public S_VanBan()
        {
            this.NhatKies = new HashSet<NhatKy>();
        }
    
        public int VanBanID { get; set; }
        public int HoSoID { get; set; }
        public string MaDinhDanh { get; set; }
        public Nullable<int> STTVanBan { get; set; }
        public Nullable<int> LoaiVanBanID { get; set; }
        public string SoVanBan { get; set; }
        public string KyHieuVanBan { get; set; }
        public string NoiDung { get; set; }
        public Nullable<int> NgonNguID { get; set; }
        public Nullable<int> SoTo { get; set; }
        public string GhiChu { get; set; }
        public string KyHieuThongTin { get; set; }
        public string TuKhoa { get; set; }
        public string ButTich { get; set; }
        public Nullable<int> TinhTrangVatLyID { get; set; }
        public Nullable<int> MucDoTinCayID { get; set; }
        public Nullable<int> ComputerFileID { get; set; }
        public Nullable<System.DateTime> NgayVanBan { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public Nullable<System.DateTime> NgayCapNhat { get; set; }
        public string NguoiTao { get; set; }
        public string NguoiChinhSua { get; set; }
        public Nullable<int> StatusID { get; set; }
        public Nullable<System.DateTime> NgayThemFile { get; set; }
        public string CheDoSuDung { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<byte> Signature { get; set; }
        public Nullable<byte> Confirmed { get; set; }
        public string CoQuanToChucBanHanh { get; set; }
    
        public virtual CommonStatu CommonStatu { get; set; }
        public virtual NgonNgu NgonNgu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhatKy> NhatKies { get; set; }
        public virtual S_ComputerFile S_ComputerFile { get; set; }
        public virtual S_HoSo S_HoSo { get; set; }
        public virtual S_LoaiVanBan S_LoaiVanBan { get; set; }
        public virtual S_MucDoTinCay S_MucDoTinCay { get; set; }
        public virtual S_TinhTrangVatLy S_TinhTrangVatLy { get; set; }
    }
}
