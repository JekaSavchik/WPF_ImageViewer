using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Runtime.CompilerServices;
using System.Windows.Forms;


namespace WpfApp_1
{
    public partial class MainWindow : Window
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        //private void MenuItemNewWin_Click(object sender, RoutedEventArgs e)
        //{
        //    Win win = new Win(listBox.SelectedItem);
        //    win.Owner = this;
        //    win.Show();
        //}
        #region slideshow
        private void MenuItemSlideShowStart_Click(object sender, RoutedEventArgs e) => timer.Start();
        private void MenuItemSlideShowStop_Click(object sender, RoutedEventArgs e) => timer.Stop();

        void timer_Tick(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == listBox.Items.Count - 1)
                timer.Stop();
            else if (listBox.SelectedIndex != -1)
                listBox.SelectedIndex += 1;
            else
                listBox.SelectedIndex = 0;
        }
        #endregion
        #region Syle
        private void MenuItemLightStyle_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("LightThem.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = System.Windows.Application.LoadComponent(uri) as ResourceDictionary;
            System.Windows.Application.Current.Resources.Clear();
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void DarkStyleButton_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("DarkThem.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = System.Windows.Application.LoadComponent(uri) as ResourceDictionary;
            System.Windows.Application.Current.Resources.Clear();
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        #endregion
    }
}
