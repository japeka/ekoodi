using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_points_calculator {
    class Jump {
        private string level;
        private double levelMeters = 0;
        private int jumpDistance = 0;
        private float jumpPoints = 0;
        private float[] stylePoints;
        private float fStylePoints;
        private float platformCompensationPoints = 0;
        private double windCompensation = 0f;
        public Jump() { }

        public void setPlatform(string level) {
            this.level = level;
        }

        public double calculatePlatformMeters() {
            double points;
            bool evalTest;
            evalTest = double.TryParse(this.level, out points);
            if (evalTest) {
                this.levelMeters = (points * -5);
                return this.levelMeters;
            } else {
                this.levelMeters = 0;
                return this.levelMeters;
            }
        }

        public double getLevelMeters() {
            return this.levelMeters;
        }


        public void setJumpDistance(int successLevel, int splitIntoHalf, int kPoint) {
            double unit = kPoint / 5;
            if (successLevel == 1)
            {
                jumpDistance = (int)Math.Round((kPoint - (3 * unit / splitIntoHalf)));
            }
            else if (successLevel == 2)
            {
                jumpDistance = (int)Math.Round((kPoint - (2 * unit / splitIntoHalf)));

            }
            else if (successLevel == 3)
            {
                jumpDistance = (int)Math.Round((kPoint - (unit / splitIntoHalf)));
            }
            else if (successLevel == 4)
            {
                jumpDistance = kPoint;
            }
            else if (successLevel == 5)
            {
                jumpDistance = (int)Math.Round((kPoint + (unit / 2)));
            }
        }

        public int getJumpDistance() {
            return jumpDistance;
        }

        public float calculatePointsForJump(int kPointDistance, float distancePointsPerMeter) {
            if (this.jumpDistance >= kPointDistance)
            {
                this.jumpPoints = 60 + ((jumpDistance - kPointDistance) * distancePointsPerMeter);
            }
            else {
                this.jumpPoints = 60 - ((kPointDistance - jumpDistance) * distancePointsPerMeter);
            }
            return this.jumpPoints;
        }

        public float getJumpPoints() {
            return this.jumpPoints;
        }

        public Tuple<string, string, float> getStylePoints() {
            string excluded = this.stylePoints[0] + " " + this.stylePoints[4];
            string included = this.stylePoints[1] + " " + this.stylePoints[2] + " " + this.stylePoints[3];
            float fStylePoints = this.stylePoints[1] + this.stylePoints[2] + this.stylePoints[3];
            return new Tuple<string, string, float>(excluded, included, fStylePoints);
        }

        public float getFStylePoints() {
            return fStylePoints;
        }

        public void handleStyles(RandomGenerator random) {
            int style = random.getSuccessLevel();
            stylePoints = new float[5];
            int rFour, rTwo, rThree;
            for (int i = 0, k = 2; i < 5; i++, k += 2) {
                long milliseconds = DateTimeOffset.Now.ToUnixTimeMilliseconds() + k;
                rFour = random.getRandom(milliseconds, 4);
                rTwo = random.getRandom(milliseconds, 2);
                rThree = random.getRandom(milliseconds, 3);
                if (style == 1) {
                    stylePoints[i] = 0.5f * rFour + 12;
                }
                if (style == 2) {
                    stylePoints[i] = 0.5f * rFour + 14;
                }
                if (style == 3) {
                    stylePoints[i] = 0.5f * rFour + 16;
                }
                if (style == 4) {
                    stylePoints[i] = 0.5f * rTwo + 18;
                }
                if (style == 5) {
                    stylePoints[i] = 0.5f * rThree + 19;
                }
            }
            Array.Sort(stylePoints); //just to make handling the array easier
        }
        
        public void setPlatformLevel(string platformLevel,float kPointDistPointsPerMeter){
            float level;
            bool evalTest = float.TryParse(platformLevel, out level);
            if (evalTest) {
              platformCompensationPoints = (-1 * level * 5) * kPointDistPointsPerMeter;
            } else {
              platformCompensationPoints = 0;
            }
        }

        public float getPlatformCompensationPoints() {
            return this.platformCompensationPoints;
        }

        public double getWindCompensation() {
            return this.windCompensation;
        }

        public void setWindCompensation(float kPointDistance, float kPointDistancePointsPerMeter) {
            Random rnd = new Random();
            int windSpeed = 0; 
            int windDirection=0; //0 -   1 +
            float windSum = 0;    
            for (int i = 0; i < 5; i++) {
                windDirection = rnd.Next(0, 2); //0,1
                windSpeed = rnd.Next(1, 31);
                if (windDirection == 0) {
                  windSum += (-1 * (windSpeed / 10));
                } else {
                  windSum += (1 * (windSpeed / 10));
                }
            }
            float meters = ((windSum / 5) * ((kPointDistance - 36) / 20));
            double roundedMeters = roundToHalfDecimal(meters);
            this.windCompensation = kPointDistancePointsPerMeter * roundedMeters * -1;
        }

        private double roundToHalfDecimal(float meters) {
            double floor = Math.Floor(meters); double ceiling = Math.Ceiling(meters); double middlePoint = floor + 0.5;
            double[] arr = new double[3]; double first,second,third;
            arr[0] = first = Math.Abs(meters - ceiling); arr[1] = second = Math.Abs(meters - middlePoint);
            arr[2] = third = Math.Abs(meters - floor); double min = arr.Min();
            if (min == first)
                return ceiling;
            else if (min == second)
                return middlePoint;
            else
                return floor;
        }
    }
}
