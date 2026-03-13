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
                    "5.Show all account with id\n6.Clear screen\n7.Exit");
                Console.WriteLine("Enter your choice:");
                char input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (!char.IsDigit(input))
                {
                    Console.WriteLine("Invalid input!!!!!!!!");
                    continue;
                }
                int choice = (int)Char.GetNumericValue(input);

                switch (choice){
                    case 1:

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
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
