/// <summary>
/// class for integers located in tree nodes
/// </summary>
public class Operand
{
    /// <summary>
    /// contains an integer
    /// </summary>
    public int operand;

    /// <summary>
    /// counts a tree node element
    /// </summary>
    /// <returns>returns the value of an integer located in a tree node</returns>
    public int Calculate()
    {
        return operand;
    }

    /// <summary>
    /// print an integer located at a tree node
    /// </summary>
    public void Print()
    {
        Console.Write($"{operand} ");
    }
}
