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
    /// Interaction logic for AddMotherWin.xaml
    /// </summary>
    public partial class AddMotherWin : Window
    {
        public AddMotherWin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// add the data that was handed over by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] NeedsNanny = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
            TimeSpan[,] workHours = { { TimeSpan.FromHours(Convert.ToDouble(SunHour.Text) + (Convert.ToDouble(SunMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(SunHour2.Text) + (Convert.ToDouble(SunMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(MonHour.Text) + (Convert.ToDouble(MonMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(MonHour2.Text) + (Convert.ToDouble(MonMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(TuesHour.Text) + (Convert.ToDouble(TuesMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(TuesHour2.Text) + (Convert.ToDouble(TuesMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(WedHour.Text) + (Convert.ToDouble(WedMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(WedHour2.Text) + (Convert.ToDouble(WedMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(ThuHour.Text) + (Convert.ToDouble(ThuMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(ThuHour2.Text) + (Convert.ToDouble(ThuMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(FriHour.Text) + (Convert.ToDouble(FriMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(FriHour2.Text) + (Convert.ToDouble(FriMin2.Text) / 60)) } };
            try
            {
                BE.Mother mother;
                if (SearchArea.Text == "")
                    mother = new BE.Mother(ID.Text, First.Text, Last.Text, Phone.Text, Address.Text, Address.Text, NeedsNanny, workHours, Comments.Text);
                else
                    mother = new BE.Mother(ID.Text, First.Text, Last.Text, Phone.Text, Address.Text, SearchArea.Text, NeedsNanny, workHours, Comments.Text);
                GetBL.bl.AddMother(mother);
                PotentialNannyWin potentialNannyWin = new PotentialNannyWin();
                potentialNannyWin.Show();
                Thread.Sleep(500);
                Close();
            }
            catch (Exception str)
            {
                MessageBox.Show(str.Message, str.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            button.FontSize = 40;
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            button.FontSize = 16;
        }
        private void SetButton()
        {
            //button.IsEnabled = ID.Text != "" && Name.Text != "" && datePicker.SelectedDate != null && (comboBox.SelectedIndex != 0 && comboBox.SelectedIndex != -1);
        }
        private void Enable(object sender, object e)
        {
            SetButton();
        }
    }
}
