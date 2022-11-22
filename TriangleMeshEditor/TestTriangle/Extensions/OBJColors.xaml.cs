using System;
using System.Collections.Generic;
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
using ColorPicker.Models;
using System.Globalization;

namespace TestTriangle.Extensions
{
    /// <summary>
    /// Logika interakcji dla klasy OBJColors.xaml
    /// </summary>
    public partial class OBJColors : Page
    {
        public OBJColors()
        {
            InitializeComponent();
            this.ObjectColor.SelectedColor = OBJProperty.ObjectColor;
        }
        private void SetVertexNormalLength(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OBJProperty.VertsNormalLength = (float)this.VertNormalSize.Value;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void SetFaceNormalLength(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OBJProperty.FaceNormalLength = (float)this.FaceNormalSize.Value;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }

        private void ResetNormals_Click(object sender, RoutedEventArgs e)
        {
            OBJProperty.ResetNormals();
            this.FaceNormalSize.Value = OBJProperty.FaceNormalLength;
            this.VertNormalSize.Value = OBJProperty.VertsNormalLength;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }

        private void ResetZoom_Click(object sender, RoutedEventArgs e)
        {
            OBJProperty.zoom = 1;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }

        private void ChangeColorStyle(object sender, SelectionChangedEventArgs e)
        {
            if (this.colstyle.SelectedIndex == 0)
                DrawTool.color_style = ColorStyle.VertexInterpolation;
            if (this.colstyle.SelectedIndex == 1)
                DrawTool.color_style = ColorStyle.VectorInterpolation;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            OBJProperty.ObjectColor = this.ObjectColor.SelectedColor;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
    }

    public class SliderValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Math.Round((double)value, 2).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
