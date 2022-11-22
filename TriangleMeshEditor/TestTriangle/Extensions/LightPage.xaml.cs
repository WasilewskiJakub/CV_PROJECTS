using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
    /// Logika interakcji dla klasy LightPage.xaml
    /// </summary>
    public partial class LightPage : Page
    {
        public LightPage()
        {
            InitializeComponent();
            this.LightColor.SelectedColor = Light.color;
        }
        private void SetKdLight(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Light.kd = (double)this.KdSlider.Value;
            var watch = Stopwatch.StartNew();
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void SetKsLight(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Light.ks = (double)this.KsSlider.Value;
            var watch = Stopwatch.StartNew();
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void SetmLight(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Light.m = (double)this.mvalSlider.Value;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            Light.color = this.LightColor.SelectedColor;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
    }
}
