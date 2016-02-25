using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitCapacityreFrigerator.Util
{
    public class OptionTxt
    {
        public OptionTxt()
        {
        }
        public static void writeTxt(string str)
        {
            StreamWriter sw = new StreamWriter("C:\\2.txt");
            sw.Write(str);
            sw.Close();
        }
        public static void appendTxt()
        {
            StreamWriter sw = File.AppendText("D:\\1.txt");
            string w = "2";
            sw.Write(w);
            sw.Close();
        }
        public static string readTxt(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                sr.Close();
                return line;
            }
            return "shi";
        }
    }
}
