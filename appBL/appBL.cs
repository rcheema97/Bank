using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using appDAL;

namespace appBL
{
    public class appBL 
    {
        //generate random bank id for account
        private String generateAccountNumber()
        {
            try
            {
                var random = new Random();
                //number1 is for bankid
                int number1;
                do
                {
                    number1 = random.Next(100, 999);
                    //while loops checks and makes sure the generated account number is distinct
                } while (Bank.doesIdExistInBank(number1.ToString()));

                return number1.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //takes parameter Customer c which only has values email, lname, fname
        //use this function to assign 
        private static String assignAccountValuesAndSendTODALLayer(Customer c,ConsoleKey type)
        {
            try
            {
                //create temp instance of this class to use the function to create random bank account
                var temp_instance_of_this_class = new appBL();
                //temp variable is the account number 
                var temp_account_number = temp_instance_of_this_class.generateAccountNumber();

                //reference points to account created in memory
                // var temp_account = AccountFactory.generateAccount(type);
                var temp_account = AccountFactory.generateAccount(type);
                //assign the random generated account number to this account
                temp_account.AccountID = temp_account_number;
                //insert the temp account into the temp customer
                c.myAccounts.Add(temp_account_number, temp_account);


                return appDAL.appDAL.createAccount(c, temp_account_number);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }


        
        //createNewAccountForNewCustomer makes a call to createAccount in DAL layer 
        public static String createNewAccountForNewCustomer(String FirstName, String Lastname, String email, String password, ConsoleKey type)
        {
            try
            {
                if (Bank.doesEmailExistInBank(email))
                {
                    throw new Exception("Email already in use by a customer");
                }
                //new customer
                var c = new Customer();
                c.FirstName = FirstName; c.LastName = Lastname; c.email = email; c.password = password;

                return assignAccountValuesAndSendTODALLayer(c, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }


        //looks up customer in bank
        private static Customer returnCustomer(String email)
        {
            try
            {

                //temp ref of customer 
                Customer temp;
                //check whether the value exists in database
                if (Bank.doesEmailExistInBank(email))
                {
                    //assign the value of temp to returned reference
                    temp = Bank.returnCustomerReferenceWithEmail(email);
                    return temp;
                }
                throw new Exception("Email provided does not exist in our database");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //creates more accounts for existing customer
        public static String createAccountForExistingCustomer(String email, ConsoleKey type)
        {
            try
            {
                var c = returnCustomer(email);
                return assignAccountValuesAndSendTODALLayer(c, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //return balance
        public static String returnAccountBalance(String email)
        {
            try
            {
                //check if the account number exists in bank
                if (Bank.doesEmailExistInBank(email))
                {
                    Customer c = Bank.returnCustomerReferenceWithEmail(email);
                    return appDAL.appDAL.returnAccountBalance(c);

                }
                throw new Exception("Account Number not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

        }

        //deposit money into acccount
        public static String DepositMoneyIntoAccount(String id, double amount)
        {
            try
            {
                if (Bank.doesIdExistInBank(id))
                {
                    if (amount > 0.0)
                    {
                        //find the customer
                        Customer temp = Bank.returnCustomerReferenceWithAccountNumber(id);

                        appDAL.appDAL.DepositMoneyIntoAccount(temp, id, amount);
                        return "Account Number: " + id + " balance now is " + temp.myAccounts[id].Balance.ToString() + " for " + temp.FirstName + " " + temp.LastName;
                    }
                    else { throw new Exception("Invalid amount"); }
                }
                throw new Exception("account number does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

        }

        //withdraw money from bank
        public static String WithdrawMoneyIntoAccount(String id, double amount)
        {
            try
            {
                if (Bank.doesIdExistInBank(id))
                {
                    if (amount > 0.0)
                    {
                        //find the customer
                        Customer temp = Bank.returnCustomerReferenceWithAccountNumber(id);

                        appDAL.appDAL.WithdrawMoneyIntoAccount(temp, id, amount);
                        return "\nAccount Number: " + id + " balance now is " + temp.myAccounts[id].Balance.ToString() + " for " + temp.FirstName + " " + temp.LastName;
                    }
                    else { throw new Exception("Invalid amount"); }
                }
                throw new Exception("account number does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public static String TransferMoneyFromTo(String accountnumber1, String accountnumber2, double amount)
        {
            try
            {
                string s = "";
                if (Bank.doesIdExistInBank(accountnumber1) && Bank.doesIdExistInBank(accountnumber2) && amount > 0.0)
                {//From (withdraw)-> accountnumber1 ; To(deposit) ->accountnumber2
                    s += WithdrawMoneyIntoAccount(accountnumber1, amount);
                    s += DepositMoneyIntoAccount(accountnumber2, amount);
                    return s;
                }
                throw new Exception("the FROM account and/or TO account does not exist OR the amount typed was invalid");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public static String deleteAccount(String accountNumber)
        {
            try
            {
                if (Bank.doesIdExistInBank(accountNumber))
                {
                    Customer c = Bank.returnCustomerReferenceWithAccountNumber(accountNumber);
                    return appDAL.appDAL.deleteAccount(c, accountNumber);
                }

                throw new Exception("Account number does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }


        }

        public static String viewTransactions(String accountNumber)
        {
            try
            {
                return appDAL.appDAL.viewTransactions(accountNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public static bool checkemailpassword(String email, String password)
        {
            try
            {
                Customer c = Bank.returnCustomerReferenceWithEmail(email);
                if (c.password.Equals(password))
                {
                    return true;
                }
                throw new Exception("Either the email or passwor is wrong");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    }
}
