using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Test.Web.Controllers
{
    public class PictureController : Controller
    {
        // GET: Picture
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload2(string file)
        {
            //由InputStream取得XHR上傳的內容
            var stream = Request.InputStream;
            long totalLen = stream.Length, uploadedBytes = 0;

            //為了展示傳輸進度，故意一次1K慢慢讀
            byte[] buffer = new byte[1024];
            string outPath = Path.Combine(Server.MapPath("~/App_Data"), file);
            using (FileStream fs = new FileStream(outPath, FileMode.Create))
            {
                while (uploadedBytes < totalLen)
                {
                    var len = stream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, len);
                    uploadedBytes += len;
                    //故意延遲1ms
                    Thread.Sleep(3);
                }
            }
            return Content("OK");
        }


        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase[] file1)
        {

            foreach (var file in file1)
            {
                if (file.ContentLength < 0)
                    continue;


                string appPath = HttpContext.Request.PhysicalApplicationPath;
                string savaFolder = @"\Images\" + 1 + @"\" + 1 + @"\Temp\";
                string saveDir = appPath + savaFolder;

                string ext = file.FileName.Substring(file.FileName.LastIndexOf("."));
                string newFileName = string.Format("{0}-{1}-{2}-{3}-{4}{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Minute, DateTime.Now.Millisecond, ext);

                string fileUrl = saveDir + newFileName;



                Directory.CreateDirectory(saveDir);
                file.SaveAs(fileUrl);


                Image.GetThumbnailImageAbort callBack =new Image.GetThumbnailImageAbort(ThumbnailCallback);

                Bitmap image = new Bitmap(fileUrl);
                int[] thumbnailScale = getThumbnailImageScale(1280, 1280, image.Width, image.Height);
                Image smallImage = image.GetThumbnailImage(thumbnailScale[0], thumbnailScale[1], callBack, IntPtr.Zero);



          
                string savaFolder2 = @"\Images2\" + 1 + @"\" + 1 + @"\Temp\";
                string saveDir2 = appPath + savaFolder2;

            
                string newFileName2 = string.Format("{0}-{1}-{2}-{3}-{4}{5}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Minute, DateTime.Now.Millisecond, ext);

                string fileUrl2 = saveDir2 + newFileName2;


                Directory.CreateDirectory(saveDir2);
                smallImage.Save(fileUrl2);






            }

            return View();
        }



        public ActionResult Cut()
        {



            return View();
        }
        private int[] getThumbnailImageScale(int maxWidth, int maxHeight, int oldWidth, int oldHeight)
        {
            int[] result = new int[] { 0, 0 };
            float widthDividend, heightDividend, commonDividend;

            widthDividend = (float)oldWidth / (float)maxWidth;
            heightDividend = (float)oldHeight / (float)maxHeight;

            commonDividend = (heightDividend > widthDividend) ? heightDividend : widthDividend;
            result[0] = (int)(oldWidth / commonDividend);
            result[1] = (int)(oldHeight / commonDividend);

            return result;
        }
        private bool ThumbnailCallback()
        {
            return false;
        }

    }
}