﻿using System;

namespace AppConstant
{
    public class AppConstant
    {
        //public const string Endpoint = "http://10.10.63.37:7777";

        //public const string Endpoint = "http://192.168.113.2:7000";
        public const string Endpoint = "http://10.10.41.10:1200";

        //public const string Endpoint = "http://10.0.2.2:56565";
        //
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
    }
}