using System;
using System.Collections.Generic;
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

namespace Labypassword
{
    /// <summary>
    /// Interaction logic for PasswordData.xaml
    /// </summary>
    public partial class PasswordData : Page
    {
        public PasswordNode itempas;
        public MainP main;
        public PasswordData(sendpassword1 pp)
        {
            this.itempas = pp.pass;
            this.main = pp.m;
            this.DataContext = itempas.passwords;
            InitializeComponent();
            listaccounts.ItemsSource = itempas.passwords;
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listaccounts.ItemsSource);
            //PropertyGroupDescription groupDescription = new PropertyGroupDescription("Fletter");
            //view.GroupDescriptions.Add(groupDescription);
        }
        private void openAddPassword(object sender, RoutedEventArgs e)
        {
            this.addbuton.IsEnabled = false;
            Passworditem newit = new Passworditem();
            itempas.passwords.Add(newit);
            listaccounts.Focusable = false;
            MorePassword.Navigate(new AddPasword(new sendEditpassword(newit,this,itempas)));
            listaccounts.Items.Refresh();
            listaccounts.IsEnabled = false;
            
        }
        private void ShowDetail(object sender, MouseButtonEventArgs e)
        {
            MorePassword.Navigate(new ShowPassword(new sendEditpassword((Passworditem)(listaccounts.SelectedItem), this, itempas)));
        }
    }

    public class sendEditpassword
    {
        public Passworditem pasit;
        public PasswordData passwindow;
        public PasswordNode list;
        public sendEditpassword(Passworditem p, PasswordData d, PasswordNode node)
        {
            pasit = p;
            passwindow = d;
            list = node;            
        }
    }
    public class passnameconv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string tmp = (string)value;
            var tmp1 = PasswordStrengthUtils.CalculatePasswordStrength(tmp);
            int x = (int)PasswordStrengthUtils.CalculatePasswordStrength(tmp);

            if ((int)tmp1 == 0)
                return "";
            else
                return tmp1.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class FirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string s = value as string;
            if (s != null && s.Length > 0)
                return s.Substring(0, 1);
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
