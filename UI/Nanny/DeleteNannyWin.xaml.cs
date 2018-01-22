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
    /// Interaction logic for DeleteNannyWin.xaml
    /// </summary>
    public partial class DeleteNannyWin : Window
    {
        public DeleteNannyWin()
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
        /// delete nanny due to her ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetBL.bl.DeleteNanny(GetBL.bl.AllNannys()[comboBox.SelectedIndex - 1].Id);
                Thread.Sleep(500);
                Close();
            }
            catch(Exception str)
            {
                MessageBox.Show(str.Message, str.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
