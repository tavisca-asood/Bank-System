using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    class Program
    {

        static void AddAccount(ref List<Account> accounts)
        {
            Console.WriteLine("Enter first name.");
            string fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter last name.");
            string lname = Console.ReadLine().Trim();
            Console.WriteLine("Enter account type");
            int type;
            AccountType accountType;
            Console.WriteLine("Enter '1' for Savings account.\nEnter '2' for Current account.\nEnter '3' for DMAT account.\nDefault is Savings.");
            int.TryParse(Console.ReadLine(), out type);                                 //Used out
            switch (type)
            {
                case 1:
                    accountType = AccountType.Savings;
                    break;
                case 2:
                    accountType = AccountType.Current;
                    break;
                case 3:
                    accountType = AccountType.DMAT;
                    break;
                default:
                    accountType = AccountType.Savings;
                    break;
            }
            Console.WriteLine("Enter the starting balance.");
            double balance;
            double.TryParse(Console.ReadLine(), out balance);                           //Used out
            while (accountType == AccountType.Savings && balance < 1000)
            {
                Console.WriteLine("The minimum balance for a Savings account is 1000.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            while (accountType == AccountType.Current && balance < 0)
            {
                Console.WriteLine("The minimum balance for a Current account is 0.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            while (accountType == AccountType.DMAT && balance < -10000)
            {
                Console.WriteLine("The minimum balance for a DMAT account is -10000.");
                double.TryParse(Console.ReadLine(), out balance);
            }
            accounts.Add(new Account(fname, lname, accountType, balance));
        }


        static Account ChooseAccount(int id, List<Account> accounts)                            //Implemented search by ID in this method
        {
            foreach (Account account in accounts)
            {
                if (account.ID == id)
                    return account;
            }
            return null;
        }

        static void PerformOperations(ref List<Account> accounts)
        {
            Console.WriteLine("Enter account ID to choose account to perform operations");
            int id;
            int.TryParse(Console.ReadLine(), out id);                   //Used out
            Account chosenAccount = ChooseAccount(id, accounts);
            if (chosenAccount != null)
            {
                int operation;
                Console.WriteLine("Enter 1 to deposit.\nEnter 2 to withdraw.\nEnter 3 to display interest.");
                int.TryParse(Console.ReadLine(), out operation);                    //Used out
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Enter the amount to be deposited");
                        chosenAccount.Deposit(double.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Enter the amount to be withdrawn");
                        chosenAccount.Withdraw(double.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine(chosenAccount.CalculateInterest());
                        break;
                    default:
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of people");
            int n = int.Parse(Console.ReadLine());
            List<Account> accounts = new List<Account>();                 //Used List instead of Array
            for (int i = 0; i < n; i++)
            {
                AddAccount(ref accounts);                   //Used ref
            }
            int choice;
            int flag;
            while (true)
            {
                Console.WriteLine("Enter 1 to to display accounts.\nEnter 2 to add an account.\nEnter 0 to exit.");
                int.TryParse(Console.ReadLine(), out choice);                   //Used out
                flag = 0;
                switch (choice)
                {
                    case 1:
                        foreach (Account account in accounts)
                            account.DisplayDetails();
                        PerformOperations(ref accounts);
                        break;
                    case 2:
                        AddAccount(ref accounts);                   //Used ref
                        break;
                    case 0:
                        flag = 1;
                        break;
                }
                if (flag == 1)
                    break;
            }
        }
    }
}
