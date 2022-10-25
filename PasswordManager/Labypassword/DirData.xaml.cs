﻿using System;
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
    /// Interaction logic for DirData.xaml
    /// </summary>
    public partial class DirData : UserControl
    {
        FolderNode foldojob;
        public DirData( FolderNode ff)
        {
            foldojob = ff;
            this.DataContext = ff;
            InitializeComponent();
        }
    }
    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{((FolderNode)value).Name}({((FolderNode)value).Children.Count})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
