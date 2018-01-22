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
    /// Interaction logic for UpdateChildWin.xaml
    /// </summary>
    public partial class UpdateChildWin : Window
    {
        public UpdateChildWin()
        {
            InitializeComponent();
            ComboBoxItem newChild;
            foreach (BE.Child child in GetBL.bl.AllChildren())
            {
                newChild = new ComboBoxItem();
                newChild.Content = child.Id + " - " + child.FirstName;
                comboBox.Items.Add(newChild);
            }
        }
        /// <summary>
        /// uodate a child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BE.Child child = new BE.Child(GetBL.bl.AllChildren()[comboBox.SelectedIndex - 1].Id, MotherID.Text, Name.Text, (DateTime)datePicker.SelectedDate, (bool)IfNeeds.IsChecked, SpecialNeeds.Text);
                GetBL.bl.UpdateChild(child);
                Thread.Sleep(500);
                Close();
            }
            catch (Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void comboBox_Selected(object sender, RoutedEventArgs e)
        {
            int index = comboBox.SelectedIndex;
            if (index == 0)
            {
                MotherID.Text = "";
                Name.Text = "";
                datePicker.SelectedDate = DateTime.Now;
                IfNeeds.IsChecked = false;
                SpecialNeeds.Text = "";
            }
            else
            {
                BE.Child child = GetBL.bl.AllChildren()[index - 1];
                MotherID.Text = child.MotherId;
                Name.Text = child.FirstName;
                datePicker.SelectedDate = child.BirthDate;
                IfNeeds.IsChecked = child.IsSpecialNeeds;
                SpecialNeeds.Text = child.SpecialNeeds;
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
    }
}
