using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;
using System.Threading;
using System.Diagnostics;
using TestTriangle.Classes;

namespace TestTriangle
{
    //https://learn.microsoft.com/en-us/dotnet/api/system.windows.media.imaging.writeablebitmap?view=windowsdesktop-6.0&fbclid=IwAR2fE0qECWVJG9XYi_dNiPkuVZnbBGgqBpgqdOHp8YuszoTGdskLvRNG67c --- Draw Pixel!

    enum ColorStyle
    {
        VertexInterpolation, VectorInterpolation
    };

    static class DrawTool
    {
        static public OBJItem readedItem;
        static public WriteableBitmap writeableBitmap;
        static public Image i;
        static public CanvasPage page;
        static public MainWindow main_wnd;
        static public Worksheet ws;
        static public Label fpscounter;
        static int dpi = 96;
        static public ColorStyle color_style;
        static public Color back = Color.FromRgb(60, 60, 60);
        public static void MakeBitmap()
        {
            DrawTool.writeableBitmap = new WriteableBitmap((int)page.ActualWidth != 0 ? (int)page.ActualWidth : 1045, (int)page.ActualHeight != 0 ? (int)page.ActualHeight : 641, dpi, dpi, PixelFormats.Bgr32, null);
            DrawTool.i.Source = DrawTool.writeableBitmap;
            ClearImage();
        }
        public static async void Repaint()
        {

            Task.Run(new Action(async () =>
           {
               var watch = Stopwatch.StartNew();
               await DrawTool.page.Dispatcher.BeginInvoke(new Action(() =>
               {
                   DrawTool.writeableBitmap.Lock();
                   DrawTool.ClearImage();
                   DrawTool.readedItem.Paint();
                   DrawTool.writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, DrawTool.writeableBitmap.PixelWidth, DrawTool.writeableBitmap.PixelHeight));
                   DrawTool.writeableBitmap.Unlock();
               }));
               watch.Stop();
               var time = watch.ElapsedMilliseconds;
               await page.Dispatcher.BeginInvoke(new Action(() => DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}"));
           }));

        }
        public static void ClearImage()
        {
            writeableBitmap.Lock();

            unsafe
            {
                IntPtr pBackBuffer = writeableBitmap.BackBuffer;
                // Compute the pixel's color.
                int color_data = back.R << 16; // R
                color_data |= back.G << 8;   // G
                color_data |= back.B << 0;   // B
                for (int i = 0; i < writeableBitmap.PixelWidth; i++)
                    for (int j = 0; j < writeableBitmap.PixelHeight; j++)
                    {
                        *((int*)pBackBuffer) = color_data;
                        pBackBuffer += 4;
                    }
            }
            writeableBitmap.AddDirtyRect(new Int32Rect(0, 0, writeableBitmap.PixelWidth, writeableBitmap.PixelHeight));
            writeableBitmap.Unlock();
        }
        static public void DrawPixel(Point P, Color c)
        {
            int column = (int)P.X;
            int row = (int)P.Y;

            if (column < 0 || row < 0 || column >= writeableBitmap.PixelWidth || row >= writeableBitmap.PixelHeight)
                return;
            unsafe
            {
                IntPtr pBackBuffer = writeableBitmap.BackBuffer;
                pBackBuffer += row * writeableBitmap.BackBufferStride;
                pBackBuffer += column * 4;
                // Compute the pixel's color.
                int color_data = c.R << 16; // R
                color_data |= c.G << 8;   // G
                color_data |= c.B << 0;   // B
                *((int*)pBackBuffer) = color_data;
            }
        }
        static public void Bresenham(Point v1, Point v2, Color c)
        {
            //https://pl.wikipedia.org/wiki/Algorytm_Bresenhama
            int d, dx, dy, ai, bi, xi, yi;
            int x = (int)v1.X, y = (int)v1.Y;
            int i = 0;
            if (v1.X < v2.X)
            {
                xi = 1;
                dx = (int)v2.X - (int)v1.X;
            }
            else
            {
                xi = -1;
                dx = (int)v1.X - (int)v2.X;
            }
            if (v1.Y < v2.Y)
            {
                yi = 1;
                dy = (int)v2.Y - (int)v1.Y;
            }
            else
            {
                yi = -1;
                dy = (int)v1.Y - (int)v2.Y;
            }
            DrawPixel(new Point(x, y), c);
            if (dx > dy)
            {
                ai = (dy - dx) * 2;
                bi = dy * 2;
                d = bi - dx;
                while (x != (int)v2.X)
                {
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        x += xi;
                    }
                    DrawPixel(new Point(x, y), c);
                }
            }
            else
            {
                ai = (dx - dy) * 2;
                bi = dx * 2;
                d = bi - dy;
                while (y != (int)v2.Y)
                {
                    if (d >= 0)
                    {
                        x += xi;
                        y += yi;
                        d += ai;
                    }
                    else
                    {
                        d += bi;
                        y += yi;
                    }
                    DrawPixel(new Point(x, y), c);
                }
            }
        }
    }
}
