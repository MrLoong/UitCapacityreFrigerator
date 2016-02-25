using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Titp.xaml 的交互逻辑
    /// </summary>
    public partial class Titp : MetroWindow
    {
        public Titp(string name )
        {
            InitializeComponent();
            text_tt.Text = "物品"+name+"不足";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        private void lihgtsTileClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
