using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace TestTriangle.Extensions
{
    /// <summary>
    /// Logika interakcji dla klasy Details.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            InitializeComponent();
            trianglecount.Content += $" | {DrawTool.readedItem.f.Count}";
            Vertexcount.Content += $" | {DrawTool.readedItem.v.Count}";
            Vertsnormalcount.Content += $" | {DrawTool.readedItem.v.Count}";
            Facecount.Content += $" | {DrawTool.readedItem.f.Count}";
        }
        private void HideTriangleMesh(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintTriangle = false;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void ShowTriangleMesh(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintTriangle = true;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void HideVertex(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintVertex = false;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void ShowVertex(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintVertex = true;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void HideFacesNormal(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintFacesNormal = false;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void ShowFacesNormal(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintFacesNormal = true;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void HideVertsNormal(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintVertsNormal = false;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
        private void ShowVertsNormal(object sender, RoutedEventArgs e)
        {
            OBJProperty.PrintVertsNormal = true;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
            //var watch = Stopwatch.StartNew();
            //DrawTool.ClearImage();
            //DrawTool.readedItem.Paint();
            //watch.Stop();
            //var time = watch.ElapsedMilliseconds;
            //DrawTool.fpscounter.Content = $"FPS {Math.Round((double)(1000 / time), 0)}";
        }
    }
}
