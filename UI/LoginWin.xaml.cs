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

namespace UI
{
    /// <summary>
    /// Interaction logic for LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            button.Background = Brushes.Orange;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            button.Background = Brushes.LightGoldenrodYellow;
        }

        private void textBlock2_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlock2.Foreground = Brushes.Gold;
        }

        private void textBlock2_MouseLeave(object sender, MouseEventArgs e)
        {
            textBlock2.Foreground = Brushes.Black;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
