/*
 * This program can run on Windows or Linux which takes as input the name of a
city and provides information about the weather for that city.

Name: Sean Chen
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace weatherAPI

{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            //set global variables
            HttpResponseMessage response;
            string result;
         
            Console.WriteLine("* Welcome to the weather station hosted by Sean Chen *");
            Console.Write("\n\nPlease input a city name: ");

            while (check)
            {              
                string city = Console.ReadLine();

                using (var client = new HttpClient())
                {
                    //make the API call
                    client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
                    response = client.GetAsync("weather?q=" + city + "&APPID=0bee2c23e9f918280c8cd64bde552d5a").Result;
                    try
                    {
                        check = false;
                        response.EnsureSuccessStatusCode();
                    }
                    catch
                    {
                        //catch the error
                        check = true;
                        Console.Write("Error: ");
                        Console.WriteLine(response.StatusCode);
                        Console.Write("\nPlease input a valid city name: ");
                        continue;

                    }


                }
                 result = response.Content.ReadAsStringAsync().Result;
                Rootobject weatherDetails = JsonConvert.DeserializeObject<Rootobject>(result);

                //get the temperature and convert the int type celsius number
                double tempCelsius = weatherDetails.main.temp - 273.15;
                int tempInt = Convert.ToInt32(tempCelsius);

                //display the weather information
                Console.WriteLine("\nThe temperature: " + tempInt +" °C");
                Console.WriteLine("\nThe pressure: "+ weatherDetails.main.pressure + " hpa");
                Console.WriteLine("\nThe humidity: "+ weatherDetails.main.humidity + " %");
                Console.WriteLine("\nThe wind speed: " + weatherDetails.wind.speed + " m/s");
                Console.WriteLine("\nThe Geo coords: [" + weatherDetails.coord.lat + ", " + weatherDetails.coord.lon + "]");
            }

            Console.WriteLine("\nThank you for using the weather station!\n");
            
        }
    }
public class Rootobject
        {
            public Coord coord { get; set; }
            public Weather[] weather { get; set; }
            public string _base { get; set; }
            public Main main { get; set; }
            public Wind wind { get; set; }
            public Clouds clouds { get; set; }
            public Rain rain { get; set; }
            public int dt { get; set; }
            public Sys sys { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public int cod { get; set; }
        }

        public class Coord
        {
            public float lon { get; set; }
            public float lat { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public int deg { get; set; }
        }

        public class Clouds
        {
            public int all { get; set; }
        }

        public class Rain
        {
            public int _3h { get; set; }
        }

        public class Sys
        {
            public int type { get; set; }
            public int id { get; set; }
            public float message { get; set; }
            public string country { get; set; }
            public int sunrise { get; set; }
            public int sunset { get; set; }
        }

        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

    }



