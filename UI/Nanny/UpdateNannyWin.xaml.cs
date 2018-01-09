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
    /// Interaction logic for UpdateNannyWin.xaml
    /// </summary>
    public partial class UpdateNannyWin : Window
    {
        public UpdateNannyWin()
        {
            InitializeComponent();
            ComboBoxItem newNanny;
            foreach (BE.Nanny nanny in GetBL.bl.AllNannys())
            {
                newNanny = new ComboBoxItem();
                newNanny.Content = nanny.Id + " - " + nanny.FirstName + " " + nanny.LastName;
                comboBox.Items.Add(newNanny);
            }
        }
        /// <summary>
        /// update a nanny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] workingDays = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
            TimeSpan[,] workHours = { { TimeSpan.FromHours(Convert.ToDouble(SunHour.Text) + (Convert.ToDouble(SunMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(SunHour2.Text) + (Convert.ToDouble(SunMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(MonHour.Text) + (Convert.ToDouble(MonMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(MonHour2.Text) + (Convert.ToDouble(MonMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(TuesHour.Text) + (Convert.ToDouble(TuesMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(TuesHour2.Text) + (Convert.ToDouble(TuesMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(WedHour.Text) + (Convert.ToDouble(WedMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(WedHour2.Text) + (Convert.ToDouble(WedMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(ThuHour.Text) + (Convert.ToDouble(ThuMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(ThuHour2.Text) + (Convert.ToDouble(ThuMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(FriHour.Text) + (Convert.ToDouble(FriMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(FriHour2.Text) + (Convert.ToDouble(FriMin2.Text) / 60)) } };
            BE.Nanny nanny = new BE.Nanny(GetBL.bl.AllMothers()[comboBox.SelectedIndex - 1].Id, First.Text, Last.Text, (DateTime)datePicker.SelectedDate, Address.Text, Phone.Text, (bool)Elevator.IsChecked, Convert.ToInt32(Floor.Text), Convert.ToInt32(Exp.Text), Convert.ToInt32(MaxChild.Text), Convert.ToInt32(MinAge.Text), Convert.ToInt32(MaxAge.Text), (bool)HourPayment.IsChecked, Convert.ToDouble(PayHour.Text), Convert.ToDouble(PayMonth.Text), (bool)TMT.IsChecked, Recommendation.Text, workingDays, workHours);
            try
            {
                GetBL.bl.UpdateNanny(nanny);
                Thread.Sleep(500);
                Close();
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBox.SelectedIndex;
            if (index == 0)
            {
                First.Text = "";
                Last.Text = "";
                datePicker.SelectedDate = DateTime.Now;
                Phone.Text = "";
                Address.Text = "";
                Elevator.IsChecked = false;
                Floor.Text = "";
                Exp.Text = "";
                MaxChild.Text = "";
                MinAge.Text = "";
                MaxAge.Text = "";
                HourPayment.IsChecked = false;
                PayHour.Text = "";
                PayMonth.Text = "";
                TMT.IsChecked = false;
                Recommendation.Text = "";
                #region Hours
                Sunday.IsChecked = false;
                Monday.IsChecked = false;
                Tuesday.IsChecked = false;
                Wednesday.IsChecked = false;
                Thursday.IsChecked = false;
                Friday.IsChecked = false;
                SunHour.Text = "";
                SunMin.Text = "";
                SunHour2.Text = "";
                SunMin2.Text = "";
                MonHour.Text = "";
                MonMin.Text = "";
                MonHour2.Text = "";
                MonMin2.Text = "";
                TuesHour.Text = "";
                TuesMin.Text = "";
                TuesHour2.Text = "";
                TuesMin2.Text = "";
                WedHour.Text = "";
                WedMin.Text = "";
                WedHour2.Text = "";
                WedMin2.Text = "";
                ThuHour.Text = "";
                ThuMin.Text = "";
                ThuHour2.Text = "";
                ThuMin2.Text = "";
                FriHour.Text = "";
                FriMin.Text = "";
                FriHour2.Text = "";
                FriMin2.Text = "";
                #endregion
            }
            else
            {
                BE.Nanny nanny = GetBL.bl.AllNannys()[index - 1];
                First.Text = nanny.FirstName;
                Last.Text = nanny.LastName;
                datePicker.SelectedDate = nanny.BirthDate;
                Phone.Text = nanny.PhoneNumber;
                Address.Text = nanny.Address;
                Elevator.IsChecked = nanny.IsElevator;
                Floor.Text = nanny.Floor.ToString();
                Exp.Text = nanny.Experience.ToString();
                MaxChild.Text = nanny.MaxChildren.ToString();
                MinAge.Text = nanny.MinAge.ToString();
                MaxAge.Text = nanny.MaxAge.ToString();
                HourPayment.IsChecked = nanny.IfHourPaid;
                PayHour.Text = nanny.PayForHour.ToString();
                PayMonth.Text = nanny.PayForMonth.ToString();
                TMT.IsChecked = nanny.VacationCheck;
                Recommendation.Text = nanny.Recommendation;
                #region hours
                Sunday.IsChecked = nanny.IsWorking[0];
                Monday.IsChecked = nanny.IsWorking[1];
                Tuesday.IsChecked = nanny.IsWorking[2];
                Wednesday.IsChecked = nanny.IsWorking[3];
                Thursday.IsChecked = nanny.IsWorking[4];
                Friday.IsChecked = nanny.IsWorking[5];
                SunHour.Text = (nanny.WorkHours[0, 0]).Hours.ToString();
                SunMin.Text = (nanny.WorkHours[0, 0]).Minutes.ToString();
                SunHour2.Text = (nanny.WorkHours[0, 1]).Hours.ToString();
                SunMin2.Text = (nanny.WorkHours[0, 1]).Minutes.ToString();
                MonHour.Text = (nanny.WorkHours[1, 0]).Hours.ToString();
                MonMin.Text = (nanny.WorkHours[1, 0]).Minutes.ToString();
                MonHour2.Text = (nanny.WorkHours[1, 1]).Hours.ToString();
                MonMin2.Text = (nanny.WorkHours[1, 1]).Minutes.ToString();
                TuesHour.Text = (nanny.WorkHours[2, 0]).Hours.ToString();
                TuesMin.Text = (nanny.WorkHours[2, 0]).Minutes.ToString();
                TuesHour2.Text = (nanny.WorkHours[2, 1]).Hours.ToString();
                TuesMin2.Text = (nanny.WorkHours[2, 1]).Minutes.ToString();
                WedHour.Text = (nanny.WorkHours[3, 0]).Hours.ToString();
                WedMin.Text = (nanny.WorkHours[3, 0]).Minutes.ToString();
                WedHour2.Text = (nanny.WorkHours[3, 1]).Hours.ToString();
                WedMin2.Text = (nanny.WorkHours[3, 1]).Minutes.ToString();
                ThuHour.Text = (nanny.WorkHours[4, 0]).Hours.ToString();
                ThuMin.Text = (nanny.WorkHours[4, 0]).Minutes.ToString();
                ThuHour2.Text = (nanny.WorkHours[4, 1]).Hours.ToString();
                ThuMin2.Text = (nanny.WorkHours[4, 1]).Minutes.ToString();
                FriHour.Text = (nanny.WorkHours[5, 0]).Hours.ToString();
                FriMin.Text = (nanny.WorkHours[5, 0]).Minutes.ToString();
                FriHour2.Text = (nanny.WorkHours[5, 1]).Hours.ToString();
                FriMin2.Text = (nanny.WorkHours[5, 1]).Minutes.ToString();
                #endregion
            }
        }
    }
}
