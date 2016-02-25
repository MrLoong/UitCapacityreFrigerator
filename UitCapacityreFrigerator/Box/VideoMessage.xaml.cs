using AVOSCloud;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
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
using WPFMediaKit.DirectShow.Controls;
using System.Threading;

namespace UitCapacityreFrigerator.Box
{
    /// <summary>
    /// VideoMessage.xaml 的交互逻辑
    /// </summary>
    public partial class VideoMessage : MetroWindow
    {
        AVObject photo;
        private string fileName = "";
        RoutedEventArgs e;
        Timer t;
        private System.Windows.Threading.DispatcherTimer dTimer = new System.Windows.Threading.DispatcherTimer();
        public VideoMessage()
        {
            InitializeComponent();
            photo = AVObject.CreateWithoutData("photo", "557283c3e4b0cfb2055d389b");
            if (MultimediaUtil.VideoInputNames.Length > 0)
            {
                vce.VideoCaptureSource = MultimediaUtil.VideoInputNames[0];
            }
            else
            {
                MessageBox.Show("未检测到任何可用摄像头!");
            }


            dTimer.Tick += new EventHandler(dTimer_Tick);
            dTimer.Interval = new TimeSpan(0,0,3);

            dTimer.Start();

           
           // Button_Click(this,e);
           // Cream();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)vce.ActualWidth, (int)vce.ActualHeight, 96, 96, PixelFormats.Default);
            bmp.Render(vce);
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                byte[] captureData = ms.ToArray();
                fileName = @"C:\temp\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                File.WriteAllBytes(fileName, captureData);
                SaveFile(captureData, DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");
               // MessageBox.Show(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");
               /// Thread.Sleep(1000);
               // AVFile localFile = AVFile.CreateFileWithLocalPath(DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", System.IO.Path.Combine(@"D:\temp\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg", DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg"));


            }
            string path = System.AppDomain.CurrentDomain.BaseDirectory + fileName;
            if (System.IO.File.Exists(path))
            {
                BitmapImage bmp1 = new BitmapImage();

                bmp1.BeginInit();

                bmp1.UriSource = new Uri(path, UriKind.Absolute);

                img.Source = bmp1;
                bmp1.CacheOption = BitmapCacheOption.OnLoad;

                bmp1.EndInit();

                MessageBox.Show("照片保存在Debug目录下photos文件夹内。");

                //BitmapImage img1 = (BitmapImage)img.SelectedItem;

                //File.Delete(img1.UriSource.ToString());

                File.Delete(fileName);
                //img.Source = null;
            }
        }

        private void dTimer_Tick(object sender,EventArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(delegate
            {
              //  MessageBox.Show("ok");

                dTimer.Stop();
                RenderTargetBitmap bmp = new RenderTargetBitmap((int)vce.ActualWidth, (int)vce.ActualHeight, 96, 96, PixelFormats.Default);
                bmp.Render(vce);
                BitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    byte[] captureData = ms.ToArray();
                    fileName = @"C:\temp\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                    File.WriteAllBytes(fileName, captureData);
                
                    SaveFile(captureData, DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");                
                }

            }), null);
        }



        private  void Button_Click_2(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        public async void SaveFile(byte[] data, string name)
        {
            AVFile file = new AVFile(name, data, new Dictionary<string, object>()
                {
                {"author","AVOSCloud"}
                });


            AVObject photo = AVObject.CreateWithoutData("photo", "55acdce0e4b044ac283609af");
            await photo.SaveAsync().ContinueWith(t =>
            {
                // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改
                photo["ss"] = file;
                photo.SaveAsync();
            }); 
        
           
            /*await photo.SaveAsync().ContinueWith(t =>
            {
                // 保存成功之后，修改一个已经在服务端生效的数据，这里我们修改age
                // LeanCloud 只会针对指定的属性进行覆盖操作，本例中的name不会被修改\
            
                photo["ss"] = file;
                photo.SaveAsync();

                MessageBox.Show("ok");
            });*/


           
        }
    }
}
