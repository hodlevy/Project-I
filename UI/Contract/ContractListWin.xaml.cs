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
    /// Interaction logic for ContractListWin.xaml
    /// </summary>
    public partial class ContractListWin : Window
    {
        public ContractListWin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// print the contracts list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string str = "Contracts:\n\n";
            List<BE.Contract> list = GetBL.bl.AllContracts();
            for (int i = 0; i < list.Count(); i++)
            {
                str += list[i].ToString() + "\n\n--------\n\n";
            }
            textBox.Text = str;
        }
    }
}
