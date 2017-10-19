using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ski_jumping_points_calculator {
    class Hill {
        private int kPointDistance; //116 m Lahden suurmäki
        private float kPointDistancePointsPerMeter; //1,8 > 100m
        private string hillName;
        List<SingleHill> hills;
        public Hill() {}
        public bool downloadHills() {
            hills = new List<SingleHill>();
            try {
                using (var fs = new FileStream(@"C:\devi\ECODE\ski-jumping-points-calculator\ski-jumping-points-calculator\assets\hills.json", FileMode.Open, FileAccess.Read))
                using (var sr = new System.IO.StreamReader(fs))
                {
                    string json = sr.ReadToEnd();
                    hills = JsonConvert.DeserializeObject<List<SingleHill>>(json);
                    sr.Close();
                    fs.Close();
                }
                return true;
            }
            catch (System.IO.FileNotFoundException e)
            {
                return false;
            }
        }

        public string getKPoint(string val) {
            var r = hills.Count != 0 ? hills.Find(c => c.Name.ToLower() == val.ToLower()): null;
            if (r != null) {
                return r.Kpoint;
            } else {
                return "";
            }
        }

        public void setKPoint(int kpoint) {
            this.kPointDistance = kpoint;
        }

        public int getKPointDistance() {
            return this.kPointDistance;
        }

        public float getKPointDistancePointsPerMeter() {
            return kPointDistancePointsPerMeter;
        }

        public void setKPointDistancePointsPerMeter() {
            if (this.kPointDistance >= 20 && this.kPointDistance <= 24)
            {
                kPointDistancePointsPerMeter = 4.8f;
            }
            else if (this.kPointDistance >= 25 && this.kPointDistance <= 29)
            {
                kPointDistancePointsPerMeter = 4.4f;
            }
            else if (this.kPointDistance >= 30 && this.kPointDistance <= 34)
            {
                kPointDistancePointsPerMeter = 4.0f;
            }
            else if (this.kPointDistance >= 35 && this.kPointDistance <= 39)
            {
                kPointDistancePointsPerMeter = 3.6f;
            }
            else if (this.kPointDistance >= 40 && this.kPointDistance <= 49)
            {
                kPointDistancePointsPerMeter = 3.2f;
            }
            else if (this.kPointDistance >= 50 && this.kPointDistance <= 59)
            {
                kPointDistancePointsPerMeter = 2.8f;
            }
            else if (this.kPointDistance >= 60 && this.kPointDistance <= 69)
            {
                kPointDistancePointsPerMeter = 2.4f;
            }
            else if (this.kPointDistance >= 70 && this.kPointDistance <= 79)
            {
                kPointDistancePointsPerMeter = 2.2f;
            }
            else if (this.kPointDistance >= 80 && this.kPointDistance <= 99)
            {
                kPointDistancePointsPerMeter = 2.0f;
            }
            else if (this.kPointDistance >= 100 && this.kPointDistance <= 169)
            {
                kPointDistancePointsPerMeter = 1.8f;
            }
            else if (this.kPointDistance >= 170 && this.kPointDistance <= 225)
            {
                kPointDistancePointsPerMeter = 1.2f;
            }
            else {
                kPointDistancePointsPerMeter = 0f;
            }
        }

    }
}
