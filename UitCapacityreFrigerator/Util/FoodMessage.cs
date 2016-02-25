using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitCapacityreFrigerator.Util
{
    public class FoodMessage
    {
        public string foodName;
        public string foodNumber;
        public string foodId;
        public string foodType;
        public int day;
        public bool state;

        public FoodMessage(string name, string number, string id, string type,int d,bool s)
        {
            foodId = id;
            foodName = name;
            foodNumber = number;
            foodType = type;
            day = d;
            state = s;

        }
        public string getId()
        {
            return this.foodId;
        }
    }
}
