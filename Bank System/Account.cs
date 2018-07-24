using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    enum AccountType                    //Using enum
    {
        Savings = 0,
        Current,
        DMAT
    }
    class Account                          //Creating a class
    {
        private static int totalAccounts = 0;                 //Declared a static variable to count the total number of accounts created. The ID is automatically assigned the current number of Total Accounts.
        private AccountType accountType;
        private string fName;
        private string lname;
        private int id;
        private double balance;

        public int ID { get => id; set => id = value; }                 //Created the getter and setter functions for ID

        public Account()                    //The default constructor for the class.
        {
            fName = "";
            lname = "";
            ID = 0;
            balance = 0;
        }
        public Account(string fname, string lname, AccountType accountType, double balance)                 //Parameterised constructor for the class.
        {
            this.accountType = accountType;
            this.fName = fname;
            this.lname = lname;
            ID = ++totalAccounts;                   //totalAccounts is incremented everytime it is assigned to an ID 
            this.balance = balance;
        }
        public void DisplayDetails()
        {
            Console.WriteLine("-----\nName : {0} {1}\nAccount Type : {2}\nAccount ID : {3}\nBalance : {4}\n-----", fName, lname, accountType, ID, balance);
        }
        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Transaction Successful!");
        }

        public double CalculateInterest()
        {
            if (accountType == AccountType.Savings)
            {
                return 4 * balance / 100;
            }
            if (accountType == AccountType.Current)
            {
                return 1 * balance / 100;
            }
            return 0;
        }

        public void Withdraw(double amount)
        {
            if (accountType == AccountType.Savings)
            {
                if (balance - amount < 1000)
                {
                    Console.WriteLine("Error! Minimum Balance should be greater than 1000");
                    return;
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine("Transaction Successful!");
                }
                return;
            }
            else if (accountType == AccountType.Current)
            {
                if (balance - amount < 0)
                {
                    Console.WriteLine("Error! Minimum Balance should be greater than 0");
                    return;
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine("Transaction Successful!");
                }
                return;
            }
            else if (accountType == AccountType.DMAT)
            {
                if (balance - amount < -10000)
                {
                    Console.WriteLine("Error! Minimum Balance should be greater than -10000");
                    return;
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine("Transaction Successful!");
                }
                return;
            }
        }
    }
}
