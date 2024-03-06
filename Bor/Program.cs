public class Program
{
    static void Main()
    {
        var newBor = new Bor();
        int userCommand = 1;
        string expression = string.Empty;
        while (userCommand != 0)
        {
            Console.WriteLine("0 - exit");
            Console.WriteLine("1 - add string");
            Console.WriteLine("2 - check for string presence");
            Console.WriteLine("3 - remove string");
            Console.WriteLine("4 - check number of prefixes");
            Console.WriteLine("Enter the command: ");

            userCommand = int.Parse(Console.ReadLine()!);
            if (userCommand == 0)
            {
                break;
            }
            switch (userCommand)
            {
                case 1:
                    Console.WriteLine("Enter the string");
                    expression = Console.ReadLine()!;
                    if (newBor.Add(expression))
                    {
                        Console.WriteLine("New line added\n");
                        break;
                    }
                    Console.WriteLine("There was already such a string or string is empty\n");
                    break;

                case 2:
                    Console.WriteLine("Enter the string");
                    expression = Console.ReadLine()!;
                    if (newBor.Contains(expression))
                    {
                        Console.WriteLine("String contained\n");
                        break;
                    }
                    Console.WriteLine("String not contained\n");
                    break;

                case 3:
                    Console.WriteLine("Enter the string");
                    expression = Console.ReadLine()!;
                    if (newBor.Remove(expression))
                    {
                        Console.WriteLine("String removed\n");
                        break;
                    }
                    Console.WriteLine("There was no such string\n");
                    break;

                case 4:
                    Console.WriteLine("Enter the string");
                    expression = Console.ReadLine()!;
                    Console.WriteLine($"expression contains {newBor.HowManyStartsWithPrefix(expression)} prefixes\n");
                    break;

                default:
                    Console.WriteLine("There is no command with this number\n");
                    break;
            }
        }
    }
}
