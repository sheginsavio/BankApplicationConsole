namespace BankApplicationConsoleBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int index = 0;
            string[,] arr = new string[10, 2];

            Console.WriteLine("Bank Application");
            while (true)
            {
                Console.WriteLine("\n_____Menu_____");
                Console.WriteLine("1.Create Account\n2.Show Account Information\n" +
                    "3.Deposit from account\n4.Withdraw from account\n" +
                    "5.Show all account\n6.Clear screen\n7.Exit");
                Console.WriteLine("Enter your choice:");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (!char.IsDigit(input))
                {
                    Console.WriteLine("Invalid input!!!!!!!!");
                    continue;
                }

                int choice = (int)Char.GetNumericValue(input);

                switch (choice) {
                    case 1:
                        if (index >= 10) {
                            Console.WriteLine("Bank is full!!!");
                            break;
                        }
                        do {
                            Console.WriteLine("Enter the Account Holder name:");
                            arr[index, 0] = Console.ReadLine();
                        } while (arr[index,0] == "");

                        string intialAmountStr;
                        int initialAmout;
                        do {
                            Console.WriteLine("Enter the intial amount");
                            intialAmountStr = Console.ReadLine();
                        }while (!int.TryParse(intialAmountStr, out int initialAmount));

                        arr[index, 1] = intialAmountStr.ToString();

                        Console.WriteLine($"Account added successfully!!\nYour id is {index}");
                        index++;
                        break;
                    case 2:
                        string name;
                        do
                        {
                            Console.WriteLine("Enter the Account Holder name:");
                            name = Console.ReadLine();
                        } while (string.IsNullOrWhiteSpace(name));

                        bool found = false;

                        for (int i = 0; i < index; i++)
                        {
                            if (string.Equals(name,arr[i, 0], StringComparison.OrdinalIgnoreCase))
                            {
                                found = true;
                                Console.WriteLine($"Account id: {i}");
                                Console.WriteLine($"Account Holder name: {arr[i,0]}");
                                Console.WriteLine($"Balance: {arr[i,1]}");
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Account not found");
                        }

                        break;
                    case 3:

                        Console.WriteLine("Enter the Account Id number to deposit:");
                        if(int.TryParse(Console.ReadLine(), out int depositId) && depositId>=0 && depositId < index)
                        {
                            Console.WriteLine("Enter the amount to deposit:");
                            if(int.TryParse(Console.ReadLine(), out int depositeAmount) && depositeAmount > 0)
                            {
                                int currentBalance = int.Parse(arr[depositId, 1]);
                                currentBalance += depositeAmount;
                                arr[depositId, 1] = currentBalance.ToString();

                                Console.WriteLine("Deposited Successfully!!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Account id\n");
                        }

                        break;
                    case 4:

                        Console.WriteLine("Enter the Account Id to withdraw from:");
                        if(int.TryParse(Console.ReadLine(), out int withdrawId) && withdrawId>=0 && withdrawId < index)
                        {
                            Console.WriteLine("Enter the amount to withdraw:");
                            if(int.TryParse(Console.ReadLine(), out int withdrawAmount) && withdrawAmount > 0)
                            {
                                int currentAmount = int.Parse(arr[withdrawId, 1]);
                                currentAmount -= withdrawAmount;
                                arr[withdrawId, 1] = currentAmount.ToString();

                                Console.WriteLine("Withdraw is successful!!!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Account id!");
                        }

                        break;
                    case 5:
                        if(index == 0)
                        {
                            Console.WriteLine("No Account exit yet");
                            break;
                        }
                        Console.WriteLine("___ Account Informations ___");
                        for (int i = 0; i < index; i++)
                        {
                            Console.WriteLine($"Account id: {i}");
                            Console.WriteLine($"Account Holder name: {arr[i, 0]}");
                            Console.WriteLine($"Balance: {arr[i, 1]}\n");
                        }
                        break;
                    case 6:
                        Console.Clear();
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
