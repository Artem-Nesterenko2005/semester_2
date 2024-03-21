/// <summary>
/// interface for stack on list and array.
/// </summary>
public interface IStack
{
    /// <summary>
    /// adds an element to the top of the stack.
    /// </summary>
    /// <param name="element">element to add to the stack.</param>
    public void Push(double element);

    /// <summary>
    /// removes an element from the top of the stack and puts the previous element on top.
    /// </summary>
    /// <returns>element from the top of the stack.</returns>
    public double Pop();

    /// <summary>
    /// checks the stack for emptyness.
    /// </summary>
    /// <returns>returns true if the stack is empty.</returns>
    public bool IsEmpty();
}
