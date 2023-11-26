using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;

namespace XamMobile.Services.Interface
{
    public interface ITinTucService
    {
        Task<List<TinTucEntity>> GetAllTinTuc();

        Task<TinTucEntity> InsertOrUpdateTinTuc(TinTucEntity model);

        Task<bool> DeleteTinTuc(int Id);
    }
}
