using AVOSCloud;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace UitCapacityreFrigerator
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            AVClient.Initialize("xi2r682xdbqerl6h90g9atyty35s9im4tqtz6zyidcjsm990", "wxeygojpwf7sasdhtrbdagmc47nvktr1o4eipbwxzvvrdr2k");
            base.OnStartup(e);
        }
    }
}
 