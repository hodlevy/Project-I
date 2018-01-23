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
    /// Interaction logic for UpdateContractWin.xaml
    /// </summary>
    public partial class UpdateContractWin : Window
    {
        public UpdateContractWin()
        {
            InitializeComponent();
            ComboBoxItem newContract;
            foreach (BE.Contract contract in GetBL.bl.AllContracts())
            {
                newContract = new ComboBoxItem();
                newContract.Content = contract.Code;
                comboBox.Items.Add(newContract);
            }
        }
        /// <summary>
        /// update a contract
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.Contract contract = null;
                contract = new BE.Contract(ChildID.Text, NannyID.Text, MotherID.Text, (bool)Met.IsChecked, (bool)Signed.IsChecked, Convert.ToDouble(PayHour.Text), Convert.ToDouble(PayMonth.Text), (bool)Per.IsChecked, (DateTime)Begin.SelectedDate, (DateTime)End.SelectedDate);
                contract.Code = comboBox.SelectedIndex;
                GetBL.bl.UpdateContract(contract);
                Thread.Sleep(500);
                Close();
            }
            catch (Exception str)
            {
                MessageBox.Show(str.Message, str.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBox.SelectedIndex;
            if (index == 0)
            {
                ChildID.Text = "";
                MotherID.Text = "";
                NannyID.Text = "";
                Met.IsChecked = false;
                Signed.IsChecked = false;
                PayHour.Text = "";
                PayMonth.Text = "";
                Per.IsChecked = false;
                Begin.SelectedDate = DateTime.Now;
                End.SelectedDate = DateTime.Now;
            }
            else
            {
                BE.Contract contract = GetBL.bl.AllContracts()[index - 1];
                ChildID.Text = contract.ChildId;
                MotherID.Text = contract.MotherId;
                NannyID.Text = contract.NannyId;
                Met.IsChecked = contract.HaveMet;
                Signed.IsChecked = contract.HaveSigned;
                PayHour.Text = contract.PayForHour.ToString();
                PayMonth.Text = contract.PayForMonth.ToString();
                Per.IsChecked = contract.PerWhat;
                Begin.SelectedDate = contract.BeginDate;
                End.SelectedDate = contract.EndDate;
            }
            SetButton();
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
            button.IsEnabled = comboBox.SelectedIndex != -1 && comboBox.SelectedIndex != 0 && PayHour.Text != "" && PayMonth.Text != "" && Begin.SelectedDate != null && End.SelectedDate != null;
        }
        private void Enable(object sender, object e)
        {
            SetButton();
        }
    }
}
