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
    /// Interaction logic for AddContractWin.xaml
    /// </summary>
    public partial class AddContractWin : Window
    {
        public AddContractWin()
        {
            InitializeComponent();
            string str = Convert.ToString(GetBL.bl.AllContracts().Count() + 1);
            Number.Text = str;
            ComboBoxItem newChild;
            foreach (BE.Child child in GetBL.bl.AllChildren())
            {
                newChild = new ComboBoxItem();
                newChild.Content = child.Id + " - " + child.FirstName;
                comboBox.Items.Add(newChild);
            }
        }
        /// <summary>
        /// add the data that was handed over by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            BE.Contract contract = null;
            try
            {
                contract = new BE.Contract(GetBL.bl.AllChildren()[comboBox.SelectedIndex - 1].Id, GetBL.bl.PotentiallyNannies(GetBL.bl.AllChildren()[comboBox.SelectedIndex - 1].MotherId)[comboBox2.SelectedIndex - 1].Id, MotherID.Text, (bool)Met.IsChecked, (bool)Signed.IsChecked, Convert.ToDouble(PayHour.Text), Convert.ToDouble(PayMonth.Text), (bool)Per.IsChecked, (DateTime)Begin.SelectedDate, (DateTime)End.SelectedDate);
                GetBL.bl.AddContract(contract);
                Thread.Sleep(500);
                Close();
            }
            catch(Exception str)
            {
                contract.Number--;
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBox2.Items.Clear();
            if (comboBox.SelectedIndex > 0)
            { 
                MotherID.Text = GetBL.bl.AllChildren()[comboBox.SelectedIndex - 1].MotherId;
                ComboBoxItem newNanny = new ComboBoxItem();
                newNanny.Content = "Choose...";
                comboBox2.Items.Add(newNanny);
                foreach (BE.Nanny nanny in GetBL.bl.PotentiallyNannies(GetBL.bl.AllChildren()[comboBox.SelectedIndex - 1].MotherId))
                {
                    newNanny = new ComboBoxItem();
                    newNanny.Content = nanny.Id + " - " + nanny.FirstName + " " + nanny.LastName;
                    comboBox2.Items.Add(newNanny);
                }
            }
            else
                MotherID.Text = "";
        }
    }
}
