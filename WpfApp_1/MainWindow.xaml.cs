using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItemOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var model = new MainModel();
            DataContext = model;
            model.LoadFiles();
        }            

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lst = sender as ListBox;
            string str = lst.SelectedItem as string;
            if (str != null)
            {
                var bi = new BitmapImage(new Uri(str));
                BigImage.Source = bi;
            }
        }

        private void ButtonRight_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
                listBox.SelectedIndex += 1;
            else
                listBox.SelectedIndex = 0;
        }

        private void ButtonLeft_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex != -1)
                listBox.SelectedIndex -= 1;
            else
                listBox.SelectedIndex = 0;
        }

    }
}
