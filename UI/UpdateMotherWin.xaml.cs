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
    /// Interaction logic for UpdateMotherWin.xaml
    /// </summary>
    public partial class UpdateMotherWin : Window
    {
        public UpdateMotherWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] NeedsNanny = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
            TimeSpan[,] workHours = { { TimeSpan.FromHours(Convert.ToDouble(SunHour.Text) + (Convert.ToDouble(SunMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(SunHour2.Text) + (Convert.ToDouble(SunMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(MonHour.Text) + (Convert.ToDouble(MonMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(MonHour2.Text) + (Convert.ToDouble(MonMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(TuesHour.Text) + (Convert.ToDouble(TuesMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(TuesHour2.Text) + (Convert.ToDouble(TuesMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(WedHour.Text) + (Convert.ToDouble(WedMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(WedHour2.Text) + (Convert.ToDouble(WedMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(ThuHour.Text) + (Convert.ToDouble(ThuMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(ThuHour2.Text) + (Convert.ToDouble(ThuMin2.Text) / 60)) }, { TimeSpan.FromHours(Convert.ToDouble(FriHour.Text) + (Convert.ToDouble(FriMin.Text) / 60)), TimeSpan.FromHours(Convert.ToDouble(FriHour2.Text) + (Convert.ToDouble(FriMin2.Text) / 60)) } };
            BE.Mother mother = new BE.Mother(ID.Text, First.Text, Last.Text, Phone.Text, Address.Text, SearchArea.Text, NeedsNanny, workHours, Comments.Text);
            try
            {
                GetBL.bl.UpdateMother(mother);
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
