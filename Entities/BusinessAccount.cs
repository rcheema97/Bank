using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class BusinessAccount:Account
    {
        public BusinessAccount()
        {
            transactions = "\n" + ToString() + " started with Balance: " + Balance.ToString() + "\n";
        }
        //return true if transaction successfull
        //return false otherwise
        public override bool withdraw(double amount)
        {
            try
            {
                double temp1;
                temp1 = this.Balance - amount;
                this.Balance = temp1;
                //store the transaction
                transactions += "\nThe " + ToString() + " withdrew " + amount.ToString() + ", Balance: " + Balance.ToString() + "\n";
                return true;
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
                return "Business Account";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    }
}
