using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitCapacityreFrigerator.Util
{
    public class FoodCommand
    {
        public string message;
        public string conmmand;

        public FoodCommand()
        {
            message = "message";
            conmmand = "command";
        }
        public void setMessage(string m)
        {
            message = m;
        }
        public void setMCommand(string c)
        {
            conmmand = c;

        }
    }
}
