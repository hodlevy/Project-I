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
        public AddContractWin()
        {
            InitializeComponent();
            string str = Convert.ToString(GetBL.bl.AllContracts().Count() + 1);
            Number.Text = str;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BE.Contract contract = new BE.Contract(ChildID.Text, NannyID.Text, MotherID.Text, (bool)Met.IsChecked, (bool)Signed.IsChecked, Convert.ToDouble(PayHour.Text), Convert.ToDouble(PayMonth.Text), (bool)Per.IsChecked, (DateTime)Begin.SelectedDate, (DateTime)End.SelectedDate);
            try
            {
                GetBL.bl.AddContract(contract);
            }
            catch(Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
