using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Loan: Account/*abstract class*/
    {
        public Loan()
        {
            transactions = "\n" + ToString() + " started with Balance: " + Balance.ToString() + "\n";
        }
        //return true if transaction successfull
        //return false otherwise
        public override bool withdraw(double amount)
        {
            try
            {
                //check for withdraw, if there hasnt been any withdraw on the account yet, then Balance value is 0.0
                if (this.Balance == 0.0)
                {
                    this.Balance -= amount;
                    //store the transaction
                    transactions += "\nThe " + ToString() + " took-out " + amount.ToString() + ", Balance: " + Balance.ToString() + "\n";
                    return true;

                }
                throw new Exception("Transaction not allowed. Account already has given out a loan");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //Function to pay for the set amount
        public new bool deposit(double amount)
        {
            try
            {
                //we have to check if a loan is taken out and also amount inserted is > 0 and <= to current Balance 
                if (this.Balance < 0.0 && (amount > 0 && amount <= this.Balance))
                {
                    this.Balance += amount;
                    transactions += "\nThe " + ToString() + " paid " + amount.ToString() + ", Balance: " + Balance.ToString() + "\n";
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

        public override string ToString()
        {
            try
            {
                return "Loan Account";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }
    }
}
