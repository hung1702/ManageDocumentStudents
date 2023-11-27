using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;

namespace XamMobile.Services.Interface
{
    public interface IBieuMauService
    {
        Task<List<LoaiBieuMauEntity>> GetAllLoaiBieuMau();

        Task<LoaiBieuMauEntity> InsertOrUpdateLoaiBieuMau(LoaiBieuMauEntity model);
        
        Task<bool> DeleteLoaiBieuMau(int Id);
    }
}
