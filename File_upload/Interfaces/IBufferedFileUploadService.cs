namespace File_upload.Interfaces;

public interface IBufferedFileUploadService
{
    Task<bool> UploadFile(IFormFile file);
}
