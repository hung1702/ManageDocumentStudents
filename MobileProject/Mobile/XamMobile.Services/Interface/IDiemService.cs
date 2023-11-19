using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.EntityModels;

namespace XamMobile.Services.Interface
{
    public interface IDiemService
    {
        Task<List<DiemEntity>> GetDSDiem();

    }

}
