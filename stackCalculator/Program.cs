class Program
{
    static void Main()
    {
        if (!TestProgram.Test())
        {
            Console.WriteLine("Error test");
            return;
        }
        Console.WriteLine("Enter the expression:");
        var expression = Console.ReadLine();
        if (expression == null)
        {
            Console.WriteLine("Error: empty string");
            return;
        }
        var errorCode = (ErrorCodes)0;

        var createArrayStack= new StackCalculator(new ArrayStack(expression.Split(' ').Length));
        double resultArray = StackCalculator.CalculateExpression(expression, ref errorCode);
        if (errorCode != ErrorCodes.OK_CODE)
        {
            if (errorCode == ErrorCodes.INCORRECT_SYMBOL)
            {
                Console.WriteLine("Error: incorrect symbol");
                return;
            }

            if (errorCode == ErrorCodes.ERROR_STACK)
            {
                Console.WriteLine("Error stack");
                return;
            }

            Console.WriteLine("Error: divisor zero");
            return;
        }
        Console.WriteLine($"Result of stack operation on array: {resultArray}");

        var createListStack = new StackCalculator(new ListStack(expression.Split(' ').Length));
        double resultList = StackCalculator.CalculateExpression(expression, ref errorCode);
        if (errorCode != ErrorCodes.OK_CODE)
        {
            if (errorCode == ErrorCodes.INCORRECT_SYMBOL)
            {
                Console.WriteLine("Error: incorrect symbol");
                return;
            }

            if (errorCode == ErrorCodes.ERROR_STACK)
            {
                Console.WriteLine("Error stack");
                return;
            }

            Console.WriteLine("Error: divisor zero");
            return;
        }
        Console.WriteLine($"Result of stack operation on list: {resultList}");
    }
}
