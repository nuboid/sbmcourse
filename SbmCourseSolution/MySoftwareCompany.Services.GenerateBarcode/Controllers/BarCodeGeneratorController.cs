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
            var barcode = QrEncoder.Encode(data, ErrorCorrectionLevel.Q, Encoding.Auto);
            var renderer = new ImageRenderer();
            var stream = new MemoryStream();
            renderer.Render(barcode, stream);

            return File(stream.ToArray(), "image/png");
        }
    }
}
