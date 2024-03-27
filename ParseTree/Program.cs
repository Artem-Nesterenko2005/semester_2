class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the path to the file");
        var path = Console.ReadLine();
        var expression = File.ReadAllText(path!);
        var tree = new ParseTree();
        string[] array = expression.Split(' ');
        tree.MakeTree(array);
        tree.PrintTree(tree);
        Console.WriteLine("\nResult: " + tree.CalculateResult(tree));
    }
}
