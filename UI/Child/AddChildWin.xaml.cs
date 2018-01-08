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
        public AddChildWin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// add the data that was handed over by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            BE.Child child = new BE.Child(ID.Text, MotherID.Text, Name.Text, (DateTime)datePicker.SelectedDate, (bool)IfNeeds.IsChecked, SpecialNeeds.Text);
            try
            {
                GetBL.bl.AddChild(child);
                Thread.Sleep(500);
                Close();
            }
            catch(Exception str)
            {
                MessageBox.Show(str.ToString(), str.ToString(), MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
