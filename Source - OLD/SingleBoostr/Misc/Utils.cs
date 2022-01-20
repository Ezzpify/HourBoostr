using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

namespace SingleBoostr.Misc
{
    internal static class Utils
    {
        internal static Color LABEL_HOVER = Color.FromArgb(255, 73, 131);
        internal static Color LABEL_NORMAL = Color.Gray;

        internal static Image BytesToImage(byte[] bytes) => Image.FromStream(new MemoryStream(bytes));
         
        internal static Bitmap ChangeImageOpacity(Image img, float opacityvalue)
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

        internal static Image FixedImageSize(Image image, int Width, int Height)
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
