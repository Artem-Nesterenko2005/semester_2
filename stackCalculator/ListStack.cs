public class ListStack : IStack
{
    private List<double> list;
    private int top;

    public ListStack(int length)
    {
        top = -1;
        list = new List<double>(length);
    }

    public void Push(double element)
    {
        ++top;
        list.Add(element);
    }

    public double Pop()
    {
        double element = list[top];
        --top;
        list.RemoveAt(list.Count - 1);
        return element;
    }

    public bool IsEmpty()
    {
        return list.Count == 0;
    }
}
