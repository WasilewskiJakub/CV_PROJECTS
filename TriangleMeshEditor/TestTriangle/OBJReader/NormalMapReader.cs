using System;
using System.Collections.Generic;

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace TestTriangle.OBJReader
{
    static class NormalMapReader
    {
        static public bool settext;
        static public bool setmap;

        static public WriteableBitmap texture;
        static public WriteableBitmap map;
        public static void Reset()
        {
            setmap = settext = false;
            texture = map = null;
        }
        public static BitmapSource SetTextrure(string path)
        {
            var uri = new Uri(path);
            int width = DrawTool.writeableBitmap.PixelWidth;
            int height = DrawTool.writeableBitmap.PixelHeight;
            var bitmap = new BitmapImage(uri);

            int dpi = (int)bitmap.DpiX;
            var bitmapt = new TransformedBitmap(bitmap, new ScaleTransform((double)(width * dpi) / (bitmap.PixelWidth * 96), (double)(height * dpi) / (bitmap.PixelHeight * 96)));
            texture = new WriteableBitmap(bitmapt);
            //DrawTool.i.Source = texture;
            return bitmap;
        }
        public static Color GetTextureColor(int x, int y)
        {
            //https://gist.github.com/unitycoder/b9d328caad4c83ea88412f342c9a00ab
            x = (int)(x / (96 / texture.DpiX));
            y = (int)(y / (96 / texture.DpiY));
            if (y < 0 || y < 0 || x >= texture.PixelWidth || y >= texture.PixelHeight)
                return new Color();
            Color pix = new Color();
            unsafe
            {
                byte[] ColorData = { 0, 0, 0, 0 }; // NOTE, results comes in BGRA order! 
                IntPtr pBackBuffer = texture.BackBuffer;
                byte* pBuff = (byte*)pBackBuffer.ToPointer();
                var b = pBuff[4 * x + (y * texture.BackBufferStride)];
                var g = pBuff[4 * x + (y * texture.BackBufferStride) + 1];
                var r = pBuff[4 * x + (y * texture.BackBufferStride) + 2];
                var a = pBuff[4 * x + (y * texture.BackBufferStride) + 3];
                pix.R = r;
                pix.G = g;
                pix.B = b;
            }
            
            return pix;
        }

        public static BitmapSource SetMap(string path)
        {
            var uri = new Uri(path);
            int width = DrawTool.writeableBitmap.PixelWidth;
            int height = DrawTool.writeableBitmap.PixelHeight;
            var bitmap = new BitmapImage(uri);

            int dpi = (int)bitmap.DpiX;
            var bitmapt = new TransformedBitmap(bitmap, new ScaleTransform((double)(width * dpi) / (bitmap.PixelWidth * 96), (double)(height * dpi) / (bitmap.PixelHeight * 96)));
            map = new WriteableBitmap(bitmapt);
            return bitmap;
        }
        public static Vector3D GetMapNormal(int x, int y, Vector3D surf)
        {
            //https://gist.github.com/unitycoder/b9d328caad4c83ea88412f342c9a00ab
            x = (int)(x / (96 / map.DpiX));
            y = (int)(y / (96 / map.DpiY));
            if (y < 0 || y < 0 || x >= map.PixelWidth || y >= map.PixelHeight)
                return new Vector3D(1,0,0);
            Vector3D pix = new Vector3D();
            Vector3D p = new Vector3D();
            unsafe
            {
                byte[] ColorData = { 0, 0, 0, 0 }; // NOTE, results comes in BGRA order! 
                IntPtr pBackBuffer = map.BackBuffer;
                byte* pBuff = (byte*)pBackBuffer.ToPointer();
                var b = pBuff[4 * x + (y * map.BackBufferStride)];
                var g = pBuff[4 * x + (y * map.BackBufferStride) + 1];
                var r = pBuff[4 * x + (y * map.BackBufferStride) + 2];
                var a = pBuff[4 * x + (y * map.BackBufferStride) + 3];
                p.X = r;
                p.Y = g;
                p.Z = b;
                pix.X = (double)(((double)r /255)*2 - 1);
                pix.Y = (double)(((double)g / 255)*2 - 1);
                pix.Z = (double)(((double)b /255));
            }
            
                pix.Normalize();
            pix.Y *= -1;
            return CalculateNormal(surf, pix);
        }
        private static Vector3D CalculateNormal(Vector3D surface, Vector3D vrgb)
        {
            Vector3D B = surface == new Vector3D(0, 0, 1) ? new Vector3D(0, 1, 0) : Vector3D.CrossProduct(surface, new Vector3D(0, 0, 1));
            B.Normalize();
            Vector3D T = Vector3D.CrossProduct(B, surface);
            T.Normalize();

            Vector3D[] M = new Vector3D[] { T, B, surface };

            Vector3D N = new Vector3D(M[0].X * vrgb.X + M[1].X * vrgb.Y+ M[2].X * vrgb.Z, M[0].Y * vrgb.X + M[1].Y * vrgb.Y + M[2].Y * vrgb.Z, M[0].Z * vrgb.X + M[1].Z * vrgb.Y + M[2].Z * vrgb.Z);
            
            N.Normalize();
            return N;
        }
    }
}
