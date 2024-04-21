using File_upload.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace File_upload.Controllers
{
    public class BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService) : Controller
    {
        readonly IBufferedFileUploadService _bufferedFileUploadService = bufferedFileUploadService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            try
            {
                if (await _bufferedFileUploadService.UploadFile(file))
                {
                    ViewBag.Message = "File Upload Successful.";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
            }
            catch (Exception) { ViewBag.Message = "File Upload Failed"; }
            return View();
        }
    }
}
