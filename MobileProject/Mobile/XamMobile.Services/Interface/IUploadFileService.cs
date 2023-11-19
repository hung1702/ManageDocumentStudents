using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamMobile.Services.Models;

namespace XamMobile.Services.Interface
{
    public interface IUploadFileService
    {
        Task<string> UploadFile(FileUploaded files);
    }
}
