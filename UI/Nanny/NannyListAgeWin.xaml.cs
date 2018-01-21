using BE;
using System;
using System.Collections;
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
    /// Interaction logic for NannyListAgeWin.xaml
    /// </summary>
    public partial class NannyListAgeWin : Window
    {
        public NannyListAgeWin()
        {
            InitializeComponent();
        }

        private void max_Click(object sender, RoutedEventArgs e)
        {
            string str = "Nannies By Max Age:\n\n";
            IEnumerable<IGrouping<int, Nanny>> list = GetBL.bl.GroupNanny(true, false);
            foreach (var items in list)
            {
                str += "Key: " + items.Key + "\n\n";
                foreach (var it in items)
                {
                    str += it.ToString() + "\n\n";
                }
                str += "--------\n\n";
            }
            textBox.Text = str;
        }

        private void min_Click(object sender, RoutedEventArgs e)
        {
            string str = "Nannies By Min Age:\n\n";
            IEnumerable<IGrouping<int, Nanny>> list = GetBL.bl.GroupNanny(false, false);
            foreach (var items in list)
            {
                str += "Key: " + items.Key + "\n\n";
                foreach (var it in items)
                {
                    str += it.ToString() + "\n\n";
                }
                str += "--------\n\n";
            }
            textBox.Text = str;
        }
    }
}
