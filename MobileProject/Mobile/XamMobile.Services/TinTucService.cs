using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Services.Models;

namespace XamMobile.Services
{
    public class TinTucService : BaseService, ITinTucService
    {
        public async Task<List<TinTucEntity>> GetAllTinTuc()
        {
            try
            {
                var userResponse = await GetRequestWithHandleErrorAsync<List<TinTucEntity>>(AppConstant.AppConstant.APIGetAllTinTuc);
                if (userResponse.Message.Code == ResponseCode.SUCCESS)
                    return userResponse.Result;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TinTucEntity> InsertOrUpdateTinTuc(TinTucEntity model)
        {
            try
            {
                var result = await PostRequestWithHandleErrorAsync<TinTucEntity, TinTucEntity>(AppConstant.AppConstant.APIInsertOrUpdateTinTuc, model);
                if (result.Message.IsSuccess)
                    return result.Result;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteTinTuc(int Id)
        {
            try
            {
                var result = await PostRequestWithHandleErrorAsync<int, bool>(AppConstant.AppConstant.APIDeleteTinTuc, Id);
                if (result.Message.IsSuccess)
                    return result.Result;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
