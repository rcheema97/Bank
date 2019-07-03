using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appBL;
using Entities;


namespace project0
{
    class Program
    {
        //public static Enum e = new();
        public static void bankfeature1()
        {
            Console.WriteLine();
            Console.WriteLine("**********************************************Welcome to the bank**************************************");


            Console.WriteLine("Welcome to the bank");
            Console.WriteLine();
            Console.WriteLine("CHOICES: ");
            Console.WriteLine("\tNEW CUSTOMER register and open an account, type '0'");
            Console.WriteLine("\tExisting customer, type '1'");
            Console.WriteLine("*******************************************************************************************************");
            Console.Write("Please select your choice: ");
        }
        public static void bankfeature2()
        {
            Console.WriteLine();
            Console.WriteLine("*******************************************************************************************************");
            Console.WriteLine();
            Console.WriteLine("CHOICES: ");
            Console.WriteLine("Existing customer OPEN a new account, type '1'");
            Console.WriteLine("Existing customer INQUIRE BALANCE and account info on account(s), type '2'");
            Console.WriteLine("Existing customer DEPOSIT money into checking/business/term account or pay-loan-on an account, type '3'");
            Console.WriteLine("Existing customer WITHDRAW from checking/busniness/term account or take-out-loan an account, type '4'");
            Console.WriteLine("Existing customer TRANSFER money to-and-from an account, type '5'");
            Console.WriteLine("Existing customer see TRANSACTIONS on an account, type '6'");
            Console.WriteLine("Existing customer DELETE an account, type '7'");
            Console.WriteLine("Press 'Q' to quit");
            Console.WriteLine("*******************************************************************************************************");
            Console.Write("Please select your choice: ");
        }

        public static void askForType()
        {
            Console.WriteLine("Please Type " + 0 + " to create a checking account");
            Console.WriteLine("Please Type " + 1 + " to create a business account");
            Console.WriteLine("Please Type " + 2 + " to create a loan account");
            Console.WriteLine("Please Type " + 3 + " to create a Term-Deposit account");
        }
        static void Main(string[] args)
        {
            bool stop = false;
            String id;
            String FirstName;
            String LastName;
            String email;
            String password;
            double amount;

            while (true)
            {
                try
                {
                    Program.bankfeature1();
                    var userInput = Console.ReadKey();
                    Console.WriteLine();

                    switch (userInput.Key) //Switch on Key enum
                    {
                        //new customer
                        case ConsoleKey.D0:
                            Console.Write("Please type your First Name: ");
                            FirstName = Console.ReadLine();
                            Console.Write("Please type your Last Name: ");
                            LastName = Console.ReadLine();
                            Console.Write("Please type your email: ");
                            email = Console.ReadLine();
                            Console.Write("Please type your password: ");
                            password = Console.ReadLine();
                            Console.WriteLine();
                            askForType();
                            var myinput = Console.ReadKey();
                            Console.WriteLine();
                            if (myinput.Key == (ConsoleKey)(TypeOfAccount.CheckingAccount) || myinput.Key == (ConsoleKey)(TypeOfAccount.BussinessAccount) ||
                                myinput.Key == (ConsoleKey)(TypeOfAccount.LoanAccount) || myinput.Key == (ConsoleKey)(TypeOfAccount.TermDeposit))
                            {

                                Console.WriteLine(appBL.appBL.createNewAccountForNewCustomer(FirstName, LastName, email, password, myinput.Key));

                            }
                            else
                            {
                                throw new Exception("Option chosen not avaiable");
                            }
                            break;
                        //existing customer
                        case ConsoleKey.D1:
                            Console.Write("Please type your email: ");
                            email = Console.ReadLine();
                            Console.Write("Please type your password: ");
                            password = Console.ReadLine();

                            while (stop == false && appBL.appBL.checkemailpassword(email, password))
                            {
                                Program.bankfeature2();
                                var _userInput = Console.ReadKey();
                                Console.WriteLine();
                                switch (_userInput.Key)
                                {
                                    //create account for existing customer
                                    case ConsoleKey.D1:
                                        askForType();
                                        var input = Console.ReadKey();
                                        Console.WriteLine();
                                        if (input.Key == (ConsoleKey)(TypeOfAccount.CheckingAccount) || input.Key == (ConsoleKey)(TypeOfAccount.BussinessAccount) ||
                                            input.Key == (ConsoleKey)(TypeOfAccount.LoanAccount) || input.Key == (ConsoleKey)(TypeOfAccount.TermDeposit))
                                        {

                                            Console.WriteLine(appBL.appBL.createAccountForExistingCustomer(email, input.Key));
                                        }

                                        else
                                        {
                                            throw new Exception("Option chosen not avaiable");
                                        }
                                        break;

                                    //inquire balance
                                    case ConsoleKey.D2:
                                        Console.WriteLine(appBL.appBL.returnAccountBalance(email));
                                        break;
                                    //deposit money
                                    case ConsoleKey.D3:
                                        Console.WriteLine("Please enter the account number: ");
                                        //id->AccountNumber
                                        id = Console.ReadLine();
                                        Console.WriteLine("Please enter the amount you want to deposit into the account: ");
                                        amount = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(appBL.appBL.DepositMoneyIntoAccount(id, amount));
                                        break;

                                    //withdraw money
                                    case ConsoleKey.D4:
                                        Console.WriteLine("Please enter the account number: ");
                                        //id->AccountNumber
                                        id = Console.ReadLine();
                                        Console.WriteLine("Please enter the amount you want to withdraw into the account: ");
                                        amount = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(appBL.appBL.WithdrawMoneyIntoAccount(id, amount));//app.BL.appBL.WithdrawMoneyIntoAccount(id,amount);
                                        break;
                                    //transfer money FROM and TO accounts
                                    case ConsoleKey.D5:
                                        Console.Write("Please type the account number FROM which you would like to send money: ");
                                        var FROM = Console.ReadLine();
                                        Console.WriteLine();
                                        Console.Write("Please type the account number TO which you would like to send money: ");
                                        var TO = Console.ReadLine();
                                        Console.Write("Please type the amount for the transaction: ");
                                        var _amount = Convert.ToDouble(Console.ReadLine());
                                        Console.WriteLine(appBL.appBL.TransferMoneyFromTo(FROM, TO, _amount));
                                        break;

                                    //list all transactions for an account
                                    case ConsoleKey.D6:
                                        Console.Write("Please type your account number for which you would like to see the transactions: ");
                                        var a = Console.ReadLine();
                                        Console.WriteLine(appBL.appBL.viewTransactions(a));//appBL.appBL.viewTransactions(a);
                                        break;

                                    //delete an account
                                    case ConsoleKey.D7:
                                        Console.Write("Please type the account number of the account which you would like to close: ");
                                        var j = Console.ReadLine();
                                        Console.WriteLine(appBL.appBL.deleteAccount(j));
                                        break;

                                    //quit
                                    case ConsoleKey.Q:
                                        stop = true;
                                        break;

                                    default:
                                        Console.WriteLine("Seems like some sort of ERROR has happened");
                                        Console.WriteLine("We request you to please choose the right option to proceed");
                                        break;

                                }
                            }

                            break;
                        default:
                            Console.WriteLine("Seems like some sort of ERROR has happened");
                            Console.WriteLine("We request you to please choose the right option to proceed");
                            break;


                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("An exception was made and caught");
                    Console.WriteLine(ex.Message);
                }
                }
        }
    }
}
