using Microsoft.AspNetCore.WebUtilities;

namespace File_upload.Interfaces;

public interface IStreamFileUpLoadService
{
    Task<bool> UploadFile(MultipartReader reader, MultipartSection section); 
}
