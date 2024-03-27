/// <summary>
/// class for operations located in tree nodes
/// </summary>
public class Operations
{
    /// <summary>
    /// contains the operation of multiplication, division, addition, subtraction
    /// </summary>
    public char operation;

    /// <summary>
    /// performs an operation in accordance with the operation that lies in the tree node
    /// </summary>
    /// <param name="operand1">first number for operation</param>
    /// <param name="operand2">second number for operation</param>
    /// <returns>returns the result of an operation on operand1 and operand2</returns>
    /// <exception cref="DivideByZeroException">exception thrown when attempting to divide by zero</exception>
    /// <exception cref="IncorrectSymbolInString">exception thrown when a character is encountered that should not be in the expression</exception>
    public int Calculate(int operand1, int operand2)
    {
        switch(operation)
        {
            case '*':
                return operand1 * operand2;

            case '/':
                if (operand2 == 0)
                {
                    throw new DivideByZeroException("divisor is zero, you can't divide by zero");
                }
                return operand1 / operand2;

            case '+':
                return operand1 + operand2;

            case '-':
                return operand1 - operand2;

            default:
                throw new IncorrectSymbolInString("this element cannot be in a valid string, there can only be operations, integers, brackets, spaces");
        }
    }

    /// <summary>
    /// print an operation located at a tree node
    /// </summary>
    public void Print()
    {
        Console.Write($"{operation} ");
    }
}
