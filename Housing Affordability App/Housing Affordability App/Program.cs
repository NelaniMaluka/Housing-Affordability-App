using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formative_1__Housing_Affordability_App__Nelani_Maluka
{
    internal class Program
    {

        static void HousingAffordability() 
        {
            try // Handles errors if the user enters the wrong inputs 
            {
                // user details 
                Console.WriteLine("Welcome to the Housing Affordability App");

                Console.WriteLine("\n**********Personal Questions***********");
                Console.Write("Enter your gross monthly income: ");
                double grossIncome = int.Parse(Console.ReadLine());

                Console.Write("Enter your gross monthly tax(15%): ");
                double monthlyTax = int.Parse(Console.ReadLine());
                monthlyTax = (monthlyTax / 100) * grossIncome;

                Console.Write("Enter how much you spend on utilities: ");
                double utilities = int.Parse(Console.ReadLine());

                Console.Write("Enter how much you spend on groceries: ");
                double groceries = int.Parse(Console.ReadLine());

                Console.Write("Enter how much you spend on transportation: ");
                double transportation = int.Parse(Console.ReadLine());

                Console.Write("Enter how much you spend on other expenses: ");
                double other = int.Parse(Console.ReadLine());

                // buy a property or rental
                Console.Write("\nAre you (1.)renting or (2.)buying a property : ");
                double selectedOption = int.Parse(Console.ReadLine());

                double homeExpense;
                if (selectedOption == 1)
                {
                    Console.Write("\nHow much is your rental : ");
                    homeExpense = int.Parse(Console.ReadLine()); // gets the monthly rental amount
                    Console.Write(value: $"\nYour monthly rent payment is: R{homeExpense}");
                }
                else if (selectedOption == 2)
                {
                    homeExpense = (int) GetLoanRepayment(); // calculates monthly home loan repayment
                    Console.WriteLine(value: $"\nYour monthly home loan repayment is: R{homeExpense}");
                }
                else
                {
                    homeExpense = 0;
                }

                // Checks affordability
                double loanAffordability = (homeExpense / grossIncome) * 100; // Calculates the percentage of the homeExpense to the monthly income
                loanAffordability = Math.Round(loanAffordability, 2);
                double oneThird = grossIncome * 0.33; // calculates 1/3 of the monthly income
                String approval;

                if (homeExpense <= oneThird) // Cheacks if the loan or rental aggremment would be accepted
                {
                    approval = "Likey";
                }
                else
                {
                    approval = "Unlikey";
                }
                Console.WriteLine($"\nYour home loan/rental is {loanAffordability}% of your gross monthly income and is {approval} to be approved");

                // Calculates monthly available money
                double expenditures = homeExpense + monthlyTax + utilities + groceries + transportation + other;
                double availableMoney = grossIncome - expenditures;
                if (availableMoney >= 0) // Checks if the user has money available or that there expenses are higher than their income
                {
                    Console.WriteLine($"You are left with R{availableMoney} after all deductions ");
                }
                else
                {
                    Console.WriteLine($"You are down with R{availableMoney} after all deductions ");
                }

                double holdTerminal = int.Parse(Console.ReadLine()); //holds the app from closing the terminal window
            }
            catch (Exception) //Handles the Error message
            {
                ErrorMessage();
            }
        }

        static void ErrorMessage() //when called displays the error message and reruns the app again
        {
            Console.Write("\nERROR Wrong Input, Enter a number\n");
            HousingAffordability();
        }

        static double GetLoanRepayment()
        {
            // Loan Repayment
            Console.WriteLine("\n**********Mortgage Questions***********");
            Console.Write("Enter the purchase price of the house: ");
            double purchasePrice = int.Parse(Console.ReadLine());

            Console.Write("How much are you depositing: ");
            double totalDeposit = int.Parse(Console.ReadLine());

            Console.Write("How much is the yearly intrest rate on the home loan: ");
            double intrestRate = int.Parse(Console.ReadLine());
            double Interest = intrestRate / 100; // Converts the intrest rate to decimal point value wich will be used to later

            Console.Write("How many months will it take to repay: ");
            double duration = int.Parse(Console.ReadLine());


            double monthlyPayment = (purchasePrice - totalDeposit) * (Math.Pow((1 + Interest / 12), duration) * Interest) / (12 * (Math.Pow((1 + Interest / 12), duration) - 1));
 
            return (int) monthlyPayment;  
        }

        static void Main(string[] args)
        {
            HousingAffordability(); 
        }
    }
}
