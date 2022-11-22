using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestTriangle.StaticProperty
{
    static class OBJProperty
    {
        public static bool PrintTriangle;
        public static bool PrintVertex;
        public static bool PrintFacesNormal;
        public static bool PrintVertsNormal;

        public static Color ObjectColor;
        public static Color VertNormalColor;
        public static Color FaceNormalColor;
        public static Color EdgeColor;
        public static Color VertColor;

        public static double VertsNormalLength;
        public static double FaceNormalLength;

        public static double zoom;

        public static void SetDefColors()
        {
            ObjectColor = Color.FromRgb(255,255,255);
            VertNormalColor = Color.FromRgb(255, 0, 0);
            FaceNormalColor = Color.FromRgb(255, 164, 6);
            EdgeColor = Color.FromRgb(43, 154, 195);
            VertColor = Color.FromRgb(255, 255, 255);
        }
        static public void ResetNormals()
        {
            VertsNormalLength = (double)0.01;
            FaceNormalLength = (double)0.01;
        }
        public static void Clear()
        {
            PrintTriangle = false;
            PrintVertex = false;
            PrintFacesNormal = false;
            PrintVertsNormal = false;
            SetDefColors();
            ResetNormals();
            zoom = 1;
        }
    }
}
