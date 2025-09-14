using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace GenerateQrCode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QrCodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetQrCode([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text)) return BadRequest("Text cannot be null or empty");
            using var qrGenerator = new QRCodeGenerator();
            using var qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            using PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeAsPngByteArr = qrCode.GetGraphic(20);

            return File(qrCodeAsPngByteArr, "image/png");
        }
    }
}