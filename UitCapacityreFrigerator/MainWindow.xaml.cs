using AVOSCloud;
using Newtonsoft.Json;
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
using UitCapacityreFrigerator.Box;
using UitCapacityreFrigerator.Communication;
using UitCapacityreFrigerator.Factory;
using UitCapacityreFrigerator.Util;

namespace UitCapacityreFrigerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static IController controller;
        public static int futureMonth = 0;
        public static int futureDay = 0;
        public static int futureHour = 0;
        public static int futureMinute = 0;
        public static int old_Total = 0;
        public static int new_Total = 0;

        public static int xx = 0;    //苹果
        public static int yy = 0;    //柠檬
        public static int zz = 0;    //酸奶
        public static int cc = 0;   //黄瓜
        public MainWindow()
        {
            InitializeComponent();
            //AVClient.Initialize("xi2r682xdbqerl6h90g9atyty35s9im4tqtz6zyidcjsm990", "wxeygojpwf7sasdhtrbdagmc47nvktr1o4eipbwxzvvrdr2k");

            inItReport();//统计页面初始化
            InitFutureTime();//未来时间初始化设置
            controller = new IController();
            controller.OpenSerialPort("COM5", "9600", "8", "One", "None", "None");
            controller.Completed += qSerialPort_Completed;
            //controller.Completed += qSerialPort_Completed;
        }
        public static IController getIController()
        {
            return controller;
        }
        /// <summary>
        /// 本地数据初始化
        /// </summary>
        private void inItData()
        {
        }

        /// <summary>
        /// 暖气温度初始化
        /// </summary>
        private void inItHeartTemp()
        {
        }

        /// <summary>
        /// 初始化统计页面
        /// </summary>
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
            report_FlipView.Items.Add(ViewFactory.getView("all", 4.2, 3.0));


            yearButton.SelectedIndex = 0;
            monthButton.SelectedIndex = DateTime.Now.Month-1;
            dayButton.SelectedIndex = DateTime.Now.Day-1;
            report_FlipView.SelectedIndex = 17;
            
        }
        /// <summary>
        /// 初始化未来时间设置
        /// </summary>
        private void InitFutureTime()
        {
            string[] month = new string[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月" };
            List<string> monthlist = new List<string>();
            for (int i = 0; i < 12;i++ )
            {
                monthlist.Add(month[i]);
            }
            waterHaterOpenHourSBtn.ItemsSource = monthlist;
            List<string> dayList = new List<string>();
            for (int i = 1; i < 32; i++)
            {
                dayList.Add(i + "");
            }
            waterHaterOpenMinuteSBtn.ItemsSource = dayList;
            List<string> hour = new List<string>();
            for (int i = 1; i < 24; i++)
            {
                hour.Add(i + "");
            }
            waterHaterCloseHourSBtn.ItemsSource = hour;
            List<string> minute = new List<string>();
            for (int i = 1; i < 61; i++)
            {
                minute.Add(i + "");
            }
            waterHaterCloseMinuteSBtn.ItemsSource = minute;

            waterHaterOpenHourSBtn.SelectedIndex = 5;
            waterHaterOpenMinuteSBtn.SelectedIndex = 30;

        }
        /// <summary>
        /// 设置界面初始化
        /// </summary>
        private void inItSetting()
        {
            inItWaterHeaterAuto();
        }
        /// <summary>
        /// 热水器自动开启数据初始化
        /// </summary>
        private void inItWaterHeaterAuto()
        {

        }
        /// <summary>
        /// 通信模块初始化
        /// </summary>
        private void inItCommunication()
        {
            inItSocket();
            inItSerialPort();
        }

        /// <summary>
        /// 开启服务器
        /// </summary>
        private void inItSocket()
        {

        }

        /// <summary>
        /// 串口通信初始化 打开串口并开启接收数据
        /// </summary>
        private void inItSerialPort()
        {

        }

        /// <summary>
        /// 开启服务器
        /// </summary>
        private void startServer()
        {

        }
        /// <summary>
        /// （委托）接收到手机发送的消息 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void socketServer_Completed(object sender, string e)
        {


        }
        /// <summary>
        /// 设置暖气温度
        /// </summary>
        /// <param name="data"></param>
        private void setHeaterTemp(string data)
        {
            string info = data.Substring(4, 2);
        }


        /// <summary>
        /// 保存开关信息到本地
        /// </summary>
        /// <param name="data"></param>
        private void saveData(string data)
        {
          //  FileHelper.saveData(data);
        }

        /// <summary>
        /// 异步查询数据数据
        /// </summary>
        /// <param name="obj"></param>
        private void AsyReceiveSearchData()
        {

        }
        private void showText(String smg)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
                MessageBox.Show(smg);
            }), null);
        }
        /// <summary>
        /// 回调函数 接收到串口发送的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void qSerialPort_Completed(object sender, string data)
        {
            try
            {
                FoodCommand foodCommand = Analysain.FromJson_foodCommand(data);
                /* if (foodCommand.conmmand.Equals("temp"))
                 {
                     //MessageBox.Show(data);
                      //this.ok1.Text = foodCommand.message.Substring(0, 2);
                     //this.ok2.Text = foodCommand.message.Substring(2, 2);
               
                     Dispatcher.BeginInvoke((ThreadStart)delegate()
                     {
                         this.ok1.Text = foodCommand.message.Substring(0, 2);
                         this.ok2.Text = foodCommand.message.Substring(2, 2);
                         saveToCloud("Temperature", this.ok1.Text + " °C");
                         saveToCloud2("Humidity", this.ok2.Text + " %");
                     });
                 }*/
                if (foodCommand.conmmand.Equals("weight") && foodCommand.message.Substring(0, 1).Equals("-"))
                {
                    //MessageBox.Show(foodCommand.message.Substring(1));
                    dealWith(Int32.Parse(foodCommand.message.Substring(1)));
                    //  MessageBox.Show(foodCommand.message);
                }
            }
            catch(Exception e)
            {

            }
            finally
            {

            }
        }

        /// <summary>
        /// 上云传温湿度
        /// </summary>
        public async void saveToCloud(string name,string data)
        {
            AVObject Temperature = AVObject.CreateWithoutData("Temperature", "5575072de4b0f22726a105b0");
            await Temperature.SaveAsync().ContinueWith(t =>
            {
                // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改
                Temperature["temperature"] = data;
                Temperature.SaveAsync();
            });


        }
        public async void saveToCloud2(string name, string data)
        {
            AVObject Humidity = AVObject.CreateWithoutData("Humidity", "5575072de4b0f22726a105af");
            await Humidity.SaveAsync().ContinueWith(t =>
            {
                // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改
                Humidity["humidity"] = data;
                Humidity.SaveAsync();
            });           
        }
        /// <summary>
        /// Tab切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// 设置Tab按钮图片
        /// </summary>
        /// <param name="old"></param>
        private void setImageSource(int old)
        {

        }

        /// <summary>
        /// 设置界面FlipView切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void settingFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inItReport();
        }

        /// <summary>
        /// 统计界面FlipView切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
           // dayButton.SelectedIndex = report_FlipView.SelectedIndex;
        }

        /// <summary>
        /// 统计界面 年份选择切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // yearButton.SelectedIndex
        }

        /// <summary>
        ///  统计界面 月份选择切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            monthButton.SelectedIndex = 6;
        }

        /// <summary>
        ///  统计界面 日期选择切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            report_FlipView.SelectedIndex = dayButton.SelectedIndex;


            // MessageBox.Show("SS");
        }

        /// <summary>
        /// 设置界面温度选择切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //tempButton.SelectedIndex
        }


        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MyClose();
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        private void MyClose()
        {
            if (MessageBoxResult.OK == MessageBox.Show("退出？", "", MessageBoxButton.OKCancel))
            {
                // fileManager.write(Constant.HEATINGTEMPPATH,setTemp.heartTemp.ToString());
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// 水果查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void oulteTitleClick(object sender, RoutedEventArgs e)
        {
            Show1 show1 = new Show1();
            show1.Show();

        }
        /// <summary>
        /// 相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lihgtsTileClick(object sender, RoutedEventArgs e)
        {
            VideoMessage video = new VideoMessage();
            video.Show();

        }

        /// <summary>
        /// 蔬菜查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waterHeaterTileClick(object sender, RoutedEventArgs e)
        {
            Show2 show2 = new Show2();
            show2.Show();


        }

        /// <summary>
        /// 过期物品提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acTileClick(object sender, RoutedEventArgs e)
        {
           // Remind remind = new Remind();
           // remind.Show();
            //Titp t = new Titp("黄瓜不足");
            //t.Show();
            Overdue over = new Overdue();
            over.Show();
        }
        /// <summary>
        /// 光伏电池
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beatteryTileClick(object sender, RoutedEventArgs e)
        {
            Show3 show3 = new Show3();
            show3.Show();
            //BeatteryMessageBox beatteryMessageBox = new BeatteryMessageBox();
            // beatteryMessageBox.Show();
        }
        /// <summary>
        /// 录入物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void heatingTileClick(object sender, RoutedEventArgs e)
        {
            InformationInput input = new InformationInput();
            input.Show();
        }
        /// <summary>
        /// 保存设置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveDataClick(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 设置未来月
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            futureMonth = waterHaterOpenHourSBtn.SelectedIndex;
           // public static int futureDay = 0;
           // public static int futureHour = 0;
           // public static int futureMinute = 0;
        }

        /// <summary>
        /// 设置未来 天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openMinute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            futureDay = waterHaterOpenMinuteSBtn.SelectedIndex;
        }
        /// <summary>
        /// 设置未来 时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeHour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            futureHour = waterHaterCloseHourSBtn.SelectedIndex;
        }
        /// <summary>
        /// 设置未来 分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeMinute_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            futureMinute = waterHaterCloseMinuteSBtn.SelectedIndex;
        }
        /// <summary>
        /// 热水器智能开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waterHeaterAutoSwitch_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 保存热水器自动开关信息
        /// </summary>
        /// <param name="data"></param>
        private void saveWaterHeaterAutoData()
        {

        }
        /*****************************TEST***************************************************************TEST**********************************
         * 
         * 
         * 
         *****************************TEST***************************************************************TEST**********************************/

        private void showMessage(string msg)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Remind remind = new Remind();
            remind.Show();
          
        }
        /// <summary>
        /// 设置暖气温度
        /// </summary>
        /// <param name="data"></param>
        public void dealWith(int temp)
        {

            List<FoodMessage> list2 = Analysain.FromJson(OptionTxt.readTxt("C:\\2.txt"));
            foreach (FoodMessage lists in list2)
            {
                if((Int32.Parse(lists.foodNumber)>=temp))
                {
                    if ((Int32.Parse(lists.foodNumber) - temp <= 10)&&!lists.foodName.Equals("00"))
                         {
                             MessageBox.Show(lists.foodName);
                             //jude(lists.foodName);
                             list2.Remove(lists);
                             deleteCloud(lists.foodName,lists.foodType);
                             jude(lists.foodName);
                             string str = JsonConvert.SerializeObject(list2);
                             OptionTxt.writeTxt(str);                   
                             break;             
                         } 
                }
                else
                {
                    if (Int32.Parse(lists.foodNumber) - temp >= -10 && !lists.foodName.Equals("00"))
                    {
                        MessageBox.Show(lists.foodName);
                        list2.Remove(lists);
                        deleteCloud(lists.foodName, lists.foodType);
                        jude(lists.foodName);
                        string str = JsonConvert.SerializeObject(list2);
                        OptionTxt.writeTxt(str);
                        break;
                    }
                }
                
              //  x++;
            }
        }
        public async void deleteCloud(string foodname,string type)
        {
            if(type.Equals("11"))
            {
               
                AVQuery<AVObject> delete = new AVQuery<AVObject>("Fruit");
                delete = delete.WhereEqualTo("name", foodname);

                await delete.FindAsync().ContinueWith(s =>
                {
                    IEnumerable<AVObject> boys = s.Result;

                    AVObject ob = boys.ElementAt(0);
                    ob.DeleteAsync();

                });

            }
            if(type.Equals("22"))
            {
               // MessageBox.Show(foodname);
                AVQuery<AVObject> delete = new AVQuery<AVObject>("Vegetable");
                delete = delete.WhereEqualTo("name", foodname);

                await delete.FindAsync().ContinueWith(s =>
                {
                    IEnumerable<AVObject> boys = s.Result;

                    AVObject ob = boys.ElementAt(0);
                    ob.DeleteAsync();

                });

            }
            if (type.Equals("33"))
            {
              //  MessageBox.Show(foodname);
                AVQuery<AVObject> delete = new AVQuery<AVObject>("Food");
                delete = delete.WhereEqualTo("name", foodname);

                await delete.FindAsync().ContinueWith(s =>
                {
                    IEnumerable<AVObject> boys = s.Result;

                    AVObject ob = boys.ElementAt(0);
                    ob.DeleteAsync();

                });
            }            
        }
        public async void lol(string name)    //上传不足物品信息
        {
            AVObject overdue = new AVObject("overdue");
            overdue["name"] = name;
            Task saveTask = overdue.SaveAsync();
            await saveTask;
        }
        public void jude(string name)
        {
           

            if (name.Substring(0, 2).Equals("苹果"))
            {
                MainWindow.xx--;
                if(xx==1)
                {
                    MessageBox.Show("缺少苹果");
                }
            }
            if (name.Substring(0, 2).Equals("+C"))
            {
                MainWindow.yy--;
                if (yy == 1)
                {
                    Dispatcher.BeginInvoke((ThreadStart)delegate()
                    {
                        Titp titp = new Titp(name.Substring(0, 2));

                        titp.Show();
                    });

                    lol(name.Substring(0, 2));
                }
            }
            if (name.Substring(0, 2).Equals("黄瓜"))
            {
               // MessageBox.Show("okokokokokokoko");
                MainWindow.cc--;
                if (cc == 1)
                {
                    Dispatcher.BeginInvoke((ThreadStart)delegate()
                    {
                        Titp titp = new Titp(name.Substring(0,2));

                        titp.Show();
                    });
                    
                }
            }
            if (name.Substring(0, 2).Equals("酸奶"))
            {
                MainWindow.zz--;
                if (zz == 1)
                {
                    MessageBox.Show("缺少酸奶");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = OptionTxt.readTxt("C:\\clean.txt");
            OptionTxt.writeTxt(str);

            MessageBox.Show("清空完成");
        }
    }
}
