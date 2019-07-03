using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AccountFactory
    {
        //returns new type of account with the provided type
        public static Account generateAccount(ConsoleKey type)
        {
            //D0
            if (type == (ConsoleKey)TypeOfAccount.CheckingAccount)
            {
                //attach the generated account number to appropriate account
                return new CheckingAccount();
            }
            //D1
            if (type == (ConsoleKey)TypeOfAccount.BussinessAccount)
            {
                //attach the generated account number to appropriate account
                return new BusinessAccount();
            }
            //D2
            if (type == (ConsoleKey)TypeOfAccount.LoanAccount)
            {
                //attach the generated account number to appropriate account
                return new Loan();
            }
            //D3
            if (type == (ConsoleKey)TypeOfAccount.TermDeposit)
            {
                //attach the generated account number to appropriate account
                return new TermDeposit();
            }
            else
            {
                throw new Exception("Invalid Account type. This account type does not exist in our Bank");
            }
        }
    }
}
