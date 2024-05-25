using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace ManagementApplication.StaticFiles
{
    public static class ImageToBytesConverter
    {
        public static byte[] ImageToBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static byte[] ImageToBytes(BitmapImage bitmapImage)
        {
            throw new NotImplementedException();
        }

        public static BitmapImage BytesToImage(byte[] bytes)
        {
            throw new NotImplementedException();
        }
    }
}
