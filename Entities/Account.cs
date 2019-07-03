using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //Abstract class for account
    public abstract class Account: IAccount
    {
        //AccountId
        public String AccountID;
        //Current balance of account
        public double Balance;

        public String transactions;

        //Constructor
        /*public Account(int value)
        {
            //value is assigned to account id
            this.AccountID = value;
        }*/

        //return true if transaction successfull
        //return false otherwise
       public abstract bool withdraw(double amount);

        //return true if transaction successfull
        //return false otherwise
        public bool deposit(double amount)
        {
            try
            {
                if (amount > 0.0)
                {
                    this.Balance += amount;
                    //store the transaction
                    transactions += "\nThe " + ToString() + " deposited " + amount.ToString() + ", Balance: " + Balance.ToString() + "\n";
                    return true;
                }
                throw new Exception("amount value is invalid");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

    }
}
