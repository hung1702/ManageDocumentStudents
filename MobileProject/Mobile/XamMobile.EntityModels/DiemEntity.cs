using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace XamMobile.EntityModels
{
    public class DiemEntity
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [JsonProperty("MaSinhVien")]
        public string MaSinhVien { get; set; }
        [JsonProperty("MaMonHoc")]
        public string MaMonHoc { get; set; }
        [JsonProperty("TenMonHoc")]
        public string TenMonHoc { get; set; }

        private double _diemCC;
        [JsonProperty("DiemCC")]
        public double DiemCC
        {
            get { return _diemCC; }
            set
            {
                if (_diemCC != value)
                {
                    _diemCC = value;
                    OnPropertyChanged(nameof(DiemCC));
                }
            }
        }

        private double _diemKT;
        [JsonProperty("DiemKT")]
        public double DiemKT
        {
            get { return _diemKT; }
            set
            {
                if (_diemKT != value)
                {
                    _diemKT = value;
                    OnPropertyChanged(nameof(DiemKT));
                }
            }
        }

        private double _diemTH;
        [JsonProperty("DiemTH")]
        public double DiemTH
        {
            get { return _diemTH; }
            set
            {
                if (_diemTH != value)
                {
                    _diemTH = value;
                    OnPropertyChanged(nameof(DiemTH));
                }
            }
        }

        private double _diemThi;
        [JsonProperty("DiemThi")]
        public double DiemThi
        {
            get { return _diemThi; }
            set
            {
                if (_diemThi != value)
                {
                    _diemThi = value;
                    OnPropertyChanged(nameof(DiemThi));
                }
            }
        }
        [JsonProperty("SoTinChi")]
        public double SoTinChi { get; set; }
        [JsonProperty("HeSoMonHoc")]
        public string HeSoMonHoc { get; set; }
        [JsonProperty("MaHocKy")]
        public int MaHocKy { get; set; }

        public List<int> HeSo
        {
            get
            {
                if (this.HeSoMonHoc == null || this.HeSoMonHoc == default)
                    this.HeSoMonHoc = "10102060";
                if (this.HeSoMonHoc == "10101070")
                    return new List<int> { 10, 10, 10, 70 };
                else if (this.HeSoMonHoc == "10202050")
                    return new List<int> { 10, 20, 20, 50 };
                else
                    return new List<int> { 10, 10, 20, 60 };
            }
        }

        public string TenHocKy
        {
            get
            {
                return GetTenHocKy(MaHocKy);
            }
        }

        public double DiemTB
        {
            get
            {
                return GetDiemTBTheoHeSo(this.HeSoMonHoc, this.DiemCC, this.DiemKT, this.DiemTH, this.DiemThi);
            }
        }

        public double DiemTBHe4
        {
            get
            {
                var diemTB = GetDiemTBTheoHeSo(this.HeSoMonHoc, this.DiemCC, this.DiemKT, this.DiemTH, this.DiemThi);
                return Math.Round(diemTB * 4 / 10, 2);
            }
        }

        public string DiemChu
        {
            get
            {
                var diemtb = GetDiemTBTheoHeSo(this.HeSoMonHoc, this.DiemCC, this.DiemKT, this.DiemTH, this.DiemThi);
                return GetDiemChu(diemtb);
            }
        }

        public string GetDiemChu(double diem)
        {
            if (diem < 4.0)
                return "F";
            else if (diem < 5)
                return "D";
            else if (diem < 5.5)
                return "D+";
            else if (diem < 6.5)
                return "C";
            else if (diem < 7)
                return "C+";
            else if (diem < 8)
                return "B";
            else if (diem < 8.5)
                return "B+";
            else if (diem < 9)
                return "A";
            else
                return "A+";
        }

        public string GetTenHocKy(int maHocKy)
        {
            if (maHocKy == 1)
                return "HK 1 Năm 1";
            else if (maHocKy == 2)
                return "HK 2 Năm 1";
            else if (maHocKy == 3)
                return "HK 3 Năm 1";
            else if (maHocKy == 4)
                return "HK 1 Năm 2";
            else if (maHocKy == 5)
                return "HK 2 Năm 2";
            else if (maHocKy == 6)
                return "HK 3 Năm 2";
            else if (maHocKy == 7)
                return "HK 1 Năm 3";
            else if (maHocKy == 8)
                return "HK 2 Năm 3";
            else if (maHocKy == 9)
                return "HK 3 Năm 3";
            else if (maHocKy == 10)
                return "HK 1 Năm 4";
            else if (maHocKy == 11)
                return "HK 2 Năm 4";
            else if (maHocKy == 12)
                return "HK 3 Năm 4";
            else if (maHocKy == 13)
                return "HK 1 Năm 5";
            else if (maHocKy == 14)
                return "HK 2 Năm 5";
            else if (maHocKy == 15)
                return "HK 3 Năm 5";
            else
                return "HK Phụ";
        }

        public double GetDiemTBTheoHeSo(string heSo, double diemCC, double diemKT, double diemTH, double diemThi)
        {
            if (HeSoMonHoc == null || HeSoMonHoc == default)
                HeSoMonHoc = "10102060";

            if (heSo == "10101070")
                return Math.Round((diemCC * 10 + diemKT * 10 + diemTH * 10 + diemThi * 70) / 100, 2);
            else if (heSo == "10202050")
                return Math.Round((diemCC * 10 + diemKT * 20 + diemTH * 20 + diemThi * 50) / 100, 2);
            else
                return Math.Round((diemCC * 10 + diemKT * 10 + diemTH * 20 + diemThi * 60) / 100, 2);
        }
    }
}
