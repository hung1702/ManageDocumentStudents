﻿using System;

namespace AppConstant
{
    public class AppConstant
    {
        public const string Endpoint = "http://10.10.41.10:1200";
        //public const string Endpoint = "http://10.0.2.2:56565";
        public const string APIThongBao = "/odata/ThongBaoChung";
        public const string APINhanVien = "/odata/S_NhanVien";
        public const string APIUser = "/odata/S_Users";
        public const string APIVanBan = "/odata/S_VanBan";
        public const string APIHoSo = "/odata/S_HoSo";
        public const string APILog = "/odata/NhatKies";
        public const string APIGetImage = "/fileuploads/download?key=";
        public const string APIInsertOrUpdateNhanVien = "api/nhanvien/insertorupdatenhanvien";
        public const string APIDeleteNhanVien = "api/nhankhau/deletenhanvien";
        public const string APIDeleteNhanVien1 = "api/nhanvien/deletenhanvien";
        public const string APIUploadImage = "api/img";
        public const string APIUpdateNhanVienAvatar = "api/nhanvien/updateavatar";

        //TinTuc
        public const string APIGetAllTinTuc = "api/tintuc/getalltintuc";
        public const string APIInsertOrUpdateTinTuc = "api/tintuc/insertorupdatetintuc";
        public const string APIDeleteTinTuc = "api/tintuc/deletetintuc";

        //MuonSach
        public const string APIGetAllMuonSach = "api/muonSach/getallmuonsach";
        public const string APIInsertOrUpdateMuonSach = "api/muonSach/insertorupdatemuonsach";

        //BieuMau
        public const string APIGetAllLoaiBieuMau = "api/bieumau/getallloaibieumau";
        public const string APIInsertOrUpdateLoaiBieuMau = "api/bieumau/insertorupdateloaibieumau";
        public const string APIDeleteLoaiBieuMau = "api/bieumau/deletetloaibieumau";
    }
}
