using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TestTriangle.Extensions;

namespace TestTriangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Back.Navigate(new LoadFile(this));
            DrawTool.main_wnd = this;
        }
        void OffActiveThreads(object sender, CancelEventArgs e)
        {
            Environment.Exit(0);
            //if (AnimationThreading.work != null)
            //    AnimationThreading.CancelAnimation();
        }
    }
}
