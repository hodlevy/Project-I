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
        public MainWindow()
        {
            InitializeComponent();
            GetBL.initBL();
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

        private void Add_Mother(object sender, RoutedEventArgs e)
        {
            AddMotherWin addMotherWin = new AddMotherWin();
            addMotherWin.ShowDialog();
        }
        private void Delete_Mother(object sender, RoutedEventArgs e)
        {
            DeleteMotherWin deleteMotherWin = new DeleteMotherWin();
            deleteMotherWin.ShowDialog();
        }
        private void Update_Mother(object sender, RoutedEventArgs e)
        {
            UpdateMotherWin updateMotherWin = new UpdateMotherWin();
            updateMotherWin.ShowDialog();
        }
        private void Add_Contract(object sender, RoutedEventArgs e)
        {
            AddContractWin addContractWin = new AddContractWin();
            addContractWin.ShowDialog();
        }
        private void Delete_Contract(object sender, RoutedEventArgs e)
        {
            DeleteContractWin deleteContractWin = new DeleteContractWin();
            deleteContractWin.ShowDialog();
        }
        private void Update_Contract(object sender, RoutedEventArgs e)
        {
            UpdateContractWin updateContractWin = new UpdateContractWin();
            updateContractWin.ShowDialog();
        }
        private void Nanny_List(object sender, RoutedEventArgs e)
        {
            NannyListWin nannyListWin = new NannyListWin();
            nannyListWin.ShowDialog();
        }
        private void Mother_List(object sender, RoutedEventArgs e)
        {
            MotherListWin motherListWin = new MotherListWin();
            motherListWin.ShowDialog();
        }
        private void Child_List(object sender, RoutedEventArgs e)
        {
            ChildListWin childListWin = new ChildListWin();
            childListWin.ShowDialog();
        }
        private void Contract_List(object sender, RoutedEventArgs e)
        {
            ContractListWin contractListWin = new ContractListWin();
            contractListWin.ShowDialog();
        }
    }
    public class GetBL
    {
        public static BL.IBL bl;

        public static void initBL()
        {
            bl = BL.FactoryBL.GetBL();
        }
        public static BL.IBL getBL()
        {
            return bl;
        }
    }
}