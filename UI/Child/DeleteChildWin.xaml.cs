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
    /// Interaction logic for DeleteChildWin.xaml
    /// </summary>
    public partial class DeleteChildWin : Window
    {
        public DeleteChildWin()
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
        /// delete child due to his ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetBL.bl.DeleteChild(GetBL.bl.AllChildren()[comboBox.SelectedIndex - 1].Id);
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
