using LoadingImagesToDB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using OnlineStorePET.Models.Database;

namespace LoadingImagesToDB.Controllers
{
    public class HomeController : Controller
    {
        private OnlineStoreDbContext context;

        public HomeController(OnlineStoreDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            LoadImage();
            return View();
        }

        private void LoadImage()
        {
            StoreDataModels.Image imgModel = new StoreDataModels.Image();   

            byte[] img = System.IO.File.ReadAllBytes(@$"C:\Users\Тимофей\Pictures\Saved Pictures\Standart T-Shirt.png");

            imgModel.ImageBytes = img;
            imgModel.Description = "Default T-Shirt";

            context.Images.Add(imgModel);
            context.SaveChanges();

            Console.ReadLine();
        }

        //private void UnloadImage()
        //{
        //    byte[] img = context.Images.First().Image;

        //    Image image;
        //    using (MemoryStream ms = new MemoryStream(img))
        //    {
        //        image = new Bitmap(ms);
        //        image.Save($@"C:\Users\Тимофей\Pictures\Saved Pictures\images2.jpg", ImageFormat.Jpeg);
        //    }           
        //}

    }
}
