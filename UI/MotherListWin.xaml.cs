using System;
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
    /// Interaction logic for MotherListWin.xaml
    /// </summary>
    public partial class MotherListWin : Window
    {
        public MotherListWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string str = "Mothers:\n\n";
            List<BE.Mother> list = GetBL.bl.AllMothers();
            for (int i = 0; i < list.Count(); i++)
            {
                str += list[i].ToString() + "\n\n--------\n\n";
            }
            textBox.Text = str;
        }
    }
}
