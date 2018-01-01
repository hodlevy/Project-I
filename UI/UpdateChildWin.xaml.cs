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
    /// Interaction logic for UpdateChildWin.xaml
    /// </summary>
    public partial class UpdateChildWin : Window
    {
        public UpdateChildWin()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            BE.Child child = new BE.Child(ID.Text, MotherID.Text, Name.Text, (DateTime)Calendar.SelectedDate, (bool)IfNeeds.IsChecked, SpecialNeeds.Text);
            try
            {
                GetBL.bl.UpdateChild(child);
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
