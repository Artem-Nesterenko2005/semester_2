/// <summary>
/// first-in-last-out data structure based on a array.
/// </summary>
public class ArrayStack : IStack
{
    /// <summary>
    /// index of the element at the top of the stack.
    /// </summary>
    private int top;

    /// <summary>
    /// array for stack.
    /// </summary>
    private double[] array;

    /// <summary>
    /// create stack on an array with a given expression length in postfix form.
    /// </summary>
    /// <param name="length">length of the expression in postfix form.</param>
    public ArrayStack(int length)
    {
        top = -1;
        array = new double[length];
    }

    /// <summary>
    /// adds an element to the top of the stack.
    /// </summary>
    /// <param name="element">element to add to the stack.</param>
    public void Push(double element)
    {
        ++top;
        array[top] = element;
    }

    /// <summary>
    /// removes an element from the top of the stack and puts the previous element on top.
    /// </summary>
    /// <returns>element from the top of the stack.</returns>
    public double Pop()
    {
        double result = array[top];
        array[top] = 0;
        --top;
        return result;
    }

    /// <summary>
    /// checks the stack for emptyness.
    /// </summary>
    /// <returns>returns true if the stack is empty.</returns>
    public bool IsEmpty()
    {
        return top == -1;
    }
}
