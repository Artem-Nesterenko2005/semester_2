/// <summary>
///data structure bor (prefix tree), with methods for adding strings, deleting strings, searching for strings, calculating the number of postfixes of a strings
/// </summary>
public class Bor
{
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
    private Dictionary<char, Bor> dictionary;

    /// <summary>
    /// creates a node for bor.
    /// </summary>
    public Bor()
    {
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
    public bool Add(string element)
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

    private void RemoveString(string element)
    {
        var auxiliaryDictionary = dictionary;
        foreach (var i in element)
        {
            if (auxiliaryDictionary[i].numberPostfix == 1)
            {
                auxiliaryDictionary.Remove(i);
                return;
            }
            --auxiliaryDictionary[i].numberPostfix;
            auxiliaryDictionary = auxiliaryDictionary[i].dictionary;
        }
    }

    /// <summary>
    /// removes a string from the bor.
    /// </summary>
    /// <param name="element">string to be deleted.</param>
    /// <returns>returns true if the string was actually in the bor.</returns>
    public bool Remove(string element)
    {
        if (element.Equals(""))
        {
            return false;
        }
        var auxiliaryDictionary = dictionary;
        for (int i = 0; i < element.Length - 1; ++i)
        {
            if (!auxiliaryDictionary.ContainsKey(element[i]))
            {
                return false;
            }
            auxiliaryDictionary = auxiliaryDictionary[element[i]].dictionary;
        }

        if (!auxiliaryDictionary[element[element.Length - 1]].isTerminal)
        {
            return false;
        }

        if (auxiliaryDictionary[element[element.Length - 1]].isTerminal && auxiliaryDictionary[element[element.Length - 1]].dictionary.Count != 0)
        {
            auxiliaryDictionary[element[element.Length - 1]].isTerminal = false;
        }

        RemoveString(element);
        --size;
        return true;
    }

    /// <summary>
    /// checks how many strings start with a given prefix.
    /// </summary>
    /// <param name="prefix">prefix to check.</param>
    /// <returns>returns the number of strings that start with the given prefix.</returns>
    public int HowManyStartsWithPrefix(string prefix)
    {
        var result = 0;
        var auxiliaryDictionary = dictionary;
        foreach (var i in prefix)
        {
            if (!auxiliaryDictionary.ContainsKey(i))
            {
                return 0;
            }
            result = auxiliaryDictionary[i].numberPostfix;
            auxiliaryDictionary = auxiliaryDictionary[i].dictionary;
        }
        return result;
    }
}
