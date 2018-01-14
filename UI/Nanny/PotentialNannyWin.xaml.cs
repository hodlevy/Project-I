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
    /// Interaction logic for PotentialNannyWin.xaml
    /// </summary>
    public partial class PotentialNannyWin : Window
    {
        /// <summary>
        /// print the potential nannies to a mother
        /// </summary>
        public PotentialNannyWin()
        {
            InitializeComponent();
            string str = "Potential Nannies:\n\n";
            List<BE.Nanny> list = GetBL.bl.PotentiallyNannies(GetBL.bl.AllMothers().Last().Id);
            for (int i = 0; i < list.Count(); i++)
            {
                str += list[i].ToString() + "\n\n--------\n\n";
            }
            textBox.Text = str;
        }
    }
}
