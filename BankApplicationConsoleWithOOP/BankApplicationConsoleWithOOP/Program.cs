using System;
using System.Collections.Generic;

namespace BankApplicationConsoleWithOOP
{

    public abstract class BankAccount
    {
        public int AccountId { get; private set; }
        public string AccountHolderName { get; private set; }
        public int Balance { get; protected set; }

        public BankAccount(int id, string name, int intialBalance)
        {
            AccountId = id;
            AccountHolderName = name;
            Balance = intialBalance;
        }

        public void Deposit(int amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine("Deposited successfully!!");
            }
            else
            {
                Console.WriteLine("Invalid amount!");
            }
        }

        public abstract void Withdraw(int amount);
        public abstract void DisplayAccountInfo();

    }

    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int id, string name, int initailBalance) : base(id, name, initailBalance) { 

        }

        public override void Withdraw(int amount)
        {
            if (amount > 0 && Balance>=amount)
            {
                Balance -= amount;
                Console.WriteLine("Withdraw Successfully!!");
            }
            else
            {
                Console.WriteLine("Invalid amount or Insufficient balance!");
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Account id: {AccountId}");
            Console.WriteLine($"Account Holder name: {AccountHolderName}");
            Console.WriteLine($"Balance: {Balance}");
        }

    }

    public class BankManager
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private int nextAccountId = 0;

        public void CreateAccount()
        {
            string name;
            do
            {
                Console.WriteLine("Enter the Account Holder name:");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            int intialBalance;
            do
            {
                Console.WriteLine("Enter the initial Balance:");
            } while (!int.TryParse(Console.ReadLine(), out intialBalance));

            BankAccount newAccount = new SavingsAccount(nextAccountId, name, intialBalance);
            accounts.Add(newAccount);

            Console.WriteLine($"Account Added successfully!!\nYour Id is {nextAccountId}");
            nextAccountId++;

        }

        public void ShowAccountInformation()
        {
            string name;
            do
            {
                Console.WriteLine("Enter the account Holder name:");
                name = Console.ReadLine();

            } while (name=="");
            bool found = false;

            foreach (var account in accounts)
            {
                if (string.Equals(account.AccountHolderName, name, StringComparison.OrdinalIgnoreCase))
                {
                    account.DisplayAccountInfo();
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Account not found");
            }
        }

        public void DepositToAccount()
        {
            Console.WriteLine("Enter the Account Id number to deposit:");
            if (int.TryParse(Console.ReadLine(), out int depositId) && depositId >= 0 && depositId < accounts.Count)
            {
                Console.WriteLine("Enter the amount to deposit:");
                if (int.TryParse(Console.ReadLine(), out int depositAmount))
                {
                    accounts[depositId].Deposit(depositAmount);
                }
            }
            else
            {
                Console.WriteLine("Invalid Account id\n");
            }
        }

        public void WithdrawFromAccount()
        {
            Console.WriteLine("Enter the Account Id to withdraw from:");
            if (int.TryParse(Console.ReadLine(), out int withdrawId) && withdrawId >= 0 && withdrawId < accounts.Count)
            {
                Console.WriteLine("Enter the amount to withdraw:");
                if (int.TryParse(Console.ReadLine(), out int withdrawAmount))
                {
                    accounts[withdrawId].Withdraw(withdrawAmount);
                }
            }
            else
            {
                Console.WriteLine("Invalid Account id!");
            }
        }

        public void ShowAllAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("No Account exists yet");
                return;
            }

            Console.WriteLine("___ Account Informations ___");
            foreach (var account in accounts)
            {
                account.DisplayAccountInfo();
                Console.WriteLine();
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankManager bank = new BankManager();
            Console.WriteLine("**** Welcome to Bank Management System ***");

            while (true)
            {
                Console.WriteLine("\nWhat you want to do:");
                Console.WriteLine("1. Create account\n2. Show account information\n" +
                                  "3. Deposit from account\n4. Withdraw from account\n" +
                                  "5. Show all account with id\n6. Clear screen\n7. Exit");

                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (!char.IsDigit(input))
                {
                    Console.WriteLine("Invalid input!!!!!!!!");
                    continue;
                }

                int choice = (int)Char.GetNumericValue(input);

                switch (choice)
                {
                    case 1:
                        bank.CreateAccount();
                        break;
                    case 2:
                        bank.ShowAccountInformation();
                        break;
                    case 3:
                        bank.DepositToAccount();
                        break;
                    case 4:
                        bank.WithdrawFromAccount();
                        break;
                    case 5:
                        bank.ShowAllAccounts();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("**** Welcome to Bank Management System ***");
                        break;
                    case 7:
                        Console.WriteLine("Thank you!!!!!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!!\n");
                        break;
                }
            }
        }
    }
}
