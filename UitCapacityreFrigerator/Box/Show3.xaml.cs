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
using UitCapacityreFrigerator.Factory;

namespace UitCapacityreFrigerator.Box
{
    /// <summary>
    /// Show3.xaml 的交互逻辑
    /// </summary>
    public partial class Show3 : MetroWindow
    {
        public Show3()
        {
            InitializeComponent();
            inItReport();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void inItReport()
        {
            string[] month = new string[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
            List<string> yearList = new List<string>();
            yearList.Add("2015年");
            yearButton.ItemsSource = yearList;

            List<string> monthList = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                monthList.Add(month[i]);
            }
            monthButton.ItemsSource = monthList;

            List<string> dayList = new List<string>();
            for (int i = 1; i < 32; i++)
            {
                dayList.Add(i + "");
            }
            dayButton.ItemsSource = dayList;
            report_FlipView.Items.Add(ViewFactory.getView("33", 4.2, 3.0));



            yearButton.SelectedIndex = 0;
            monthButton.SelectedIndex = DateTime.Now.Month - 1;
            dayButton.SelectedIndex = DateTime.Now.Day - 1;
            report_FlipView.SelectedIndex = 17;
        }

        private void year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void report_FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
