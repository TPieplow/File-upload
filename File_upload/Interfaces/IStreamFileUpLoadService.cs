using Microsoft.AspNetCore.WebUtilities;

namespace File_upload.Interfaces;

public interface IStreamFileUploadService
{
    Task<bool> UploadFile(MultipartReader reader, MultipartSection section); 
}
