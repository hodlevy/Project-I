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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BL.IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }

        private void Add_Nanny(object sender, RoutedEventArgs e)
        {
            AddNannyWin addNannyWin = new AddNannyWin();
            addNannyWin.ShowDialog();
        }

        private void Delete_Nanny(object sender, RoutedEventArgs e)
        {
            DeleteNannyWin deleteNannyWin = new DeleteNannyWin();
            deleteNannyWin.ShowDialog();
        }

        private void Update_Nanny(object sender, RoutedEventArgs e)
        {
            UpdateNannyWin updateNannyWin = new UpdateNannyWin();
            updateNannyWin.ShowDialog();
        }

        private void Add_Child(object sender, RoutedEventArgs e)
        {
            AddChildWin addChildWin = new AddChildWin();
            addChildWin.ShowDialog();
        }

        private void Delete_Child(object sender, RoutedEventArgs e)
        {
            DeleteChildWin deleteChildWin = new DeleteChildWin();
            deleteChildWin.ShowDialog();
        }

        private void Update_Child(object sender, RoutedEventArgs e)
        {
            UpdateChildWin updateChildWin = new UpdateChildWin();
            updateChildWin.ShowDialog();
        }
    }
}
