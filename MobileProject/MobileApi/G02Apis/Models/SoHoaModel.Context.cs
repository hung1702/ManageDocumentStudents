﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SoHoaEntities : DbContext
    {
        public SoHoaEntities()
            : base("name=SoHoaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<CommonStatu> CommonStatus { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
        public virtual DbSet<DigitalSignature> DigitalSignatures { get; set; }
        public virtual DbSet<FileUpload> FileUploads { get; set; }
        public virtual DbSet<Huyen> Huyens { get; set; }
        public virtual DbSet<NgonNgu> NgonNgus { get; set; }
        public virtual DbSet<NhatKy> NhatKies { get; set; }
        public virtual DbSet<S_Authority> S_Authority { get; set; }
        public virtual DbSet<S_ComputerFile> S_ComputerFile { get; set; }
        public virtual DbSet<S_CoQuan> S_CoQuan { get; set; }
        public virtual DbSet<S_HopSo> S_HopSo { get; set; }
        public virtual DbSet<S_HoSo> S_HoSo { get; set; }
        public virtual DbSet<S_Kho> S_Kho { get; set; }
        public virtual DbSet<S_LoaiCoQuan> S_LoaiCoQuan { get; set; }
        public virtual DbSet<S_LoaiHoSo> S_LoaiHoSo { get; set; }
        public virtual DbSet<S_LoaiVanBan> S_LoaiVanBan { get; set; }
        public virtual DbSet<S_LuuTru> S_LuuTru { get; set; }
        public virtual DbSet<S_Menu> S_Menu { get; set; }
        public virtual DbSet<S_MucDoTinCay> S_MucDoTinCay { get; set; }
        public virtual DbSet<S_MucLucHoSo> S_MucLucHoSo { get; set; }
        public virtual DbSet<S_NhanVien> S_NhanVien { get; set; }
        public virtual DbSet<S_Page> S_Page { get; set; }
        public virtual DbSet<S_Phong> S_Phong { get; set; }
        public virtual DbSet<S_Role> S_Role { get; set; }
        public virtual DbSet<S_Role_URL> S_Role_URL { get; set; }
        public virtual DbSet<S_TinhTrangVatLy> S_TinhTrangVatLy { get; set; }
        public virtual DbSet<S_Uers_Atuthority> S_Uers_Atuthority { get; set; }
        public virtual DbSet<S_User_Role> S_User_Role { get; set; }
        public virtual DbSet<S_Users> S_Users { get; set; }
        public virtual DbSet<S_VanBan> S_VanBan { get; set; }
        public virtual DbSet<Tinh> Tinhs { get; set; }
        public virtual DbSet<XaPhuong> XaPhuongs { get; set; }
    }
}
