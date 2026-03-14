namespace BankApplicationConsoleBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

                int index = 0;
                string[,] arr = new string[10,2];


                switch (choice){
                    case 1:
                        index++;

                        Console.WriteLine("Enter the Account Holder name:");
                        arr[index, 0] = Console.ReadLine();
                        Console.WriteLine("Enter the intial amount");
                        arr[index, 1] = Console.ReadLine();

                        Console.WriteLine("Account added successfully!!");
                        break;
                    case 2:
                        Console.WriteLine("Enter the Account Holder name:");
                        string name = Console.ReadLine();

                        for (int i = 0; i < index; i++)
                        {
                            if (string.Equals(name,arr[i, 0], StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"Account Holder name: {arr[i,0]}");
                                Console.WriteLine($"Balance: {arr[i,1]}");
                                break;
                            }
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        for (int i = 0; i < index; i++)
                        {
                            Console.WriteLine($"Account Holder name: {arr[i, 0]}");
                            Console.WriteLine($"Balance: {arr[i, 1]}");
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
                        Console.WriteLine("Invalid Choice!!!");
                        break;

                }
            }
        }
    }
}
