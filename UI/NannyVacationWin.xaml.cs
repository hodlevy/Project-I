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
    /// Interaction logic for NannyVacationWin.xaml
    /// </summary>
    public partial class NannyVacationWin : Window
    {
        public NannyVacationWin()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string str = "Nannies with vacations according to TMT:\n\n";
            List<BE.Nanny> list = GetBL.bl.VacationCheck_AllNanny();
            for (int i = 0; i < list.Count(); i++)
            {
                str += list[i].ToString() + "\n\n--------\n\n";
            }
            textBox.Text = str;
        }
    }
}
