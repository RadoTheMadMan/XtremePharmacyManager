using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XtremePharmacyManager
{
    public static class ImageBinConverter
    {
        public static void ConvertImageToBinary(Bitmap Image, out byte[] target)
        {
            try
            {
                byte[] result;
                MemoryStream memoryStream = new MemoryStream();
                Image.Save(memoryStream, ImageFormat.Png);
                result = memoryStream.ToArray();
                target = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Bitmap blank = new Bitmap(Image.Width, Image.Height);
                int Size = blank.Width * blank.Height;
                byte[] result = new byte[Size];
                MemoryStream memoryStream = new MemoryStream(result);
                blank.Save(memoryStream, ImageFormat.Png);
                target = result;
            }
        }

        public static void ConvertBinaryToImage(byte[] bytes, out Bitmap target)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(bytes);
                target = new Bitmap(memoryStream);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\nStackTrace:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                target = new Bitmap(32, 32);
            }
        }
    }
}
