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
using System.Windows.Shapes;

namespace WpfApp_1
{
    /// <summary>
    /// Логика взаимодействия для Win.xaml
    /// </summary>
    public partial class Win : Window
    {
        private Picture pic1;
        public string img { get; set; }
        public Win(object pic)
        {
            InitializeComponent();
            //pic1 = pic;
        }
    }
}
