using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for ContractListDistanceWin.xaml
    /// </summary>
    public partial class ContractListDistanceWin : Window
    {
        public ContractListDistanceWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string str = "Contracts By Distance:\n\n";
            IEnumerable<IGrouping<int, BE.Contract>> list = GetBL.bl.ContractByDistance(false);
            foreach (var items in list)
            {
                str += "Key: " + items.Key + "\n\n";
                foreach (var item in items)
                {
                    str += item.ToString() + "\n\n";
                }
                str += "--------\n\n";
            }
            textBox.Text = str;
        }
    }
}
