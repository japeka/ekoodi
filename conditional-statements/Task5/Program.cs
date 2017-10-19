using System;
/*
TASK 5
Toteuta Maatalousnäyttelyn lipunhinnan muodostuminen C# -ohjelmointikielellä.
Perustiedot
Kysytään asiakkaan tiedot
Lasketaan alennus
Ilmoitetaan lipun hinta
Ehdot: Vain yksi alennus myönnetään. Paitsi, jos on opiskelija sekä Mtk:n jäsen, hän saa molemmat alennukset.
Normaalihinta 16 e
Alle 7 v. ilmaiseksi
65 v. ja yli: 50 % alennus
7-15 v. 50% alennus
Mtk jäsen: 15 % alennus
Varusmies: 50 % alennus
Opiskelija: 45 % alennus 
*/
namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("************************");
            Console.WriteLine("Ticket Counting Program");
            Console.WriteLine("************************\n");

            //ticket price hardcoded
            float ticketPrice = 16.0f;

            // Prompt user for age
            Console.Write("Please enter your age: ");

            String userInputAge;
            userInputAge = Console.ReadLine();
            int age;
            bool evalAgeTest = int.TryParse(userInputAge, out age);
            if (evalAgeTest)
            {
                if (age >= 0 && age <= 120)
                {
                    if (age >= 0 && age < 7)
                    {//100%
                        Console.WriteLine("Ticket costs 0 euros");
                    }
                    else if ((age >= 7 && age <= 15) || (age >= 65 && age < 120))
                    {   //50% discount
                        //Console.WriteLine("(age >= 7 && age <= 15) || (age >= 65 && age < 120)");
                        countDiscountForRole(50.0f, ticketPrice);
                    }
                    else {  //0%
                        //Console.WriteLine("Age not between the ranges");
                        countDiscountForRole(0.0f, ticketPrice);
                    }
                }
                else {
                    Console.WriteLine("The age range needs to be between 0 and 120 years");
                }
            }
            else {
                Console.WriteLine("Invalid age input!");
            }

            Console.ReadKey();

        }

        static void countDiscountForRole(float discountAge, float ticketPrice) {
            //age based discount
            float discount = ticketPrice * (discountAge / 100);
            //discounted price
            float discountedSum = (ticketPrice - discount);

            //User inputs for role (mtk-partner, draftee, student)
            Console.WriteLine("User role selection");
            Console.Write("Are you a MTK-partner(1 = yes): ");
            String userInputRoleMtk;
            userInputRoleMtk = Console.ReadLine();
            int selectionMtk;
            bool evalRoleMtkTest = int.TryParse(userInputRoleMtk, out selectionMtk);
            bool bMth = evalRoleMtkTest && selectionMtk == 1 ? true : false;

            // Prompt user for user role (draftee)
            Console.Write("Are you a draftee(1 = yes): ");
            String userInputRoleDraftee;
            userInputRoleDraftee = Console.ReadLine();
            int selectionDraftee;
            bool evalRoleDrafteeTest = int.TryParse(userInputRoleDraftee, out selectionDraftee);
            bool bDraftee = evalRoleDrafteeTest && selectionDraftee == 1 ? true : false;

            // Prompt user for user role (student)
            Console.Write("Are you a student(1 = yes): ");
            String userInputRoleStudent;
            userInputRoleStudent = Console.ReadLine();
            int selectionStudent;
            bool evalRoleStudentTest = int.TryParse(userInputRoleStudent, out selectionStudent);
            bool bStudent = evalRoleStudentTest && selectionStudent == 1 ? true : false;
            if (bMth && bStudent) //if Mth-partner && Student 
            {
                Console.WriteLine("The ticket costs {0} euros", (discountedSum - (discountedSum * 0.6)));
            }
            else {
                if (bMth)
                {
                    Console.WriteLine("The ticket costs {0} euros", (discountedSum - (discountedSum * 0.15)));
                }
                else if (bDraftee)
                {
                    Console.WriteLine("The ticket costs {0} euros", (discountedSum - (discountedSum * 0.5)));
                }
                else if (bStudent)
                {
                    Console.WriteLine("The ticket costs {0} euros", (discountedSum - (discountedSum * 0.45)));
                }
                else {
                    Console.WriteLine("The ticket costs {0} euros", discountedSum);
                }
            }
        }
    }
}
