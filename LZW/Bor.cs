/// <summary>
///data structure bor (prefix tree), with methods for adding strings, deleting strings, searching for strings, calculating the number of postfixes of a strings
/// </summary>
public class Bor
{
    /// <summary>
    /// string code from bor
    /// </summary>
    public int code;

    /// <summary>
    /// number of strings in bor
    /// </summary>
    public int size;

    /// <summary>
    /// number of postfixes for a node.
    /// </summary>
    private int numberPostfix;

    /// <summary>
    /// shows whether the node is a terminal node.
    /// </summary>
    private bool isTerminal;

    /// <summary>
    /// dictionary for storing strings.
    /// </summary>
    public Dictionary<char, Bor> dictionary;

    /// <summary>
    /// creates a node for bor.
    /// </summary>
    public Bor()
    {
        code = 0;
        numberPostfix = 0;
        isTerminal = false;
        dictionary = new Dictionary<char, Bor>();
    }

    private void subtractPostfix(string element)
    {
        var auxiliaryDictionary = dictionary;
        foreach (var i in element)
        {
            --auxiliaryDictionary[i].numberPostfix;
            auxiliaryDictionary = auxiliaryDictionary[i].dictionary;
        }
    }

    /// <summary>
    /// adds a string to the bor.
    /// </summary>
    /// <param name="element">the string to be inserted into the bor.</param>
    /// <returns>returns true if the string is new.</returns>
    public bool Add(string element, int codeElement)
    {
        if (element.Equals(""))
        {
            return false;
        }
        bool result = false;
        var auxiliaryDictionary = dictionary;
        foreach (var i in element)
        {
            if (!auxiliaryDictionary.ContainsKey(i))
            {
                Bor node = new Bor();
                auxiliaryDictionary.Add(i, node);
                node.code = codeElement;
                result = true;
            }

            if (i == element[element.Length - 1])
            {
                if (!auxiliaryDictionary[i].isTerminal)
                {
                    result = true;
                }
                auxiliaryDictionary[i].isTerminal = true;
            }

            ++auxiliaryDictionary[i].numberPostfix;
            auxiliaryDictionary = auxiliaryDictionary[i].dictionary;
        }
        if (result)
        {
            ++size;
            return result;
        }
        subtractPostfix(element);
        return result;
    }

    /// <summary>
    /// checks bor for string presence.
    /// </summary>
    /// <param name="element">string to be checked for presence in bor.</param>
    /// <returns>returns true if the string is contained in bor.</returns>
    public bool Contains(string element)
    {
        var auxiliaryDictionary = dictionary;
        bool checkTerminal = false;
        foreach (var i in element)
        {
            if (auxiliaryDictionary.ContainsKey(i))
            {
                checkTerminal = auxiliaryDictionary[i].isTerminal;
                auxiliaryDictionary = auxiliaryDictionary[i].dictionary;
                continue;
            }
            return false;
        }
        return checkTerminal;
    }

    /// <summary>
    /// checks the string code
    /// </summary>
    /// <param name="element">string from Bor</param>
    /// <returns>string code "element"</returns>
    public int CheckCode(string element)
    {
        var auxiliaryDictionary = dictionary;
        for (int i = 0; i < element.Length - 2; ++i)
        {
            auxiliaryDictionary = auxiliaryDictionary[element[i]].dictionary;
        }
        return element.Length != 1 ? auxiliaryDictionary[element[element.Length - 2]].code : auxiliaryDictionary[element[element.Length - 1]].code;
    }
}
