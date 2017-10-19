using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;

namespace ski_jumping_points_calculator
{
    class Jumper
    {
        private string name;
        public Jumper() {}
        public string getFakeFullName()
        {
            using (var client = new HttpClient())
            {
                var url = @"https://uinames.com/api/?amount=1";
                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    var fakename = JsonConvert.DeserializeObject<FakeName>(responseString);
                    this.name = fakename.Name + " " + fakename.Surname;
                    return this.name;
                }
            }
            return "Matt Skijumper";
        }

        public string getJumpersName() {
            return name;
        }

        public void setJumper(string name) {
            this.name = name;
        }


    }
}
