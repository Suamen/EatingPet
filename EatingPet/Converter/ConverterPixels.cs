using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EatingPet.Converter
{
    public class ConverterPixels
    {

        public int ConvertPixelX(int pixelX)
        {
            var ConvertPixelY =( 65535 * pixelX) / Screen.PrimaryScreen.Bounds.Height;
            return ConvertPixelY;
        }
        public int ConvertPixelY(int pxelY)
        {
            var ConvertPixelX = (65535 * pxelY) / Screen.PrimaryScreen.Bounds.Width;
            return ConvertPixelX;
        }
    }

}
