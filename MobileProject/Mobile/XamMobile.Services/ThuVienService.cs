using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Services.Models;

namespace XamMobile.Services
{
    public class ThuVienService : BaseService, IThuVienService
    {
        public async Task<List<MuonSachEntity>> GetAllMuonSach()
        {
            try
            {
                var response = await GetRequestWithHandleErrorAsync<List<MuonSachEntity>>(AppConstant.AppConstant.APIGetAllMuonSach);
                if (response.Message.Code == ResponseCode.SUCCESS)
                {
                    return response.Result;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<MuonSachEntity> InsertOrUpdateMuonSach(MuonSachEntity model)
        {
            try
            {
                var result = await PostRequestWithHandleErrorAsync<MuonSachEntity, MuonSachEntity>(AppConstant.AppConstant.APIInsertOrUpdateMuonSach, model);
                if (result.Message.IsSuccess)
                {
                    return result.Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
