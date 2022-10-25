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
using System.IO;
using Microsoft.Win32;
using System.Globalization;

namespace Labypassword
{
    /// <summary>
    /// Interaction logic for AddPasword.xaml
    /// </summary>
    public partial class AddPasword : UserControl
    {
        Passworditem pass;
        PasswordData prevframe;
        PasswordNode node;
        public AddPasword(sendEditpassword pp)
        {
            pass = pp.pasit;
            prevframe = pp.passwindow;
            node = pp.list;
            this.DataContext = new { info = pass };
            InitializeComponent();
            ShowIcon.Source = pass.icon;
            namebox.Text = pass.Name;
            mailbox.Text = pass.Email;
            loginbox.Text = pass.Login;
            webbox.Text = pass.Website;
            notebox.Text = pass.Notes;
            passbox.Text = pass.Password;

        }
        private void SelectIcon(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    pass.icon = new BitmapImage(new Uri(openFileDialog.FileName));
                    ShowIcon.Source = pass.icon;
                    Resolution.Text = $"Resolution: {pass.icon.PixelWidth}x{pass.icon.PixelHeight}";
                    DPI.Text = $"Dpi: {pass.icon.DpiX}x{pass.icon.DpiY}";
                    Format.Text = $"Format: {pass.icon.Format}";
                }
                catch(Exception p)
                {
                    MessageBox.Show("Can't open File choose image file", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            pass.Name = namebox.Text;
            pass.Email = mailbox.Text;
            pass.Login = loginbox.Text;
            pass.Website = webbox.Text;
            pass.Notes = notebox.Text;
            pass.lastedit = DateTime.Now;
            pass.Password = passbox.Text;
            pass.setfirst();
            prevframe.listaccounts.Items.Refresh();
            prevframe.addbuton.IsEnabled = true;
            prevframe.listaccounts.IsEnabled = true;
            prevframe.MorePassword.Navigate(new ShowPassword(new sendEditpassword(pass,prevframe,node)));
        }
            private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            prevframe.addbuton.IsEnabled = true;
            prevframe.listaccounts.IsEnabled = true;
            prevframe.MorePassword.Navigate(new RBlank());
        }
    }
    public class Passconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tmp = (string)value;
            int x = (int)PasswordStrengthUtils.CalculatePasswordStrength(tmp);
            return x;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PassconverterColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tmp = (string)value;
            int x = (int)PasswordStrengthUtils.CalculatePasswordStrength(tmp);
            switch(x)
            {
                case 0:
                    return Brushes.Black;
                case 1:
                    return Brushes.Red;
                case 2:
                    return Brushes.DarkOrange;
                case 3:
                    return Brushes.Orange;
                case 4:
                    return Brushes.LightGreen;
                case 5:
                    return Brushes.Green;
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
