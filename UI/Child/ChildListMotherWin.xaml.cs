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
    /// Interaction logic for ChildListMotherWin.xaml
    /// </summary>
    public partial class ChildListMotherWin : Window
    {
        public ChildListMotherWin()
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = comboBox.SelectedIndex;
            if (index == 0)
            {
                textBox.Text = "";
            }
            else
            {
                string str = "Children of " + GetBL.bl.AllMothers()[index - 1].FirstName + " " + GetBL.bl.AllMothers()[index - 1].LastName + ":\n\n";
                List<BE.Child> list = GetBL.bl.AllChildren();
                for (int i = 0; i < list.Count(); i++)
                {
                    if(list[i].MotherId == GetBL.bl.AllMothers()[index - 1].Id)
                        str += list[i].ToString() + "\n\n--------\n\n";
                }
                textBox.Text = str;
            }
        }
    }
}
