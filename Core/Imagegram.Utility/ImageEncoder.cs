using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Imagegram.Utility
{
	public class ImageEncoder
	{
		public byte[] ConvertImageToJpeg(string filePath)
		{
            Bitmap bmp1 = new Bitmap(filePath);
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L); //100L for no quality loss
            myEncoderParameters.Param[0] = myEncoderParameter;

            var stream = new MemoryStream();
            bmp1.Save(stream, jpgEncoder, myEncoderParameters);

            return stream.ToArray(); 
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }
}
