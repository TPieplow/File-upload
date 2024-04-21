using File_upload.Interfaces;
using File_upload.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace File_upload.Controllers;

public class StreamFileUploadController(IStreamFileUploadService streamService) : Controller
{
    readonly IStreamFileUploadService _streamService = streamService;

    public IActionResult Index()
    {
        return View();
    }

    [ActionName("Index")]
    [HttpPost]
    public async Task<IActionResult> SaveFileToPhysicalFolder()
    {
        var boundary = HeaderUtilities.RemoveQuotes(MediaTypeHeaderValue.Parse(Request.ContentType).Boundary).Value;
        if (boundary is not null)
        {
            var reader = new MultipartReader(boundary, Request.Body);
            var section = await reader.ReadNextSectionAsync();
            string response = string.Empty;
            try
            {
                if (await _streamService.UploadFile(reader, section))
                {
                    ViewBag.Message = "File Uploaded Succesfully";
                    return View("Index");
                }
                ViewBag.Message = "File Upload Failed";
            }
            catch (Exception) { ViewBag.Message = "An error occurred while uploading file."; }
        }
        ViewBag.Message = "File Upload Failed";
        return View();
    }
}
