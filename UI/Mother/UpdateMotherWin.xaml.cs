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
    /// Interaction logic for UpdateMotherWin.xaml
    /// </summary>
    public partial class UpdateMotherWin : Window
    {
        public UpdateMotherWin()
        {
            InitializeComponent();
            ComboBoxItem newMother;
            foreach (BE.Mother mother in GetBL.bl.AllMothers())
            {
                newMother = new ComboBoxItem();
                newMother.Content = mother.Id + " - " + mother.FirstName + " " + mother.LastName;
                comboBox.Items.Add(newMother);
            }
        }
        /// <summary>
        /// update a mother
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] NeedsNanny = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
            TimeSpan[,] workHours = { { TimeSpan.FromHours(Convert.ToDouble(SunHour.Text) + (Convert.ToDouble(SunMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(SunHour2.Text) + (Convert.ToDouble(SunMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(MonHour.Text) + (Convert.ToDouble(MonMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(MonHour2.Text) + (Convert.ToDouble(MonMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(TuesHour.Text) + (Convert.ToDouble(TuesMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(TuesHour2.Text) + (Convert.ToDouble(TuesMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(WedHour.Text) + (Convert.ToDouble(WedMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(WedHour2.Text) + (Convert.ToDouble(WedMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(ThuHour.Text) + (Convert.ToDouble(ThuMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(ThuHour2.Text) + (Convert.ToDouble(ThuMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(FriHour.Text) + (Convert.ToDouble(FriMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(FriHour2.Text) + (Convert.ToDouble(FriMin2.Text) / 60)) } };
            try
            {
                BE.Mother mother = new BE.Mother(GetBL.bl.AllMothers()[comboBox.SelectedIndex - 1].Id, First.Text, Last.Text, Phone.Text, Address.Text, SearchArea.Text, NeedsNanny, workHours, Comments.Text);
                GetBL.bl.UpdateMother(mother);
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
                Phone.Text = "";
                Address.Text = "";
                SearchArea.Text = "";
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
                BE.Mother mother = GetBL.bl.AllMothers()[index - 1];
                First.Text = mother.FirstName;
                Last.Text = mother.LastName;
                Phone.Text = mother.PhoneNumber;
                Address.Text = mother.Address;
                SearchArea.Text = mother.SearchingArea;
                #region hours
                Sunday.IsChecked = mother.NeedsNanny[0];
                Monday.IsChecked = mother.NeedsNanny[1];
                Tuesday.IsChecked = mother.NeedsNanny[2];
                Wednesday.IsChecked = mother.NeedsNanny[3];
                Thursday.IsChecked = mother.NeedsNanny[4];
                Friday.IsChecked = mother.NeedsNanny[5];
                SunHour.Text = (mother.NeedsNannyHours[0, 0]).Hours.ToString();
                SunMin.Text = (mother.NeedsNannyHours[0, 0]).Minutes.ToString();
                SunHour2.Text = (mother.NeedsNannyHours[0, 1]).Hours.ToString();
                SunMin2.Text = (mother.NeedsNannyHours[0, 1]).Minutes.ToString();
                MonHour.Text = (mother.NeedsNannyHours[1, 0]).Hours.ToString();
                MonMin.Text = (mother.NeedsNannyHours[1, 0]).Minutes.ToString();
                MonHour2.Text = (mother.NeedsNannyHours[1, 1]).Hours.ToString();
                MonMin2.Text = (mother.NeedsNannyHours[1, 1]).Minutes.ToString();
                TuesHour.Text = (mother.NeedsNannyHours[2, 0]).Hours.ToString();
                TuesMin.Text = (mother.NeedsNannyHours[2, 0]).Minutes.ToString();
                TuesHour2.Text = (mother.NeedsNannyHours[2, 1]).Hours.ToString();
                TuesMin2.Text = (mother.NeedsNannyHours[2, 1]).Minutes.ToString();
                WedHour.Text = (mother.NeedsNannyHours[3, 0]).Hours.ToString();
                WedMin.Text = (mother.NeedsNannyHours[3, 0]).Minutes.ToString();
                WedHour2.Text = (mother.NeedsNannyHours[3, 1]).Hours.ToString();
                WedMin2.Text = (mother.NeedsNannyHours[3, 1]).Minutes.ToString();
                ThuHour.Text = (mother.NeedsNannyHours[4, 0]).Hours.ToString();
                ThuMin.Text = (mother.NeedsNannyHours[4, 0]).Minutes.ToString();
                ThuHour2.Text = (mother.NeedsNannyHours[4, 1]).Hours.ToString();
                ThuMin2.Text = (mother.NeedsNannyHours[4, 1]).Minutes.ToString();
                FriHour.Text = (mother.NeedsNannyHours[5, 0]).Hours.ToString();
                FriMin.Text = (mother.NeedsNannyHours[5, 0]).Minutes.ToString();
                FriHour2.Text = (mother.NeedsNannyHours[5, 1]).Hours.ToString();
                FriMin2.Text = (mother.NeedsNannyHours[5, 1]).Minutes.ToString();
                #endregion
            }
        }
    }
}
