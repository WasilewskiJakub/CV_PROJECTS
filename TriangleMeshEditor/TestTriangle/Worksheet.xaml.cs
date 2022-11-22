using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using TestTriangle.OBJReader;
using TestTriangle.Extensions;
using TestTriangle.StaticProperty;

namespace TestTriangle
{
    /// <summary>
    /// Interaction logic for Worksheet.xaml
    /// </summary>
    public partial class Worksheet : Page
    {
        private MainWindow mainwindow;
        private OBJFileReader obj;
        private ChosenLayout layout;
        private EnvironmentPage envpage;
        private DetailsPage detpage;
        private CanvasPage canv_page;
        private InstructionPage instpage;
        private Instruction instleftpage;
        public Worksheet(MainWindow main, OBJFileReader RenderOBJ)
        {
            OBJProperty.SetDefColors();
            Light.ResetLight();
            this.obj = RenderOBJ;
            this.mainwindow = main;
            DrawTool.readedItem = this.obj.Readed_Object;
            InitializeComponent();
            DrawTool.fpscounter = this.FPSCounter;
            this.FilNameLabel.Content = obj.ToString();
            OBJProperty.Clear();
            DrawTool.ws = this;
            this.layout = new ChosenLayout(this.envbord, this.envimg);
            this.canv_page = new CanvasPage(this);
            this.envpage = new EnvironmentPage();
            
            this.instpage = new InstructionPage();
            this.instleftpage = new Instruction();
            this.MainBoard.Navigate(this.canv_page);
            this.Extension.Navigate(this.envpage);
            this.detpage = new DetailsPage();
        }
        private void Exit_Worksheet(object sender, MouseEventArgs e)
        {
            OBJProperty.Clear();
            this.mainwindow.Back.Navigate(new LoadFile(this.mainwindow));
            this.mainwindow.Back.NavigationService.RemoveBackEntry();
            NormalMapReader.Reset();
            AnimationThreading.CancelAnimation();
        }
        private void ChooseEnvLight(object sender, MouseEventArgs e)
        {
            if (this.layout.Equals(new ChosenLayout(this.envbord, this.envimg)))
                return;
            this.layout.SetNewLayout(this.envbord, this.envimg);
            this.Extension.Navigate(this.envpage);
            this.Extension.NavigationService.RemoveBackEntry();
            this.MainBoard.Navigate(this.canv_page);
            this.MainBoard.NavigationService.RemoveBackEntry();
        }
        private void DetailsChoose(object sender, MouseEventArgs e)
        {
            if (this.layout.Equals(new ChosenLayout(this.detbord, this.detimg)))
                return;
            this.layout.SetNewLayout(this.detbord, this.detimg);
            this.Extension.Navigate(this.detpage);
            this.Extension.NavigationService.RemoveBackEntry();
            this.MainBoard.Navigate(this.canv_page);
            this.MainBoard.NavigationService.RemoveBackEntry();
        }
        private void InstChoose(object sender, MouseEventArgs e)
        {
            if (this.layout.Equals(new ChosenLayout(this.instbord, this.instimg)))
                return;
            this.layout.SetNewLayout(this.instbord, this.instimg);
            this.Extension.Navigate(this.instleftpage);
            this.Extension.NavigationService.RemoveBackEntry();
            this.MainBoard.Navigate(this.instpage);
            this.MainBoard.NavigationService.RemoveBackEntry();
        }
    }
    public class ChosenLayout
    {
        public Border border;
        public Image image;

        private int offwidth = 25;
        private int onwidth = 25;
        public override bool Equals(object obj)
        {
            return ((ChosenLayout)obj).border == this.border && ((ChosenLayout)obj).image == this.image;
        }
        public ChosenLayout(Border b, Image i)
        {
            this.border = b;
            this.image = i;
        }
        private void OFFPrevious()
        {
            this.border.BorderThickness = new Thickness(0, 0, 0, 0);
            this.image.Width = offwidth;
        }
        private void ONCurrent()
        {
            this.border.BorderThickness = new Thickness(0, 0, 0, 2);
            this.image.Width = onwidth;
        }
        public void SetNewLayout(Border b, Image i)
        {
            OFFPrevious();
            this.image = i;
            this.border = b;
            ONCurrent();
        }
    }
}
