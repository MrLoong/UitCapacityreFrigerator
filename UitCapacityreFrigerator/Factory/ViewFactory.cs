using AVOSCloud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using UitCapacityreFrigerator.Util;

namespace UitCapacityreFrigerator.Factory
{
    public class ViewFactory
    {
        private static StackPanel stackPanl;
        public static StackPanel getView(string type, double waterHeater, double heating)
        {
            //double all = bulb_1 + bulb_2 + ac + waterHeater + 6.5 ;
            stackPanl = new StackPanel();
            setWH();
            setHeader();
            List<FoodMessage> list = Analysain.FromJson(OptionTxt.readTxt("C:\\2.txt"));
           // List<FoodMessage> list = new List<FoodMessage>();
            foreach (FoodMessage lists in list)
            {
                if (lists.foodType.Equals(type))
                {
                    setViewContent(lists.foodName, lists.foodNumber);
                }
                if (type.Equals("all") && !lists.foodName.Equals("00"))
                {
                    setViewContent(lists.foodName, lists.foodNumber);
                }
                if(type.Equals("over"))
                {
                    int x = MainWindow.futureDay - DateTime.Now.Day + (MainWindow.futureMonth - DateTime.Now.Month) * 30;
                   // MessageBox.Show(x.ToString());
                    if (x-lists.day<=0&&!lists.foodName.Equals("00"))
                    {
                       // MessageBox.Show("OK");
                        setViewContent(lists.foodName, lists.foodNumber);
                        updateCloud(lists.foodName,lists.foodType);
                    }
                }
            }
            /*setViewContent("电灯Ⅰ", bulb_1);
            setViewContent("电灯 Ⅱ", bulb_2);
            setViewContent("空调", ac);
            setViewContent("热水器", waterHeater);
            setViewContent("电热水壶", 6.5); */
            // setEnd(all);

            // setPrice(all); 
            return stackPanl;
        }
        public static async void updateCloud(string foodname,string type)
        {
            if (type.Equals("11"))
            {
                AVQuery<AVObject> delete = new AVQuery<AVObject>("Fruit");
                delete = delete.WhereEqualTo("name", foodname);

                await delete.FindAsync().ContinueWith(s =>
                {
                    IEnumerable<AVObject> boys = s.Result;

                    AVObject ob = boys.ElementAt(0);
                    ob.SaveAsync().ContinueWith(t =>
                    {
                        // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                        // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改
                        ob["state"] = false;
                        ob.SaveAsync();

                    });

                });

            }
            if (type.Equals("22"))
            {
                AVQuery<AVObject> delete = new AVQuery<AVObject>("Vegetable");
                delete = delete.WhereEqualTo("name", foodname);

                await delete.FindAsync().ContinueWith(s =>
                {
                    IEnumerable<AVObject> boys = s.Result;

                    AVObject ob = boys.ElementAt(0);
                    ob.SaveAsync().ContinueWith(t =>
                    {
                        // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                        // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改
                        ob["state"] = false;
                        ob.SaveAsync();

                    });

                });

            }
            if (type.Equals("33"))
            {
                AVQuery<AVObject> delete = new AVQuery<AVObject>("Food");
                delete = delete.WhereEqualTo("name", foodname);

                await delete.FindAsync().ContinueWith(s =>
                {
                    IEnumerable<AVObject> boys = s.Result;

                    AVObject ob = boys.ElementAt(0);
                    ob.SaveAsync().ContinueWith(t =>
                    {
                        // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                        // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改
                        ob["state"] = false;
                        ob.SaveAsync();

                    });

                });

            }

        }

        private static void setWH()
        {

            stackPanl.Orientation = Orientation.Vertical;
            //     stackPanl.HorizontalAlignment = HorizontalAlignment.Center;
            // stackPanl.Width = 888;
            //stackPanl.Height = 510;
        }


        private static void setHeader()
        {
            stackPanl.Children.Add(getChildStackPanel("名称", "数量", 0));
            stackPanl.Children.Add(getRectangle(4));
        }

        private static void setEnd(double all)
        {
            stackPanl.Children.Add(getChildStackPanel("共计", all + " kW·h", 1));
            stackPanl.Children.Add(getRectangle(2));
        }

        private static void setPrice(double all)
        {

            stackPanl.Children.Add(getChildStackPanel("金额", (all * 0.5) + " RMB", 1));
            stackPanl.Children.Add(getRectangle(4));
        }
        private static void setViewContent(string item, string energy)
        {
            stackPanl.Children.Add(getChildStackPanel(item, energy, 1));
            if ("Heater" != item)
            {
                stackPanl.Children.Add(getRectangle(2));
            }
        }

        private static Rectangle getRectangle(int hight)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = hight;
            rectangle.Width = 600;
            rectangle.StrokeThickness = 0;
            rectangle.Fill = Brushes.Black;
            rectangle.Margin = new Thickness(10);
            return rectangle;
        }
        private static StackPanel getChildStackPanel(string name, string power, int color)
        {
            StackPanel childStackPanl = new StackPanel();
            childStackPanl.Orientation = Orientation.Horizontal;

            if (color == 2)
            {
                childStackPanl.Margin = new Thickness(188, 0, 0, 60);
            }
            else
            {
                childStackPanl.Margin = new Thickness(188, 0, 0, 0);
            }


            TextBlock textBlock_name = new TextBlock();
            textBlock_name.Text = name;
            textBlock_name.Width = 380;
            textBlock_name.FontSize = 28;



            TextBlock textBlock_power = new TextBlock();
            textBlock_power.Text = power;
            textBlock_power.Width = 160;
            textBlock_power.FontSize = 28;

            if (color == 0)
            {
                textBlock_name.Foreground = Brushes.Gray;
                textBlock_power.Foreground = Brushes.Gray;
            }
            else
            {
                textBlock_name.Foreground = Brushes.Black;
                textBlock_power.Foreground = Brushes.Black;
            }
            childStackPanl.Children.Add(textBlock_name);
            childStackPanl.Children.Add(textBlock_power);

            // childStackPanl.HorizontalAlignment = HorizontalAlignment.Center;
            return childStackPanl;
        }
    }
}
