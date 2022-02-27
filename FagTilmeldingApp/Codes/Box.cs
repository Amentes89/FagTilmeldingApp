using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPH1.Codes
{
    internal class Box : IComparable<Box>
    {
        private double Højde { get; set; }

        private double Bredde { get; set; }

        private double Længde { get; set; }

        public double Volume { get; set; }

        private BoxType Type { get; set; }

        public Box()
        {
        }

        public Box(double højde, double bredde, double længde)
        {
            Højde = højde;
            Bredde = bredde;
            Længde = længde;
            GetVolume();
            SetBoxType();
        }

        private void GetVolume()
        {
            Volume = Længde * Bredde * Højde;
        }

        public override string ToString()
        {
            return $"Volume {Volume}, {Type.ToString()}";
        }

        public static Box operator +(Box b, Box c)
        {
            Box box = new Box();

            box.Længde = b.Længde + c.Længde;
            box.Bredde = b.Bredde + c.Bredde;
            box.Højde = b.Højde + c.Højde;
            box.Volume = box.Længde * box.Bredde * box.Højde;

            //Regel: LilleBox + lilleBox giver mellemBox, resten er storBox.
            if (b.Type == BoxType.lilleBox && c.Type == BoxType.lilleBox)
            {
                box.Type = BoxType.mellemBox;
            }
            else
            {
                box.Type = BoxType.storbox;
            }

            return box;
        }

        private void SetBoxType()
        {

            if (Volume <= 125)
            {
                // lille box
                Type = BoxType.lilleBox;
            }
            else if (Volume >= 126 && Volume <= 1500)
            {
                // mellem box
                Type = BoxType.mellemBox;
            }
            else
            {
                // stor box
                Type = BoxType.storbox;
            }

            //Type = (Volume <= 125) ? BoxType.lilleBox : (Volume >= 126 && Volume <= 1500) ? BoxType.mellemBox : BoxType.storbox;
        }

        public int CompareTo(Box? other)
        {
            if (Volume < other.Volume)
            {
                return 1;
            }
            else if (Volume > other.Volume)
            {
                return -1;
            }
            else
            {
                return 0;
            }

            //return (Volume < other.Volume) ? 1 : (Volume > other.Volume) ? -1 : 0;
        }
    }
}