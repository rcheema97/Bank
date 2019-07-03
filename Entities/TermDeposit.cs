using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TermDeposit : Account
    {
        public TermDeposit()
        {
            transactions = "\n" + ToString() + " started with Balance: " + Balance.ToString() + "\n";
        }
        //CountDown class variable for time 
        private CountDown clock { get; set; }

        //set to true when a deposit is made
        //false value means you can make a deposit
        public bool checkForTermDeposit;
        //&& checkForTermDeposit==false

        public new bool deposit(double amount)
        {
            try
            {
                //once a deposit is made, start the countdown
                if (amount > 0.0 && checkForTermDeposit == false)
                {
                    this.Balance += amount;
                    checkForTermDeposit = true;
                    //time
                    clock = new CountDown();
                    //subscribe to event
                    clock.CountDownCompleted += onCountDownCompleted;
                    transactions += "\nThe " + ToString() + " deposited " + amount.ToString() + ", Balance: " + Balance.ToString() + "\n";
                    return true;
                }
                throw new Exception("Transaction not allowed. Either the amount is invalid " +
                    "or the term deposit is preset some time ago");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        //return false and do nothing else
        public override bool withdraw( double amount)
        {
            try
            {
                throw new Exception("Action not allowed");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
            //return false;
        }
        //this function will push the money out 
        public bool withdraw()
        {
            try
            {
                //this mean the account hasn't reached the end of agreed term time, so there will be penalty
                if (checkForTermDeposit == true)
                {
                    //if this happens I want to subscribe to the event, so money doesn't automatically get added
                    clock.CountDownCompleted -= onCountDownCompleted;
                    //penalty
                    this.Balance -= (this.Balance * 0.1);
                    //manually set to false, so if you wanna start new term 
                    checkForTermDeposit = false;
                    //true for successfull operation
                    transactions += "\nThe " + ToString() + " withdrew: " + Balance.ToString() + "\n";
                    return true;
                }
                //successfully reached the end of agreed term time, so you can withdraw full money
                if (checkForTermDeposit == false && this.Balance > 0.0)
                {
                    transactions += "\nThe " + ToString() + " withdrew: " + Balance.ToString() + "\n";
                    this.Balance -= this.Balance;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }

        private void onCountDownCompleted(object source, EventArgs args)
        {
            try
            {
                this.checkForTermDeposit = false;
                this.Balance += (this.Balance * 0.1);
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
                return "Term Deposit Account";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { }
        }


    }
}
