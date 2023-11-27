using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;
using XamMobile.Services.Models;

namespace XamMobile.Services
{
    public class BieuMauService : BaseService, IBieuMauService
    {
        public async Task<List<LoaiBieuMauEntity>> GetAllLoaiBieuMau()
        {
            try
            {
                var userResponse = await GetRequestWithHandleErrorAsync<List<LoaiBieuMauEntity>>(AppConstant.AppConstant.APIGetAllLoaiBieuMau);
                if (userResponse.Message.Code == ResponseCode.SUCCESS)
                    return userResponse.Result;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<LoaiBieuMauEntity> InsertOrUpdateLoaiBieuMau(LoaiBieuMauEntity model)
        {
            try
            {
                var result = await PostRequestWithHandleErrorAsync<LoaiBieuMauEntity, LoaiBieuMauEntity>(AppConstant.AppConstant.APIInsertOrUpdateLoaiBieuMau, model);
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

        public async Task<bool> DeleteLoaiBieuMau(int Id)
        {
            try
            {
                var result = await PostRequestWithHandleErrorAsync<int, bool>(AppConstant.AppConstant.APIDeleteLoaiBieuMau, Id);
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
