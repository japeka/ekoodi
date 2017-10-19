using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_points_calculator {
    class RandomGenerator {
        int successLevel;
        int splitIntoHalf;
        public RandomGenerator() {}

        public void setSuccessLevel() {
            Random rnd = new Random();
            successLevel = rnd.Next(1, 6);
            splitIntoHalf = rnd.Next(1, 3);
        }

        public int getRandom(long seconds,int n) {
            char last = seconds.ToString()[seconds.ToString().Length - 1];
            int num; bool evalTest = int.TryParse(last.ToString(), out num);
            if (evalTest) {
                if (n == 4) {
                    if (num >= 0 && num <= 2) {
                        return 0;
                    }
                    else if (num >= 3 && num <= 5) {
                        return 1;
                    }
                    else if (num >= 6 && num <= 8) {
                        return 2;
                    }
                    else {
                        return 3;
                    }
                }
                else if (n == 3) {
                    if (num >= 0 && num <= 3)
                    {
                        return 0;
                    }
                    else if (num >= 4 && num <= 7)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else if (n == 2) {
                    if (num >= 0 && num <= 5)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else {
                Random rnd = new Random();
                return rnd.Next(0, n); 
            }
            return 0;                
        }

        public int getSplitIntoHalf() {
            return this.splitIntoHalf;
        }

        public int getSuccessLevel() {
            return this.successLevel;
        }
    }
}
