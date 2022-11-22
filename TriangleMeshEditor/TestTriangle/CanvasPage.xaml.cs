using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTriangle.StaticProperty;
using TestTriangle.Classes;
using System.Diagnostics;
using TestTriangle.Extensions;

namespace TestTriangle
{
    /// <summary>
    /// Logika interakcji dla klasy CanvasPage.xaml
    /// </summary>
    public partial class CanvasPage : Page
    {
        public Worksheet wind;
        public bool EnableMove;
        CursorPos curr_pos;
        public CanvasPage(Worksheet wind)
        {
            InitializeComponent();
            DrawTool.i = this.Image_To_Draw;
            this.wind = wind;
            DrawTool.page = this;
            DrawTool.MakeBitmap();
            DrawTool.readedItem.Paint();
            BitmapHelper.pixelcolor = new Color[DrawTool.writeableBitmap.PixelWidth];
        }
        private void LeftButtonClick(object sender, MouseEventArgs e)
        {
            curr_pos = new CursorPos((int)Mouse.GetPosition(this).X, (int)Mouse.GetPosition(this).Y);
            EnableMove = true;
        }
        private void MoveObj(object sender, MouseEventArgs e)
        {
            if (EnableMove && AnimationThreading.work==null)
            {
                DrawTool.readedItem.AroundYaxis(Trigonometry.ForMove((Mouse.GetPosition(Canvas_To_Draw).X - curr_pos.X) / 600 * 180));
                DrawTool.Repaint();
            }
        }

        private void StopMoving(object sender, MouseEventArgs e)
        {
            curr_pos = null;
            EnableMove = false;
            if(AnimationThreading.work == null)
                DrawTool.readedItem.SetVertsxyz();
        }

        private void ZoomFigure(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta > 0) //upside
            {
                if (OBJProperty.zoom < 2)
                    OBJProperty.zoom += (double)0.1; 
            }
            if(e.Delta<0)
            {
                if (OBJProperty.zoom > 0.3)
                    OBJProperty.zoom -= (double)0.1;
            }
            DrawTool.Repaint();
        }


    }
    class CursorPos
    {
        public int X;
        public int Y;
        public CursorPos(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
