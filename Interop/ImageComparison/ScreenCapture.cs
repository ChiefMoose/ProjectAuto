using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ImageComparison
{
    public static class ScreenCapture
    {
        private const string INVALID_RECTANGLE_DIMENSIONS = "Rectangle cannot have 0 or negative {0}.";

        /// <summary>
        /// Creates a <see cref="Bitmap"/> image.
        /// </summary>
        /// <param name="captureBounds">Dimensions and position of desired <see cref="Bitmap"/>.</param>
        /// <returns>Returns <see cref="Bitmap"/> of the specified window dimensions.</returns>
        public static Bitmap CaptureBitmapImage(Rectangle captureBounds)
        {
            Bitmap captureBitmap = new Bitmap(captureBounds.Width, captureBounds.Height);

            using (Graphics image = Graphics.FromImage(captureBitmap))
            {
                image.CopyFromScreen(
                    captureBounds.Left,
                    captureBounds.Top,
                    0, 0,
                    captureBitmap.Size);
            }
            return captureBitmap;
        }

        /// <summary>
        /// Creates a <see cref="Bitmap"/> image.
        /// </summary>
        /// <param name="topLeftPoint">Upper left corner of image to be captured.</param>
        /// <param name="lowerRightPoint">Lower right point of image to be captured.</param>
        /// <returns>Returns <see cref="Bitmap"/> of the specified window dimensions.</returns>
        public static Bitmap CaptureBitmapImage(Point topLeftPoint, Point lowerRightPoint)
        {
            if (lowerRightPoint.X - topLeftPoint.X <= 0)
            {
                throw new InvalidOperationException(string.Format(INVALID_RECTANGLE_DIMENSIONS, "width"));
            }

            if (lowerRightPoint.Y - topLeftPoint.Y <= 0)
            {
                throw new InvalidOperationException(string.Format(INVALID_RECTANGLE_DIMENSIONS, "height"));
            }

            Rectangle rect = new Rectangle(
                topLeftPoint.X,
                topLeftPoint.Y,
                lowerRightPoint.X - topLeftPoint.X,
                lowerRightPoint.Y - topLeftPoint.Y);

            return CaptureBitmapImage(rect);
        }

        /// <summary>
        /// Saves a given <see cref="Bitmap"/> to a specified directory.
        /// </summary>
        /// <param name="image">Image to be saved.</param>
        /// <param name="directory">Directory to be saved to.</param>
        public static void SaveBitmapImage(Bitmap image, string directory)
        {
            image.Save(directory, ImageFormat.Bmp);
        }

        public static Bitmap ImageDifferential(Bitmap imageOne, Bitmap imageTwo)
        {
            if (imageOne.Height != imageTwo.Height)
            {
                throw new InvalidOperationException("Image heights do not match.");
            }

            if (imageOne.Width != imageTwo.Width)
            {
                throw new InvalidOperationException("Image widths do not match.");
            }

            Bitmap image = new Bitmap(imageOne.Width, imageOne.Height);

            Color white = Color.White;
            Color red = Color.Red;

            for (int x = 0; x < imageOne.Width; x++)
            {
                for (int y = 0; y < imageOne.Height; y++)
                {
                    if (imageOne.GetPixel(x, y).Equals(imageTwo.GetPixel(x, y)))
                    {
                        image.SetPixel(x, y, white);
                    }
                    else
                    {
                        image.SetPixel(x, y, red);
                    }
                }
            }

            return image;
        }

        /// <summary>
        /// Returns the image difference between the two images.
        /// </summary>
        /// <param name="imageOne">First image to be compared.</param>
        /// <param name="imageTwo">Second image to be compared.</param>
        /// <returns>Difference as a percent between the two images.</returns>
        public static double GetImageDifference(Bitmap imageOne, Bitmap imageTwo)
        {
            double area = 0;
            double difference = 0;
            using (Bitmap image = ImageDifferential(imageOne, imageTwo))
            {
                area = image.Height * image.Width;

                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        if (image.GetPixel(x, y) == Color.Red)
                        {
                            difference++;
                        }
                    }
                }
                if (difference > 0.0d)
                {
                    return area / difference;
                }
                else
                {
                    return 0.0d;
                }
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}