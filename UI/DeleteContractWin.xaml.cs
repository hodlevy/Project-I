using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for DeleteContractWin.xaml
    /// </summary>
    public partial class DeleteContractWin : Window
    {
        public DeleteContractWin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// delete contract due to his number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetBL.bl.DeleteContract(Convert.ToInt32(textBox.Text));
                Thread.Sleep(500);
                Close();
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
