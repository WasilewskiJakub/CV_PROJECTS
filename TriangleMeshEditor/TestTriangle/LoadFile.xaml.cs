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
using TestTriangle.FileHistory;
using System.Globalization;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using TestTriangle.OBJReader;
using Path = System.IO.Path;

namespace TestTriangle
{
    /// <summary>
    /// Interaction logic for LoadFile.xaml
    /// </summary>
    public partial class LoadFile : Page
    {
        //private string FilePath;
        private RecentProjects list;
        private Thread child_generate;
        private MainWindow mainwindow;
        public LoadFile(MainWindow main)
        {
            this.mainwindow = main;
            Serializators.SetPath = $"{Environment.CurrentDirectory}\\Data\\RecentPaths.txt";
            this.list = Serializators.Deserializate_Recent_Projects();
            InitializeComponent();
            RecentList.ItemsSource = list.Details;
        }
        private void TakeNewProject(object sender, MouseEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            dialog.Filter = "3D Object|*.OBJ";
            dialog.Title = "Choose .OBJ File";

            if (dialog.ShowDialog() == true)
            {
                FileInfo file_info = new FileInfo(dialog.FileName);
                var tmp = file_info.Attributes;
                var newitem = new ProjectData(file_info.Name, dialog.FileName, DateTime.Now);
                if (this.list.Details.Exists((x) => { return x.FileName == newitem.FileName;})){
                    this.list.Details.RemoveAll((x) => { return x.FileName == newitem.FileName;});
                }
                this.list.Details.Insert(0, newitem);
                this.RecentList.SelectedItem = newitem;
                Serializators.Serializate_Recent_Projects(this.list);
                this.RecentList.Items.Refresh();
                SetInfoAoutFile(dialog.FileName);
            }
        }

        private void SetInfoAoutFile(string path)
        {
            try
            {
                FileInfo file_info = new FileInfo(path);
                (string s, string v) size = ((float)file_info.Length > 1000000? Math.Round((float)file_info.Length/1000000,2).ToString(): Math.Round((float)file_info.Length/1000,2).ToString(), (float)file_info.Length > 1000000 ? "MB":"KB");
                string txt = $"File Details:\n" +
                $"Name: {file_info.Name}\n" +
                $"Length: {size.s} {size.v}\n" +
                $"Creation time: {file_info.CreationTime.ToShortDateString()}\n" +
                $"Last edit: {file_info.LastWriteTime.ToShortDateString()}\n";
                FileDetailsBox.Text = txt;
                FileNameLabel.Text = file_info.Name;
            }
            catch(Exception)
            {
                throw new FileException(path);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.list.Details.Clear();
            Serializators.Serializate_Recent_Projects(this.list);
            this.RecentList.Items.Refresh();
            FileNameLabel.Text = "Choose File ->";
            FileDetailsBox.Text = "Choose File to see details!";
        }

        private void SelectNewItem(object sender, SelectionChangedEventArgs e)
        {
            if(RecentList.SelectedItem!= null)
            {
                try
                {
                    SetInfoAoutFile(((ProjectData)RecentList.SelectedItem).FilePath);

                }
                catch (Exception a)
                {
                    this.list.Details.RemoveAll((x) => x.FilePath == ((ProjectData)RecentList.SelectedItem).FilePath);
                    this.RecentList.Items.Refresh();
                    this.RecentList.SelectedItem = null;
                    FileNameLabel.Text = "Choose File ->";
                    FileDetailsBox.Text = "Choose File to see details!";
                    Serializators.Serializate_Recent_Projects(this.list);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.RecentList.SelectedItem != null)
            {
                var readed = new OBJFileReader(((ProjectData)this.RecentList.SelectedItem).FilePath);
                readed.RenderObject();
                this.mainwindow.Back.Navigate(new Worksheet(this.mainwindow,readed));
                this.mainwindow.Back.NavigationService.RemoveBackEntry();
            }
        }
    }
    class FileException : Exception
    {
        public FileException(string path)
        {
            MessageBox.Show($"Could not find file:\n{path}\n","Missing File" , MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime tt = (DateTime)value;
            return $"{tt.Day}.{tt.Month}.{tt.Year}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
