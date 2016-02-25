using AVOSCloud;
using MahApps.Metro.Controls;
using Newtonsoft.Json;
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
using UitCapacityreFrigerator.Communication;
using UitCapacityreFrigerator.Util;

namespace UitCapacityreFrigerator.Box
{
    /// <summary>
    /// InformationInput.xaml 的交互逻辑
    /// </summary>
    public partial class InformationInput : MetroWindow
    {
        private List<FoodMessage> list;
        private List<FoodMessage> list2;
     //   private static int old = 0;
        private static string id = " ";
     //   public static int old_wi = 0;        
       // public event EventHandler<string> Completed;
        private IController controller = MainWindow.getIController();

        public InformationInput()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            list = Analysain.FromJson(OptionTxt.readTxt("C:\\DATA.txt"));
            list2 = Analysain.FromJson(OptionTxt.readTxt("C:\\2.txt"));
            controller.Completed += qSerialPort_Completed;
        }

        public void qSerialPort_Completed(object sender, string data)
        {
          //  MessageBox.Show(data);
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                if(!text1.Text.Equals("Pass"))
                {
                    text1.Text = " ";
                    id = " ";
                    lampBox1.Text = " ";
                    lampBox.Text = " ";
                }
                try
                {
                    FoodCommand foodCommand = Analysain.FromJson_foodCommand(data);
                    if (foodCommand.conmmand.Equals("barcode") || foodCommand.conmmand.Equals("weight"))
                    {

                        if (foodCommand.conmmand.Equals("barcode"))
                        {

                            text1.Text = "Pass";
                            id = foodCommand.message;
                        }
                        if (foodCommand.conmmand.Equals("weight"))
                        {
                            lampBox.Text = foodCommand.message;

                        }
                        if (text1.Text != " " && lampBox.Text != " " && text1.Text.Equals("Pass"))
                        {

                            foreach (FoodMessage lists in list)
                            {
                               // MessageBox.Show(lists.foodName);
                                if (lists.foodId.Equals(id))
                                {
                                   // MessageBox.Show(lists.foodName);
                                    lampBox1.Text = lists.foodName;
                                    FoodMessage food1 = new FoodMessage(lists.foodName, lampBox.Text, lists.foodId, lists.foodType, lists.day, lists.state);
                                    list2.Add(food1);
                                    SaveToCloud(lists.day.ToString(), lists.foodName, lampBox.Text, lists.foodType, lists.state);
                                    text1.Text = "Complete";
                                }
                            }
                        }

                    }
                    if (foodCommand.conmmand.Equals("weight"))
                    {

                        text.Text = foodCommand.message;

                     //   MessageBox.Show(text.Text);
                    }
                }
                catch(Exception e)
                {

                }

            }), null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           /* FoodMessage food1 = new FoodMessage("黄瓜", "176克", "?餄", "22", 4, true);
            FoodMessage food3 = new FoodMessage("酸奶", "288克", "Q]頋", "33", 5, true);
            FoodMessage food5 = new FoodMessage("香瓜1", "342克", "延驖", "11", 6, true);
            FoodMessage food4 = new FoodMessage("香瓜2", "342克", "盝魸", "11", 3, true);
            list.Add(food1);
            list.Add(food3);
            list.Add(food4);
            list.Add(food5);*/

            //  string str = JsonConvert.SerializeObject(list);
            //MessageBox.Show(str);
            
            //OptionTxt.writeTxt(str);
           // AVObject beckham = new AVObject("Fruit");

          //  MessageBox.Show("ok");
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = JsonConvert.SerializeObject(list2);
            OptionTxt.writeTxt(str);


          //  MessageBox.Show(MainWindow.old_Total.ToString());
            controller.Completed -= qSerialPort_Completed;
            this.Close();
            //Environment.Exit(0);
        }
        public async void SaveToCloud(string r,string n,string k,string type,bool s)
        {
            if (n.Substring(0, 2).Equals("苹果"))
            {
               // MainWindow.xx++;
            }
            if (n.Substring(0, 2).Equals("+C"))
            {
                MainWindow.yy++;
            }
            if (n.Substring(0, 2).Equals("黄瓜"))
            {
               //MainWindow.cc++;
            }
            if (n.Substring(0, 2).Equals("酸奶"))
            {
              //  MainWindow.zz++;
            }
            if (type.Equals("11"))
            {

                AVObject Fruit = new AVObject("Fruit");
                Fruit["remainDays"] = r;
                Fruit["name"] = n;
                Fruit["kiloNum"] = k;
                Fruit["state"] = s;
                Task saveTask = Fruit.SaveAsync();
                await saveTask;
            }
            if(type.Equals("22"))
            {
                AVObject Vegetables = new AVObject("Vegetable");
                Vegetables["remainDays"] = r;
                Vegetables["name"] = n;
                Vegetables["kiloNum"] = k;
                Vegetables["state"] = s;
                Task saveTask = Vegetables.SaveAsync();
                await saveTask;
            }
            if (type.Equals("33"))
            {
                AVObject Food = new AVObject("Food");
                Food["remainDays"] = r;
                Food["name"] = n;
                Food["kiloNum"] = k;
                Food["state"] = s;
                Task saveTask = Food.SaveAsync();
                await saveTask;
            }

        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            text_Copy.Text = "香蕉";
            FoodMessage food1 = new FoodMessage("香蕉", text.Text, "0", "11", 4, true);
            
            list2.Add(food1);
            SaveToCloud("4", "香蕉", text.Text, "11", true);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "橘子";
             FoodMessage food1 = new FoodMessage("橘子", text.Text, "0", "11", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "橘子", text.Text, "11", true);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "柠檬";
             FoodMessage food1 = new FoodMessage("柠檬", text.Text, "0", "11", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "柠檬", text.Text, "11", true);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            text_Copy.Text = "香瓜";
            FoodMessage food1 = new FoodMessage("香瓜", text.Text, "0", "11", 4, true);
            list2.Add(food1);
            SaveToCloud("4", "香瓜", text.Text, "11", true);
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "西瓜";
             FoodMessage food1 = new FoodMessage("西瓜", text.Text, "0", "11", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "西瓜", text.Text, "11", true);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "葡萄";
             FoodMessage food1 = new FoodMessage("葡萄", text.Text, "0", "11", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "葡萄", text.Text, "11", true);
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "樱桃";
             FoodMessage food1 = new FoodMessage("樱桃", text.Text, "0", "11", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "樱桃", text.Text, "11", true);
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "薯条";
             FoodMessage food1 = new FoodMessage("薯条", text.Text, "0", "33", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "薯条", text.Text, "33", true);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "面包";
             FoodMessage food1 = new FoodMessage("面包", text.Text, "0", "33", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "面包", text.Text, "33", true);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "酸奶";
             FoodMessage food1 = new FoodMessage("酸奶", text.Text, "0", "33", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "酸奶", text.Text, "33", true);
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
              text_Copy.Text = "香肠";
              FoodMessage food1 = new FoodMessage("香肠", text.Text, "0", "33", 4, true);
              list2.Add(food1);
              SaveToCloud("4", "香肠", text.Text, "33", true);
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "饼干";
             FoodMessage food1 = new FoodMessage("饼干", text.Text, "0", "33", 4, true);
            list2.Add(food1);
            SaveToCloud("4", "饼干", text.Text, "33", true);
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "果冻";
             FoodMessage food1 = new FoodMessage("果冻", text.Text, "0", "33", 4, true);
            list2.Add(food1);
            SaveToCloud("4", "果冻", text.Text, "33", true);
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "糖果";
             FoodMessage food1 = new FoodMessage("糖果", text.Text, "0", "33", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "糖果", text.Text, "33", true);
        }
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "黄瓜";
             FoodMessage food1 = new FoodMessage("黄瓜", text.Text, "0", "22", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "黄瓜", text.Text, "22", true);
        }
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "西红柿";
             FoodMessage food1 = new FoodMessage("西红柿", text.Text, "0", "22", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "西红柿", text.Text, "22", true);
        }
        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "韭菜";
             FoodMessage food1 = new FoodMessage("韭菜", text.Text, "0", "22", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "韭菜", text.Text, "22", true);
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
              text_Copy.Text = "南瓜";
              FoodMessage food1 = new FoodMessage("南瓜", text.Text, "0", "22", 4, true);
              list2.Add(food1);
              SaveToCloud("4", "南瓜", text.Text, "22", true);
        }

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "苦瓜";
             FoodMessage food1 = new FoodMessage("苦瓜", text.Text, "0", "22", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "苦瓜", text.Text, "22", true);
        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "蔬菜";
             FoodMessage food1 = new FoodMessage("蔬菜", text.Text, "0", "22", 4, true);
             list2.Add(food1);
             SaveToCloud("4", "蔬菜", text.Text, "22", true);
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
             text_Copy.Text = "胡萝卜";
             FoodMessage food1 = new FoodMessage("胡萝卜", text.Text, "0", "22", 4, true);
             list2.Add(food1);
             //MessageBox.Show(text.Text);
             SaveToCloud("4", "胡萝卜", text.Text, "22", true);
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {
            string str = JsonConvert.SerializeObject(list2);
            OptionTxt.writeTxt(str);
           // MessageBox.Show(text.Text);
            controller.Completed -= qSerialPort_Completed;
            this.Close();
        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            text.Text = "1000";
        }
    }
}
