using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace appDAL
{
    public class appDAL
    {
        //fake database
        private static IBank mybank = new Bank();

        //add a customer to bank
        public static String createAccount(Customer c, String accountNumber)
        {
            try
            {
                return mybank.createAccount(c, accountNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //open database and send the record
        public static String returnAccountBalance(Customer c)
        {
            try
            {
                //temp customer

                return c.viewBalance(c);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

        }

        //open database and put the money in it
        public static void  DepositMoneyIntoAccount(Customer c,String id, double amount)
        {
            try
            {
                c.myAccounts[id].deposit(amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

        }

        //open database and take out the money
        public static void WithdrawMoneyIntoAccount(Customer c, String id, double amount)
        {
            try
            {
                c.myAccounts[id].withdraw(amount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }

        }

        //delete an account
        public static String deleteAccount(Customer c, String accountNumber)
        {
            try
            {
                return c.deleteAccount(accountNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //transaction
        public static String viewTransactions(String accountNumber)
        {
            try
            {
                //find the customer -> afte customer find the account -> return transaction
                return Bank.returnCustomerReferenceWithAccountNumber(accountNumber).myAccounts[accountNumber].transactions;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }



    }
}
