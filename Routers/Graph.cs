/// <summary>
/// class for building, printing graph and finding the optimal path connecting all vertices of the graph
/// </summary>
public class Graph
{
    /// <summary>
    /// a dictionary with a list of neighboring vertices and their distances for a given vertex
    /// </summary>
    public Dictionary<int, int> neighbors = new Dictionary<int, int>();

    /// <summary>
    /// the vertex number of this node
    /// </summary>
    public int vertex;

    /// <summary>
    /// the next node for this vertex is
    /// </summary>
    public Graph next;

    /// <summary>
    /// number of vertices
    /// </summary>
    private int size;

    /// <summary>
    /// creates a graph for vertices and distances for them from a file
    /// </summary>
    /// <param name="fileData">all text from the file</param>
    public void CreateGraph(string fileData)
    {
        if (fileData == "")
        {
            throw new EmptyFileException("The initial data file is empty");
        }
        var currentNode = this;
        List<int> list = new List<int>();
        int variable = 0;
        string[] paths = fileData.Split('\n', '\r', ':', ',', '(', ')');
        this.vertex = int.Parse(paths[0]);
        for (int i = 1; i < paths.Length - 1; ++i)
        {

            if (paths[i] == "" && paths[i - 1] == "")
            {
                ++i;
                currentNode.next = new Graph();
                var previousNode = currentNode;
                currentNode = currentNode.next;
                currentNode.vertex = int.Parse(paths[i]);
                continue;
            }

            if (paths[i] == "")
            {
                continue;
            }

            if (int.TryParse(paths[i], out variable) && int.TryParse(paths[i + 1], out variable) && !list.Contains(int.Parse(paths[i])))
            {
                list.Add(int.Parse(paths[i]));
            }

            int[] array = new int[] { };
            if (!array.Contains(int.Parse(paths[i])) && int.TryParse(paths[i + 1], out variable))
            {
                array.Contains(int.Parse(paths[i]));
            }

            currentNode.neighbors.Add(int.Parse(paths[i]), int.Parse(paths[i+1]));
            ++i;
        }
        size = list.Count + 1;
    }

    private int[] CalculateOptimalPath(Graph auxiliaryGraph)
    {
        int[] array = new int[this.size];
        bool[] visitVertex = new bool[this.size];
        auxiliaryGraph.vertex = 1;
        Graph current = this;
        for (int j = 0; j <= this.size - 1; ++j)
        {

            if (auxiliaryGraph.vertex != 1)
            {
                current = new Graph();
                current.vertex = auxiliaryGraph.vertex;
                var allData = this;
                while (allData != null)
                {
                    if (allData.neighbors.ContainsKey(current.vertex))
                    {
                        current.neighbors.Add(allData.vertex, allData.neighbors[current.vertex]);
                    }

                    if (allData.vertex == current.vertex)
                    {
                        foreach (var i in allData.neighbors)
                        {
                            current.neighbors.Add(i.Key, i.Value);
                        }
                    }
                    allData = allData.next;
                }

                if (current.neighbors.Count == 1)
                {
                    continue;
                }
            }

            foreach (var i in current.neighbors)
            {
                auxiliaryGraph.neighbors.Add(i.Key, i.Value);
                if (Math.Abs(array[i.Key - 1]) < i.Value)
                {
                    array[i.Key - 1] = i.Value;
                    if (visitVertex[i.Key - 1])
                    {
                        array[i.Key - 1] = i.Value * -1;
                    }
                }
            }
            array[auxiliaryGraph.vertex - 1] *= -1;
            visitVertex[auxiliaryGraph.vertex - 1] = true;
            auxiliaryGraph.next = new Graph();
            auxiliaryGraph = auxiliaryGraph.next;
            int counter = 0;
            foreach (var i in visitVertex)
            {
                if (!i)
                {
                    ++counter;
                }
            }

            if (counter == 1)
            {
                auxiliaryGraph.vertex = Array.FindIndex(visitVertex, x => x.Equals(false)) + 1;
                continue;
            }

            if (counter == 0)
            {
                break;
            }

            auxiliaryGraph.vertex = Array.FindIndex(array, x => x.Equals(array.Where(x => x >= 0).Max())) + 1;
        }
        if (array.Contains(0))
        {
            throw new DisconnectedGraphException("Disconnect graph");
        }
        return array;
    }

    /// <summary>
    /// prints out the most optimal path in the graph
    /// </summary>
    /// <returns>optimal paths in graph</returns>
    public string OptimalPaths()
    {
        Graph graph = new Graph();
        string result = string.Empty;
        int[] resultArray = CalculateOptimalPath(graph);
        while (resultArray.Any(x => x != 0) && graph != null)
        {
            result = result + graph.vertex + ": ";
            foreach (var j in graph.neighbors)
            {
                if (resultArray.Contains(-j.Value) || resultArray.Contains(j.Value))
                {
                    result += j.Key + "(" + j.Value + ") ";
                    while (resultArray.Contains(-j.Value))
                    {
                        resultArray[Array.FindIndex(resultArray, x => x.Equals(-j.Value))] = 0;
                    }
                }
            }
            graph = graph.next;
            result += "\r\n";
        }
        return result;
    }
}
