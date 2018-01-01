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
    /// Interaction logic for UpdateNannyWin.xaml
    /// </summary>
    public partial class UpdateNannyWin : Window
    {
        public UpdateNannyWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] workingDays = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
            TimeSpan[,] workHours = { { TimeSpan.FromHours(Convert.ToDouble(SunHour.Text) + (Convert.ToDouble(SunMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(SunHour2.Text) + (Convert.ToDouble(SunMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(MonHour.Text) + (Convert.ToDouble(MonMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(MonHour2.Text) + (Convert.ToDouble(MonMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(TuesHour.Text) + (Convert.ToDouble(TuesMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(TuesHour2.Text) + (Convert.ToDouble(TuesMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(WedHour.Text) + (Convert.ToDouble(WedMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(WedHour2.Text) + (Convert.ToDouble(WedMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(ThuHour.Text) + (Convert.ToDouble(ThuMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(ThuHour2.Text) + (Convert.ToDouble(ThuMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(FriHour.Text) + (Convert.ToDouble(FriMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(FriHour2.Text) + (Convert.ToDouble(FriMin2.Text) / 60)) } };
            BE.Nanny nanny = new BE.Nanny(ID.Text, First.Text, Last.Text, (DateTime)Date.SelectedDate, Address.Text, Phone.Text, (bool)Elevator.IsChecked, Convert.ToInt32(Floor.Text), Convert.ToInt32(Exp.Text), Convert.ToInt32(MaxChild.Text), Convert.ToInt32(MinAge.Text), Convert.ToInt32(MaxAge.Text), (bool)HourPayment.IsChecked, Convert.ToDouble(PayHour.Text), Convert.ToDouble(PayMonth.Text), (bool)TMT.IsChecked, Recommendation.Text, workingDays, workHours);
            try
            {
                GetBL.bl.UpdateNanny(nanny);
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
