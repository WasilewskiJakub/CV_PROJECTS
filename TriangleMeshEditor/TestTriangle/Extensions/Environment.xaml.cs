using Microsoft.Win32;
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
using TestTriangle.OBJReader;

namespace TestTriangle.Extensions
{
    /// <summary>
    /// Logika interakcji dla klasy Environment.xaml
    /// </summary>
    public partial class EnvironmentPage : Page
    {
        public ChosenLayout layout;
        private Page radial;
        private Page XYZ;
        private Page anim;
        public ChosenLayout details;
        public Page objcolor;
        public Page lightpage;
        public EnvironmentPage()
        {
            InitializeComponent();
            this.details = new ChosenLayout(this.objbord, this.objimg);
            this.layout = new ChosenLayout(this.radbord, this.radimg);
            this.objcolor = new OBJColors();
            this.lightpage = new LightPage();
            this.radial = new RadialMove();
            this.XYZ = new XYZMove();
            this.anim = new AnimMove();
            this.LightFrame.Navigate(radial);
            this.DetailFrame.Navigate(this.objcolor);
        }

        private void ChooseRadial(object sender, MouseEventArgs e)
        {
            if (this.layout.Equals(new ChosenLayout(this.radbord, this.radimg)))
                return;
            this.layout.SetNewLayout(this.radbord, this.radimg);
            this.LightFrame.Navigate(this.radial);
            this.LightFrame.NavigationService.RemoveBackEntry();
        }
        private void ChooseXYZ(object sender, MouseEventArgs e)
        {
            if (this.layout.Equals(new ChosenLayout(this.xyzbord, this.xyzimg)))
                return;
            this.layout.SetNewLayout(this.xyzbord, this.xyzimg);
            this.LightFrame.Navigate(this.XYZ);
            this.LightFrame.NavigationService.RemoveBackEntry();
        }
        private void ChooseAnim(object sender, MouseEventArgs e)
        {
            if (this.layout.Equals(new ChosenLayout(this.animbord, this.animimg)))
                return;
            this.layout.SetNewLayout(this.animbord, this.animimg);
            this.LightFrame.Navigate(this.anim);
            this.LightFrame.NavigationService.RemoveBackEntry();
        }
        private void Chooseobj(object sender, MouseEventArgs e)
        {
            if (this.details.Equals(new ChosenLayout(this.objbord, this.objimg)))
                return;
            this.details.SetNewLayout(this.objbord, this.objimg);
            this.DetailFrame.Navigate(this.objcolor);
            this.DetailFrame.NavigationService.RemoveBackEntry();
        }
        private void Choosebackground(object sender, MouseEventArgs e)
        {
            if (this.details.Equals(new ChosenLayout(this.backgroundbord, this.backgroundimg)))
                return;
            this.details.SetNewLayout(this.backgroundbord, this.backgroundimg);
            this.DetailFrame.Navigate(this.lightpage);
            this.DetailFrame.NavigationService.RemoveBackEntry();
        }

        private void LoadTexture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            //dialog.Filter = "3D Object|*.OBJ";
            //dialog.Title = "Choose .OBJ File";

            if (dialog.ShowDialog() == true)
            {
                this.PreviewTexture.Source = NormalMapReader.SetTextrure(dialog.FileName);
                this.setextbut.IsEnabled = true;
                //NormalMapReader.GetTextureColor(2, 2);
            }
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void SetText(object sender, RoutedEventArgs e)
        {
            NormalMapReader.settext = true;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void disabletext(object sender, RoutedEventArgs e)
        {
            NormalMapReader.settext = false;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        //MAP
        private void LoadMap_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            //dialog.Filter = "3D Object|*.OBJ";
            //dialog.Title = "Choose .OBJ File";

            if (dialog.ShowDialog() == true)
            {
                this.PreviewMap.Source = NormalMapReader.SetMap(dialog.FileName);
                this.setmapbut.IsEnabled = true;
            }
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void SetMap(object sender, RoutedEventArgs e)
        {
            NormalMapReader.setmap = true;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
        private void disableMap(object sender, RoutedEventArgs e)
        {
            NormalMapReader.setmap = false;
            if (AnimationThreading.work == null)
                DrawTool.Repaint();
        }
    }
    public class ChosenLayout
    {
        public Border border;
        public Image image;
        public override bool Equals(object obj)
        {
            return ((ChosenLayout)obj).border == this.border && ((ChosenLayout)obj).image == this.image;
        }
        public ChosenLayout(Border b, Image i)
        {
            this.border = b;
            this.image = i;
        }
        protected void OFFPrevious()
        {
            this.border.BorderThickness = new Thickness(0, 0, 0, 0);
        }
        protected void ONCurrent()
        {
            this.border.BorderThickness = new Thickness(0, 0, 0, 1);
        }
        virtual public void SetNewLayout(Border b, Image i)
        {
            OFFPrevious();
            this.image = i;
            this.border = b;
            ONCurrent();
        }
    }
}
