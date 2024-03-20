public class Program
{
    static void Main()
    {
        UniqueList<int> uniqueList = new UniqueList<int>();
        uniqueList.AddUniqueList(1, 1);
        uniqueList.AddUniqueList(2, 2);
        uniqueList.AddUniqueList(5, 5);
        uniqueList.AddUniqueList(0, 0);
        uniqueList.Remove(2, 2);
        uniqueList.ChangeByIndexUniqueList(0, 7);
    }
}
