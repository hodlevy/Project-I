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
    /// Interaction logic for AddContractWin.xaml
    /// </summary>
    public partial class AddContractWin : Window
    {
        public BL.IBL bl;
        public AddContractWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        private void textBlock12_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BE.Contract contract = new BE.Contract();
            textBlock12.Text = contract.Number.ToString();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ///////////////////
        }
    }
}
