using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace weather_app {

    class WeatherUtility {

        private string Location; 
        private string RequestURL;
        private string UserSelection;
        private string APIKEY = "52087b841a0e19eae02720bc08ef0b5b";
        public WeatherUtility() {}

        private void GetRequestURL() {
            if (this.UserSelection == "1") {
                string[] words = this.Location.Split(',');
                this.RequestURL = string.Format(@"http://api.openweathermap.org/data/2.5/{0}?q={1}&appid={2}&lang={3}&units=metric", "weather", this.Location, APIKEY, words[1]);
            }
            if (this.UserSelection == "2") {
                string[] words = this.Location.Split(',');
                this.RequestURL = string.Format(@"http://api.openweathermap.org/data/2.5/{0}?q={1}&appid={2}&lang={3}&units=metric", "forecast", this.Location, APIKEY, words[1]);
            }
        }

        private void PromptLocation() {
            string userInput;
            while (true) {
                Console.Write("Enter your city and country code separated with a comma: ");
                userInput = Console.ReadLine();
                if (Regex.IsMatch(userInput, @"^[a-öA-Ö]{2,},[a-zA-Z]{2}$")) {
                    this.Location = userInput.ToLower();
                    break;
                }
            }
        }

        public void PromptUser() {
            while (true) {
                Console.WriteLine("______________Weather Application______________");
                Console.WriteLine("To get weather forecast for the current day enter 1");
                Console.WriteLine("To get weather forecast for the 5 next days enter 2");
                Console.WriteLine("To exit the program hit any other key");
                Console.Write("Enter your selection: ");
                string userInput = Console.ReadLine();
                if (userInput == "1") {
                  this.UserSelection = "1";
                  PromptLocation(); GetRequestURL(); GetWeatherData();
                } else if (userInput == "2") {
                  this.UserSelection = "2";
                  PromptLocation(); GetRequestURL();GetWeatherData();
                }
                else {
                   break;
                }
            }
            Console.WriteLine("Thank you for using weather app!"); Console.ReadKey();
        }

        private void GetWeatherData() {
            try {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(this.RequestURL).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content;
                        string responseString = responseContent.ReadAsStringAsync().Result;
                        if (this.UserSelection == "1")
                        {
                            //current day's weather
                            var Weather = JsonConvert.DeserializeObject<model.Weather>(responseString);
                            Console.WriteLine("________________________________________\nLocation: \t\t{0}\nTemperature: \t\t{1} celcius degrees\nWind Speed: \t\t{2}m/s\nWeather Description: \t{3}\n",
                                Weather.LocationName, Weather.Measurement.Temperature,Weather.Wind.Speed, Weather.Descriptions[0].Description
                            );
                        }
                        else {
                            //5 days forecast
                            var Forecast = JsonConvert.DeserializeObject<model.Forecast>(responseString);
                            Console.WriteLine("\nThe Weather Forecast For {0}", Forecast.City.Name);
                            if (Forecast.Descriptions.Capacity != 0)
                            {
                                int counter = 1;
                                foreach (model.ForecastDescription Description in Forecast.Descriptions) {
                                    if (counter % 8 == 0) {
                                      Console.WriteLine("\nDate: \t\t\t{0}", Description.DateTxt);
                                      Console.WriteLine("Temperature: \t\t{0} celcius degrees", Description.Measurement.Temperature);
                                      Console.WriteLine("Wind Speed: \t\t{0} m/s\n________________________________________", Description.Wind.Speed);
                                    }    
                                    counter++;
                                }
                                Console.Write("\n");
                            }
                            else {
                                Console.WriteLine("\nNo weather forecast data available for the 5 next days!\n");         
                            }
                        }
                        return;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine("Exception occured\n"+ e.ToString());
                return;
            }
            return;
        }
    }
}
