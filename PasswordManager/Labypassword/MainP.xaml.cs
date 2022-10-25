
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace Labypassword
{
    /// <summary>
    /// Interaction logic for MainP.xaml
    /// </summary>
    public partial class MainP : UserControl
    {
        MainWindow window;
        FileExplorer filetree;
        public MainP(MainWindow window)
        {
            this.window = window;
            filetree = new FileExplorer();
            DataContext = filetree;
            InitializeComponent();
        }
        public void LogOutClick(object sender, RoutedEventArgs args)
        {
            window.Content = window.PasswordPage;
        }

        private void addDir2Dir(object sender, RoutedEventArgs e)
        {
            ((FolderNode)manager.SelectedItem).Children.Add(new FolderNode());
                //dir.Children.Add(new FolderNode());
        }
        private void addpass2Dir(object sender, RoutedEventArgs e)
        {
            ((FolderNode)manager.SelectedItem).Children.Add(new PasswordNode());
            //dir.Children.Add(new FolderNode());
        }
        private void addIMG2Dir(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage tmp = new BitmapImage(new Uri(openFileDialog.FileName));
                    ((FolderNode)manager.SelectedItem).Children.Add(new IMGNode(tmp));
                }
                catch (Exception p)
                {
                    MessageBox.Show("Can't open File choose image file", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        TreeViewItem workingitem;
        private void removeobj(object sender, RoutedEventArgs e)
        {
            var torem = ((INode)manager.SelectedItem);
            ItemsControl parent = GetSelectedTreeViewItemParent(workingitem);
            TreeViewItem treeitem = parent as TreeViewItem;
            if(treeitem == null)
            {
                filetree.TreeData.Remove(torem);
                return;
            }
            treeitem.IsSelected = true;
            ((INodeWithChildren)(manager.SelectedItem)).Children.Remove(torem);
            treeitem.IsExpanded = true;
        }
        private void Rename(object sender, RoutedEventArgs e)
        {
            var tmp = workingitem.Header;
            var tbox = new TextBox();
            workingitem.Header = tbox;
            tbox.TextChanged += new TextChangedEventHandler(txt_TextChanged);
        }
        string newname = "";
        private void txt_TextChanged(object sender, EventArgs e)
        {
            
            ((INode)manager.SelectedItem).Name = (sender as TextBox).Text;
        }
        public ItemsControl GetSelectedTreeViewItemParent(TreeViewItem item)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as ItemsControl;
        }
        
        private void OpenDetails(object sender, MouseButtonEventArgs e)
        {
            var tt = ((TreeViewItem)sender).IsSelected = true;
            var typ = manager.SelectedItem.GetType();
            switch(typ.Name)
            {
                case "FolderNode":
                    //x = 0;
                    frameforinfo.Navigate(new DirData((FolderNode)manager.SelectedItem));
                    break;
                case "PasswordNode":
                    frameforinfo.Navigate(new PasswordData(new sendpassword1((PasswordNode)manager.SelectedItem, this)));
                    break;
                case "IMGNode":
                    frameforinfo.Navigate(new ImageDetail((IMGNode)manager.SelectedItem));
                    break;
            }
            e.Handled = true;
        }
        private void RighClickOnItem(object sender, MouseButtonEventArgs e)
        {
            //var tmp = (TextBox)sender;
            ((TreeViewItem)sender).IsSelected = true;
            workingitem = (TreeViewItem)sender;
            e.Handled = true;
        }
        private void AddDirectory(object sender, RoutedEventArgs e)
        {
            filetree.TreeData.Add(new FolderNode());
        }
        private void AddPassword(object sender, RoutedEventArgs e)
        {
            filetree.TreeData.Add(new PasswordNode());
        }
        private void AddImage(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage tmp = new BitmapImage(new Uri(openFileDialog.FileName));
                    filetree.TreeData.Add(new IMGNode(tmp));
                }
                catch (Exception p)
                {
                    MessageBox.Show("Can't open File choose image file", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
    }
    public class sendpassword1
    {
        public PasswordNode pass;
        public MainP m;
        public sendpassword1(PasswordNode n,MainP m)
        {
            this.m = m;
            this.pass = n;
        }
    }
    public interface INode
    {
        bool Dir { get; set; }
        string FullPath { get; }
        string Name { get; set; }
    }

    public interface INodeWithChildren : INode
    {
        ObservableCollection<INode> Children { get; }
    }


    public class FolderNode : INodeWithChildren
    {
        public ObservableCollection<INode> Children { get; set; }
        public string Name { get; set; }
        public string FullPath { get; set; }
        public bool Dir { get; set; }

        //initialize default values
        public FolderNode()
        {
            Name = "New Directory";
            Children = new ObservableCollection<INode>();
            Dir = true;
        }
    }

    public enum Aplhabet
    {
        A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,R,S,T,U,W,X,Y,Z,OTHER
    }

    public class Passworditem
    {
        public Aplhabet Fletter { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
        public DateTime create { get; set; }
        public DateTime lastedit { get; set; }
        public PasswordStrength strength { get; set; }
        public Passworditem()
        {
            Name = "Account Name";
            Email = "";
            Login = "";
            this.Password = "";
            this.Website = "";
            this.Notes = "";
            create = DateTime.Now;
            lastedit = create;
            this.strength = PasswordStrengthUtils.CalculatePasswordStrength(this.Password);
        }
        public void setfirst()
        {
            if(Name.Length ==0)
            {
                Fletter = Aplhabet.OTHER;
                return;
            }
            else
            {
                string tmp = Name.ToUpper();
                int xx = (tmp[0] - 'A');
                if (xx < 65 || xx > 90)
                    Fletter = Aplhabet.OTHER;
                else
                Fletter = (Aplhabet)(xx);
            }
        }

        public BitmapImage icon { get; set; }
    }
    public class PasswordNode : INode
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public bool Dir { get; set; }

        public ObservableCollection<Passworditem> passwords { get; set; }
        public PasswordNode()
        {
            passwords = new ObservableCollection<Passworditem>();
            Name = "New Password";
            Dir = false;
        }
    }
    public class IMGNode : INode
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public bool Dir { get; set; }
        public BitmapImage image { get; set; }
        public IMGNode(BitmapImage tt)
        {
            this.image = tt;
            Name = "New Image";
            Dir = false;
        }

    }
    public class FileExplorer : INotifyPropertyChanged
    {
        public FileExplorer()
        {
            //initialize and add
            m_folders = new ObservableCollection<INode>();
        }

        private ObservableCollection<INode> m_folders;
        public ObservableCollection<INode> TreeData
        {
            get { return m_folders; }
            set
            {
                m_folders = value;
                NotifiyPropertyChanged("Folders");
            }
        }

        void NotifiyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class ContextMenuConverter : IValueConverter
    {
        public ContextMenu EmptySpace { get; set; }
        public ContextMenu FolderMenu { get; set; }
        public ContextMenu PasswordMenu { get; set; }
        public ContextMenu ImgMenu { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return EmptySpace;
            if (value != null)
            {
                Type type = value.GetType();
                if (type == typeof(PasswordNode))
                    return PasswordMenu;
                else if (type == typeof(FolderNode))
                    return FolderMenu;
                else if (type == typeof(IMGNode))
                    return ImgMenu;
                else
                    return EmptySpace;
            }
            return null;
  
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
