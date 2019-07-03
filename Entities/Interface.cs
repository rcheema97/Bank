using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IBank
    {
        //returns the account info
        String createAccount(Customer c, String accountNumber);

    }

    public interface IRemoveAccount
    {
        //return true if the account was successfully removed
        //return false otherwise
        bool removeAccount();
    }
   public interface IAccount
    {
        //return true if transaction successfull
        //return false otherwise
        bool withdraw(double a);

        //return true if transaction successfull
        //return false otherwise
        bool deposit(double a);

    }






}



