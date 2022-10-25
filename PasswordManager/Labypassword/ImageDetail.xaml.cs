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

namespace Labypassword
{
    /// <summary>
    /// Interaction logic for ImageDetail.xaml
    /// </summary>
    public partial class ImageDetail : UserControl
    {
        IMGNode img;
        public ImageDetail(IMGNode img)
        {
            this.img = img;
            InitializeComponent();
            imgshow.Source = img.image;
        }
        private void Save_Image(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document";
            dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (dlg.ShowDialog() == true)
            {
                var encoder = new JpegBitmapEncoder(); // Or PngBitmapEncoder, or whichever encoder you want
                encoder.Frames.Add(BitmapFrame.Create(img.image));
                using (var stream = dlg.OpenFile())
                {
                    encoder.Save(stream);
                }
            }
        }
    }
}
