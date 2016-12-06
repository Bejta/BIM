using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BIMDomain.Models
{
    public class ImageManager
    {
        private int thumbnailSize = 256;
        private int width;
        private int height;

        public Image ResizeImage(Image image)
        {
            int thumbnailSize = 256;

            if (image.Width > image.Height)
            {
                width = thumbnailSize;
                height = image.Height * thumbnailSize / image.Width;
            }
            else
            {
                width = image.Width * thumbnailSize / image.Height;
                height = thumbnailSize;
            }

            return image;
        }

        public Image LoadImageFromFile(string fileName)
        {
            //Image img = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/" + fileName), true);
            //Image img = Image.FromFile(HostingEnvironment.MapPath("~/Content/images/" + fileName), true);
            Image img = Image.FromFile(Path.Combine(Environment.CurrentDirectory, @"BIMDomain\Content\images\", fileName));

            return img;
        }
       

        //Convert image to byte array
        public byte[] converterImageToByte(Image image)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] byteImage = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
            return byteImage;
        }

        public bool IsValidImage(Image image)
        {
            if (image.RawFormat.Guid == ImageFormat.Png.Guid)
                return true;

            return false;
        }
    }
}