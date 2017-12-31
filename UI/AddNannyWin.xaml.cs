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
    /// Interaction logic for AddNannyWin.xaml
    /// </summary>
    public partial class AddNannyWin : Window
    {
        public BL.IBL bl;
        public AddNannyWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] workingDays = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
           // BE.Nanny nanny = new BE.Nanny(ID.Text, First.Text, Last.Text, Date.SelectedDate, Phone.Text, Address.Text, Elevator.IsChecked, Floor.Text, Exp.Text, MaxChild.Text, MinAge.Text, MaxAge.Text, HourPayment.IsChecked, PayHour.Text, PayMonth.Text, TMT.IsChecked, Recommendation.Text, workingDays, );
            try
            {
           //     bl.AddNanny(nanny);
            }
            catch(Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
