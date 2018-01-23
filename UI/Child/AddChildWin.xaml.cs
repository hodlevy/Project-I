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
    /// Interaction logic for AddChildWin.xaml
    /// </summary>
    public partial class AddChildWin : Window
    {
        BE.Child child;
        public AddChildWin()
        {
            InitializeComponent();
            ComboBoxItem newMother;
            foreach (BE.Mother mother in GetBL.bl.AllMothers())
            {
                newMother = new ComboBoxItem();
                newMother.Content = mother.Id + " - " + mother.FirstName + " " + mother.LastName;
                comboBox.Items.Add(newMother);
            }
            child = new BE.Child();
            addChildGrid.DataContext = child;
        }
        /// <summary>
        /// add the data that was handed over by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!IDCheck(ID.Text.ToString()))
                    throw new Exception("Wrong ID!");
                child.MotherId = GetBL.bl.AllMothers()[comboBox.SelectedIndex - 1].Id;
                GetBL.bl.AddChild(child);
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
            button.IsEnabled = ID.Text != "" && Name.Text != "" && datePicker.SelectedDate != null && (comboBox.SelectedIndex != 0 && comboBox.SelectedIndex != -1);
        }
        private void Enable(object sender, TextChangedEventArgs e)
        {
            SetButton();
        }
        private void Enable3(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }

        private void Enable2(object sender, SelectionChangedEventArgs e)
        {
            SetButton();
        }
        static bool IDCheck(String strID)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (strID == null)
                return false;

            strID = strID.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(strID.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }

            return (count % 10 == 0);
        }
    }
}
