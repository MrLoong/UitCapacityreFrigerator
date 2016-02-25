using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitCapacityreFrigerator.Util
{
    public class Analysain
    {
        public static List<FoodMessage> FromJson(string json)
        {
            List<FoodMessage> jsonObject = null;
            try
            {

                jsonObject = (List<FoodMessage>)JsonConvert.DeserializeObject(json, typeof(List<FoodMessage>));

            }
            catch (Exception e)
            {

            }
            return jsonObject;
        }
        public static FoodCommand FromJson_foodCommand(string json)
        {
            FoodCommand jsonObject = null;
            try
            {

                jsonObject = (FoodCommand)JsonConvert.DeserializeObject(json, typeof(FoodCommand));

            }
            catch (Exception e)
            {

            }
            return jsonObject;
        }
    }
}
