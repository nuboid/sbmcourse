using Barcoder.Code128;
using Barcoder.Qr;
using Barcoder.Renderer.Image;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace MySoftwareCompany.Services.GenerateBarcode.Controllers
{
    [ApiController]
    public class BarCodeGeneratorController : Controller
    {
        private readonly ILogger _logger;
        private readonly IDistributedCache _distributedCache;
        public BarCodeGeneratorController(
            ILogger<BarCodeGeneratorController> logger,
            IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }
        [HttpGet("api/ping")]
        public string GetPing()
        {
            return "pong";
        }

        [HttpGet("api/barcode/{data}")]
        public IActionResult GetBarcode(string data)
        {
            _logger.LogInformation("GetBarcode " + data);

            System.IO.File.WriteAllText(Environment.CurrentDirectory + @"/mydata/" + "file_" + DateTime.Now.Ticks + ".txt", data);

            var cachedString = _distributedCache.GetString("TEST");
            if (string.IsNullOrEmpty(cachedString))
            {
                _distributedCache.SetString("TEST","somevaluetocache");
                _logger.LogInformation("Was not found, ... but now set.");
            }
            else
            {
                _logger.LogInformation("Yeah, ... was found : " + cachedString);
            }

            var barcode = Code128Encoder.Encode(data, true);
            var renderer = new ImageRenderer();
            var stream = new MemoryStream();
            renderer.Render(barcode, stream);

            return File(stream.ToArray(), "image/png");
        }
    }
}
