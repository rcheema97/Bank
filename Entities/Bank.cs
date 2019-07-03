
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Bank : IBank
    {
        //Table of customers with pk as email
        //made it static because all customers should be accessible by every branch(instance) of bank
        private static Dictionary<String, Customer> customers= new Dictionary<String, Customer>();

        //Table of email with pk as AccountNumber
        private static Dictionary<String, String> allAccountsID = new Dictionary<string, string>();

        //List of random Account numbers generated
        //private static List<String> allAccountsID= new List<string>();

        //returns the account info
        public String createAccount(Customer c, String accountNumber)
        {
            try
            {
                //new customer: so add them to database
                if (!doesEmailExistInBank(c.email))
                {
                    customers.Add(c.email, c);
                    //allBankID.Add(c.email);
                }
                //everytime this function is called an account is created
                allAccountsID.Add(accountNumber, c.email);
                return c.ToString(accountNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public static bool doesIdExistInBank(String id)
        {
            try
            {
                if (allAccountsID.Keys.Contains(id))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public static bool doesEmailExistInBank(String id)
        {
            try
            {
                if (customers.Keys.Contains(id))
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }



        //returns reference to customer using email
        public static Customer returnCustomerReferenceWithEmail(String email)
        {
            try
            {
                return customers[email];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public static Customer returnCustomerReferenceWithAccountNumber(String accountNumber)
        {
            try
            {
                Customer c = customers[allAccountsID[accountNumber]];
                return c;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

    }
}
