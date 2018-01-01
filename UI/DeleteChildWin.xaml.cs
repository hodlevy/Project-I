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
    /// Interaction logic for DeleteChildWin.xaml
    /// </summary>
    public partial class DeleteChildWin : Window
    {
        public DeleteChildWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetBL.bl.DeleteChild(textBox.Text);
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
