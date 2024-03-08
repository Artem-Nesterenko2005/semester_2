/// <summary>
/// first-in-last-out data structure based on a list.
/// </summary>
public class ListStack : IStack
{
    /// <summary>
    /// list for stack.
    /// </summary>
    private List<double> list;

    /// <summary>
    /// index of the element at the top of the stack.
    /// </summary>
    private int top;

    /// <summary>
    /// create stack on an list with a given expression length in postfix form.
    /// </summary>
    /// <param name="length">length of the expression in postfix form.</param>
    public ListStack(int length)
    {
        top = -1;
        list = new List<double>(length);
    }

    /// <summary>
    /// adds an element to the top of the stack.
    /// </summary>
    /// <param name="element">element to add to the stack.</param>
    public void Push(double element)
    {
        ++top;
        list.Add(element);
    }

    /// <summary>
    /// removes an element from the top of the stack and puts the previous element on top.
    /// </summary>
    /// <returns>element from the top of the stack.</returns>
    public double Pop()
    {
        double element = list[top];
        --top;
        list.RemoveAt(list.Count - 1);
        return element;
    }

    /// <summary>
    /// checks the stack for emptyness.
    /// </summary>
    /// <returns>returns true if the stack is empty.</returns>
    public bool IsEmpty()
    {
        return list.Count == 0;
    }
}
