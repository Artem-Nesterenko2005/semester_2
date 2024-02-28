public class StackCalculator
{
    static private IStack stack;

    public StackCalculator(IStack stackType)
    {
        stack = stackType;
    }

    static private double TransactionProcessing(char symbol, double number1, double number2, ref ErrorCodes errorCode)
    {
        switch (symbol)
        {
            case '+':
                return (number1 + number2);

            case '-':
                return (number2 - number1);

            case '*':
                return (number1 * number2);

            case '/':
                if (Math.Abs(number1) < 0.0000000001)
                {
                    errorCode = ErrorCodes.DIVISOR_ZERO;
                    return 0;
                }
                return (number2 / number1);

            default:
                return 0;
        }
    }

    static private bool IsOperation(char symbol)
    {
        return symbol == '*' || symbol == '/' || symbol == '-' || symbol == '+';
    }

    static private bool CheckString(string expression) 
    {
        foreach(var symbol in expression)
        {
            if (!char.IsDigit(symbol) && !IsOperation(symbol) && symbol != ' ')
            {
                return false;
            }
        }
        return true;
    }

    static public double CalculateExpression(string expression, ref ErrorCodes errorCode)
    {
        if (!CheckString(expression))
        {
            errorCode = ErrorCodes.INCORRECT_SYMBOL;
            return 0;
        }

        string[] elements = expression.Split(' ');
        double number = 0;
        foreach(var symbol in elements)
        {
            if (errorCode != ErrorCodes.OK_CODE)
            {
                return 0;
            }

            if (double.TryParse(symbol, out number))
            {
                stack.Push(number);
                continue;
            }

            if (stack.IsEmpty())
            {
                errorCode = ErrorCodes.ERROR_STACK;
                return 0;
            }
            stack.Push(TransactionProcessing(symbol[0], stack.Pop(), stack.Pop(), ref errorCode));
        }
        return stack.Pop();
    }
}
