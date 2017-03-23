using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;

namespace SingleBoostr
{
    class Utils
    {
        private static Random _random = new Random();

        public static Random GetRandom()
        {
            return _random;
        }

        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
        }

        public static bool IsOnlyNumbers(string str)
        {
            return new Regex("^[0-9]+$").IsMatch(str);
        }

        public static string GetUnicodeString(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }

        public static Image BytesToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        public static Bitmap ChangeImageOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                ColorMatrix colormatrix = new ColorMatrix()
                {
                    Matrix33 = opacityvalue
                };

                ImageAttributes imgAttribute = new ImageAttributes();
                imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                Brush bgBrush = new SolidBrush(Color.FromArgb(27, 27, 27));
                g.FillRectangle(bgBrush, 0, 0, img.Width, img.Height);
                g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);

                return bmp;
            }
        }

        public static Image FixedImageSize(Image image, int Width, int Height)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;

            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = Width / (double)sourceWidth;
            nScaleH = Height / (double)sourceHeight;

            nScale = Math.Max(nScaleH, nScaleW);
            destY = (Height - sourceHeight * nScale) / 2;
            destX = (Width - sourceWidth * nScale) / 2;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);

            Bitmap bmPhoto = new Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            using (Graphics grPhoto = Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new Rectangle(0, 0, sourceWidth, sourceHeight);
                grPhoto.DrawImage(image, to, from, GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }
    }
}
