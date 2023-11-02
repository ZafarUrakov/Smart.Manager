using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartManager.Services.Processings.Spreadsheets;
using System.IO;
using System.Threading.Tasks;

namespace SmartManager.Controllers
{
    public class SpreadsheetController : Controller
    {
        private readonly ISpreadsheetsProcessingService spreadsheetProcessingService;

        public SpreadsheetController(ISpreadsheetsProcessingService spreadsheetProcessingService)
        {
            this.spreadsheetProcessingService = spreadsheetProcessingService;
        }

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImportFile(IFormFile formFile)
        {
            IFormFile importFile = Request.Form.Files[0];

            using (MemoryStream stream = new MemoryStream())
            {
                importFile.CopyTo(stream);
                stream.Position = 0;
                await this.spreadsheetProcessingService.ProcessImportRequest(stream);
            }

            return RedirectToAction("GetStudents", "Student");

        }
    }
}
