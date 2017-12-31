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
    /// Interaction logic for AddMotherWin.xaml
    /// </summary>
    public partial class AddMotherWin : Window
    {
        public BL.IBL bl;
        public AddMotherWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool[] NeedsNanny = { (bool)Sunday.IsChecked, (bool)Monday.IsChecked, (bool)Tuesday.IsChecked, (bool)Wednesday.IsChecked, (bool)Thursday.IsChecked, (bool)Friday.IsChecked };
            //BE.Mother mother = new BE.Mother(ID.Text, First.Text, Last.Text, Phone.Text, Address.Text, SearchArea.Text, NeedsNanny, , Comments.Text);
            try
            {
                //bl.AddMother(mother);
            }
            catch(Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
