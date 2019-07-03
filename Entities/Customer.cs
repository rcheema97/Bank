using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        //List of accounts beloning to a single customer
        //key parameter is account number
        //value is account
        public Dictionary<String, Account> myAccounts;

        public Customer()
        {
            myAccounts = new Dictionary<String, Account>();
        }
        //different property of a customer
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String email { get; set; }

        public String password { get; set; }
        
        public string ToString(String id)
        {
            try
            {
                return FirstName.ToString() + " " + LastName.ToString() + " with email address: " +
                    email.ToString() + " has created a " + myAccounts[id].ToString() + "\nYour Account Numer: " + id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public string viewBalance(Customer c)
        {
            try
            {
                String s = "";
                foreach (KeyValuePair<String, Account> arr in c.myAccounts)
                {
                    s += "Account#: " + arr.Key.ToString() + ", Balance: " + arr.Value.Balance.ToString() + ", Account-Type: " + arr.Value.ToString() + "\n";
                }
                return s;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public string deleteAccount(String accountNumber)
        {
            try
            {
                //only delete account when balance is zero
                //otherwise clear the balance before 
                if (myAccounts[accountNumber].Balance == 0.0)
                {
                    string s = "The account with account#: " + accountNumber;
                    myAccounts.Remove(accountNumber);
                    s += " was deleted";
                    return s;
                }
                throw new Exception("The balance for account to be deleted is not ZERO. Get the balance to ZERO before deleting it");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    }
}
