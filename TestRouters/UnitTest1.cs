public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestCommonFile()
    {
        string data = File.ReadAllText("..//..//..//commonFile.txt");
        var graph = new Graph();
        graph.CreateGraph(data);
        Assert.IsTrue(graph.OptimalPaths() == File.ReadAllText("..//..//..//commonFileOptimal.txt"));
    }

    [Test]
    public void TestEmptyFile()
    {
        string data = File.ReadAllText("..//..//..//emptyFile.txt");
        var graph = new Graph();
        Assert.Throws<EmptyFileException>(() => graph.CreateGraph(data));  
    }

    [Test]
    public void TestDisconnectGraphFile()
    {
        string data = File.ReadAllText("..//..//..//disconnectGraph.txt");
        var graph = new Graph();
        graph.CreateGraph(data);
        Assert.Throws<DisconnectedGraphException>(() => graph.OptimalPaths());
    }
}
