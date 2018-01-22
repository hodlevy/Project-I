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
    /// Interaction logic for DeleteMotherWin.xaml
    /// </summary>
    public partial class DeleteMotherWin : Window
    {
        public DeleteMotherWin()
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
        /// delete mother due to her ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetBL.bl.DeleteMother(GetBL.bl.AllMothers()[comboBox.SelectedIndex - 1].Id);
                Thread.Sleep(500);
                Close();
            }
            catch (Exception str)
            {
                MessageBox.Show(str.Message, str.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
