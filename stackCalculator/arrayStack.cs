public class ArrayStack : IStack
{
    private int top;
    private double[] array;

    public ArrayStack(int length)
    {
        top = -1;
        array = new double[length];
    }

    public void Push(double element)
    {
        ++top;
        array[top] = element;
    }

    public double Pop()
    {
        double result = array[top];
        array[top] = 0;
        --top;
        return result;
    }

    public bool IsEmpty()
    {
        return top == -1;
    }
}
