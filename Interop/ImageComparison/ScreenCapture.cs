using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace ImageComparison
{
    public static class ScreenCapture
    {
        /// <summary>
        /// Creates a <see cref="Bitmap"/> image.
        /// </summary>
        /// <param name="captureBounds">Dimensions and position of desired <see cref="Bitmap"/>.</param>
        /// <returns><see cref="Bitmap"/> of the rectangle given.</returns>
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
                return null;
            }

            if (imageOne.Width != imageTwo.Width)
            {
                return null;
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
    }
}