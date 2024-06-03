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
                if (Image != null)
                {
                    Image.Save(memoryStream, ImageFormat.Png);
                }
                result = memoryStream.ToArray();
                target = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Bitmap blank = new Bitmap(Image.Width, Image.Height);
                byte[] result;
                MemoryStream memoryStream = new MemoryStream();
                blank.Save(memoryStream, ImageFormat.Png);
                result = memoryStream.ToArray();
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
                MessageBox.Show($"{GLOBAL_RESOURCES.CRITICAL_ERROR_MESSAGE}::{ex.Message}\n{GLOBAL_RESOURCES.STACK_TRACE_MESSAGE}:{ex.StackTrace}", $"{GLOBAL_RESOURCES.CRITICAL_ERROR_TITLE}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                target = new Bitmap(32, 32);
            }
        }
    }
}
