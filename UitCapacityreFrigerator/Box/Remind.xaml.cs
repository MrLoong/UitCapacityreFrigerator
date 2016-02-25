using MahApps.Metro.Controls;
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

namespace UitCapacityreFrigerator.Box
{
    /// <summary>
    /// Remind.xaml 的交互逻辑
    /// </summary>
    public partial class Remind : MetroWindow
    {
        public Remind()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void lihgtsTileClick(object sender, RoutedEventArgs e)
        {
            Overdue over = new Overdue();
            over.Show();
            this.Close();
        }
    }
}
