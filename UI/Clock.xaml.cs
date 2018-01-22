using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace UI
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl
    {
        public Clock()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            { dateText.Text = DateTime.Now.ToString("HH:mm:ss"); }, Dispatcher);
        }
    }
}
