using System;
using System.IO;
using AutoMapper;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TouristApi.Controllers
{

    [Route("image")]
    [ApiController]
    public class ImageController : ControllerBase
    {




        private IWebHostEnvironment _hostingEnvironment;



        public ImageController(IWebHostEnvironment hostingEnvironment)
        {

            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("upload/image")]
        public ActionResult uploadImage([FromQuery] IFormFile file)
        {
            string path = _hostingEnvironment.WebRootPath + "/images/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            String fileName = DateTime.Now.ToString("yyyyMMddTHHmmss") + ".jpeg";
            using (var fileStream = System.IO.File.Create(path + fileName))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return Ok(fileName);
            }
        }


        [HttpPost]
        [Route("upload/video")]
        public ActionResult UploadVideo([FromQuery] IFormFile file)
        {


            Random rd = new Random();

            int rand_num = rd.Next(100, 1000000);
            string path = _hostingEnvironment.WebRootPath + "/videos/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var fileStream = System.IO.File.Create(path + rand_num.ToString() + ".mp4"))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();

                return Ok(rand_num.ToString() + ".mp4");



                // string path = _hostingEnvironment.WebRootPath + "/videos/";
                // if (!Directory.Exists(path))
                // {
                //     Directory.CreateDirectory(path);
                // }
                // String fileName = DateTime.Now.ToString("yyyyMMddTHHmmss") + ".mp4";
                // using (var fileStream = System.IO.File.Create(path + fileName))
                // {
                //     file.CopyTo(fileStream);
                //     fileStream.Flush();
                //     // using (Image bigImage = new Bitmap(fileName))
                //     // {
                //     //     // Algorithm simplified for purpose of example.
                //     //     int height = bigImage.Height / 10;
                //     //     int width = bigImage.Width / 10;

                //     //     // Now create a thumbnail
                //     //     using (Image smallImage = bigImage.GetThumbnailImage(width,
                //     //                                                         height,
                //     //                                                         new Image.GetThumbnailImageAbort(() => false), IntPtr.Zero))
                //     //     {
                //     //         smallImage.Save("thumbnail.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //     //     }
                //     // }
                //     return Ok(fileName);
            }


        }




    }
}