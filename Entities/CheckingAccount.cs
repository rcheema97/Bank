using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CheckingAccount:Account
    {
        //return true if transaction successfull
        //return false otherwise

        public CheckingAccount()
        {
            transactions = "\n"+ ToString() +" started with Balance: " + Balance.ToString()+"\n";
        }
        public override bool withdraw(double amount)
        {
            try
            {
                double temp1;
                temp1 = this.Balance - amount;
                if (temp1 >= 0)
                {
                    this.Balance = temp1;
                    //store the transaction
                    transactions += "\nThe " + ToString() + " withdrew " + amount.ToString() + ", Balance: " + Balance.ToString() + "\n";
                    return true;
                }
                throw new Exception("transaction not allowed. Balance is lows");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        public override string ToString()
        {
            try
            {
                return "CheckingAccount";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    }
}
