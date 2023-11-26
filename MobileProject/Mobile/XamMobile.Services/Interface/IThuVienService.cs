using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;

namespace XamMobile.Services.Interface
{
    public interface IThuVienService
    {
        Task<List<MuonSachEntity>> GetAllMuonSach();

        Task<MuonSachEntity> InsertOrUpdateMuonSach(MuonSachEntity model);
    }
}
