using System;
using System.Text.RegularExpressions;
/*
Task 6
    Testing following string methods

    IndexOf
    Insert
    Length
    Replace
    Remove
    Split
    Substring
    Trim
    ToUpper
    ToLower
*/
namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            //indexOf//
            string str = "abcde";
            int ind = str.IndexOf('b');
            Console.WriteLine("{0}",ind);
            //position of char found in string -1 not found & !-1 found

            //insert//
            String original = "aaabbb";
            Console.WriteLine("The original string: '{0}'", original);
            String modified = original.Insert(3, "@");
            //insert at position new substring
            Console.WriteLine("The modified string: '{0}'", modified);

            //Length//
            Console.WriteLine("The length of modified string: '{0}'", modified.Length);

            //Replace//
            Console.WriteLine("Replaced version of modified string '{0}'",modified.Replace('@','å'));

            //Remove//
            string rStr = "1234567890";
            string removedStr1 = rStr.Remove(2); //12 otetaan n kpl merkkejä ja siitä eteenpäin ol. merkit pois
            string removedStr2 = rStr.Remove(2, 3); //12 ja 2 seuraavat merkkiä pois
            Console.WriteLine("{0} {1}", rStr, removedStr1); //12
            Console.WriteLine("{0} {1}", rStr, removedStr2); //1267890

            //Split #1 char array//
            string sStr = "ab+dd-ef gd";
            char[] separators = { ' ' ,'-' , '+'};
            string[] arrStr = sStr.Split(separators);
            foreach (string word in arrStr)
            {
                Console.WriteLine(word);
            }

            //Split #2 Regex//
            string rValue = "cat dog animal person";
            //string rValue = "cat\r\ndog\r\nanimal\r\nperson"; 
            string[] lines = Regex.Split(rValue, @"\s");
            foreach (string word in lines)
            {
                Console.WriteLine(word);
            }

            //Substring//
            string input = "OneTwoThree";
            string sub1 = input.Substring(0, 3);
            string sub2 = input.Substring(6);
            Console.WriteLine("Substring1: {0}", sub1); // One => kolme ekaa merkkiä
            Console.WriteLine("Substring2: {0}", sub2); // Otetaan 6. positio ja siitä eteenpäin loput

            //Trim//
            string st = "  This is an example string. ";
            string st1 = st.Trim();
            Console.WriteLine("Untrimmed: {0} Trimmed: {1}", st, st1);

            //ToUpper && ToLower//
            string name = "jaNnE";
            Console.WriteLine("Original {0} ToLower: {1} ToUPper: {2}", name, name.ToLower(), name.ToUpper() );

            Console.ReadKey();

        }
    }
}
