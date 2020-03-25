using Barcoder.Code128;
using Barcoder.Qr;
using Barcoder.Renderer.Image;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace MySoftwareCompany.Services.GenerateBarcode.Controllers
{
    [ApiController]
    public class BarCodeGeneratorController : Controller
    {
        [HttpGet("api/ping")]
        public string GetPing()
        {
            return "pong";
        }

        [HttpGet("api/barcode/{data}")]
        public IActionResult GetBarcode(string data)
        {
            var barcode = Code128Encoder.Encode(data, true);
            var renderer = new ImageRenderer();
            var stream = new MemoryStream();
            renderer.Render(barcode, stream);

            return File(stream.ToArray(), "image/png");
        }
    }
}
