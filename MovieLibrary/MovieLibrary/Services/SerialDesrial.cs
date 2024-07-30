using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace MovieLibrary.Services
{
 
    public class SerialDesrial
    {

        public static string filePath = ConfigurationManager.AppSettings["fileName"];

        public static void SerializeData(List<Movie> list)
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
        }

        public static List<Movie> DeserializeData()
        {
            List<Movie> list = new List<Movie>();
           
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                list = JsonConvert.DeserializeObject<List<Movie>>(json);
            }
            else
            {

                File.WriteAllText(filePath, JsonConvert.SerializeObject(list));
            }
            return list;
        }
    }
}
