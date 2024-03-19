public class Program
{
    static void Main()
    {
        var LZWStructure = new LZW();

        Console.WriteLine("Enter the path to the file");
        string path = Console.ReadLine()!;
        if (!File.Exists(path)) 
        {
            Console.WriteLine("No such file exists");
            return;
        }

        Console.WriteLine("Enter key");
        string key = Console.ReadLine()!;
        if (key != "-c" && key != "-u")
        {
            Console.WriteLine("No such key exists");
            return;
        }

        string data = File.ReadAllText(path);
        if (key == "-c")
        {
            List<int> compressedString = LZWStructure.Compress(data);
            float compressionRatio = (float)(data.Length - compressedString.Count) / data.Length;
            Console.WriteLine("Compression ratio - " + MathF.Round(compressionRatio,2));
            System.IO.File.WriteAllLines(path + ".zipped", compressedString.Select(data => data.ToString()));
            return;
        }

        string[] compressedData = File.ReadAllLines(path);
        string decompressionString = LZWStructure.Decompress(compressedData);
        Console.WriteLine("Decompression completed");
        System.IO.File.WriteAllText(path.Substring(0, path.Length - 7), decompressionString);
    }
}
