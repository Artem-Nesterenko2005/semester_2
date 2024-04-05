using System.IO.Enumeration;

class Program
{
    static public void Main()
    {
        Console.WriteLine("Enter the path to the file where the data is recorded");
        var pathOldData = Console.ReadLine();
        Console.WriteLine("Enter the path to the file where the data will be written");
        var pathNewData = Console.ReadLine();
        string data = File.ReadAllText(pathOldData!);
        var graph = new Graph();
        graph.CreateGraph(data);
        System.IO.File.WriteAllText(pathNewData!, graph.OptimalPaths());
    }
}
