using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Services.Models;

namespace XamMobile.Services
{
    public class DiemService : BaseService, IDiemService
    {
        public async Task<List<DiemEntity>> GetDSDiem()
        {
            try
            {
                var dsDiem = new List<DiemEntity>()
                {
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "100",TenMonHoc = "Lap Trinh Huong Doi Tuong Huong Doi Tuong",DiemCC = 7, DiemKT = 8, DiemTH = 8, DiemThi = 8, SoTinChi = 3, MaHocKy = 4
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "101",TenMonHoc = "Lap Trinh Web",DiemCC = 7, DiemKT = 8, DiemTH = 8, DiemThi = 8, SoTinChi = 3, MaHocKy = 6
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "102",TenMonHoc = "Co So Du Lieu",DiemCC = 5, DiemKT = 6, DiemTH = 8, DiemThi = 10, SoTinChi = 2, MaHocKy = 7
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "103",TenMonHoc = "He Dieu Hanh",DiemCC = 3, DiemKT = 5, DiemTH = 5, DiemThi = 8,SoTinChi = 3, MaHocKy = 3
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "104",TenMonHoc = "Lich Su Dang",DiemCC = 10, DiemKT = 10, DiemTH = 10, DiemThi = 9,SoTinChi = 2, MaHocKy = 1
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "100",TenMonHoc = "Lap Trinh Huong Doi Tuong Huong Doi Tuong",DiemCC = 7, DiemKT = 8, DiemTH = 8, DiemThi = 8, SoTinChi = 3, MaHocKy = 1
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "101",TenMonHoc = "Lap Trinh Web",DiemCC = 7, DiemKT = 8, DiemTH = 8, DiemThi = 8, SoTinChi = 3, MaHocKy = 1
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "102",TenMonHoc = "Co So Du Lieu",DiemCC = 5, DiemKT = 6, DiemTH = 8, DiemThi = 10, SoTinChi = 2, MaHocKy = 1
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "103",TenMonHoc = "He Dieu Hanh",DiemCC = 3, DiemKT = 5, DiemTH = 5, DiemThi = 8,SoTinChi = 3, MaHocKy = 1
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "104",TenMonHoc = "Lich Su Dang",DiemCC = 10, DiemKT = 10, DiemTH = 10, DiemThi = 9,SoTinChi = 2, MaHocKy = 2
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "100",TenMonHoc = "Lap Trinh Huong Doi Tuong Huong Doi Tuong",DiemCC = 7, DiemKT = 8, DiemTH = 8, DiemThi = 8, SoTinChi = 3, MaHocKy = 4
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "101",TenMonHoc = "Lap Trinh Web",DiemCC = 7, DiemKT = 8, DiemTH = 8, DiemThi = 8, SoTinChi = 3, MaHocKy = 4
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "102",TenMonHoc = "Co So Du Lieu",DiemCC = 5, DiemKT = 6, DiemTH = 8, DiemThi = 10, SoTinChi = 2, MaHocKy = 5
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "103",TenMonHoc = "He Dieu Hanh",DiemCC = 3, DiemKT = 5, DiemTH = 5, DiemThi = 8,SoTinChi = 3, MaHocKy = 5
                    },
                    new DiemEntity()
                    {
                        MaSinhVien = "B19DCCN330", MaMonHoc = "104",TenMonHoc = "Lich Su Dang",DiemCC = 10, DiemKT = 10, DiemTH = 10, DiemThi = 9,SoTinChi = 2, MaHocKy = 4
                    }
                };

                return dsDiem.OrderBy(x => x.TenMonHoc).ToList();
                //var userResponse = await GetRequestWithHandleErrorAsync<OdataResult<List<HoSoEntity>>>($"{AppConstant.AppConstant.APIHoSo}");
                //if (userResponse.Message.Code == ResponseCode.SUCCESS)
                //{
                //    return userResponse.Result.Results;
                //}
                //return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
    }
}
