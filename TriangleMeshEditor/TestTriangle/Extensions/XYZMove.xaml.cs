using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TestTriangle.Extensions
{
    /// <summary>
    /// Logika interakcji dla klasy XYZMove.xaml
    /// </summary>
    public partial class XYZMove : Page
    {
        public XYZMove()
        {
            InitializeComponent();
        }
        private void Xposition(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Light.possition.x = (double)this.Xpos.Value;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void Yposition(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Light.possition.y = -1*(double)this.Ypos.Value;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void Zposition(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Light.possition.z = (double)this.Zpos.Value;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Light.possition.x = this.Xpos.Value = 0;
            Light.possition.y = this.Ypos.Value = 0;
            Light.possition.z = this.Zpos.Value = 1.1;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
    }
}
