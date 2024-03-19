/// <summary>
/// a class containing methods for decompressing and compressing data from files using an algorithm LZW
/// </summary>
public class LZW
{
    /// <summary>
    /// compresses data from a file using an algorithm LZW
    /// </summary>
    /// <param name="data">data from the file</param>
    /// <returns>list of encoded characters</returns>
    public List<int> Compress(string data)
    {
        if (data == "")
        {
            return new List<int>(); 
        }
        var compressBor = new Bor();
        foreach (var i in data)
        {
            if (!compressBor.Contains(i.ToString()))
            {
                compressBor.Add(i.ToString(), i);
            }
        }
        string newString = string.Empty;
        List<int> result = new List<int>();
        var codeCounter = 256;
        foreach (var i in data)
        {
            newString += (char)i;
            if (!compressBor.Contains(newString))
            {
                compressBor.Add(newString, codeCounter++);
                result.Add(compressBor.CheckCode(newString));
                newString = string.Empty;
                newString += (char)i;
            }
        }
        if (newString.Length > 1) 
        {
            var dictionary = compressBor.dictionary;
            for (var i = 0; i < newString.Length - 1; ++i)
            {
                dictionary = dictionary[newString[i]].dictionary;
            }
            result.Add((int)dictionary[newString[newString.Length - 1]].code);
            return result;
        }
        result.Add(compressBor.CheckCode(data[data.Length - 1].ToString()));
        return result;
    }

    /// <summary>
    /// decompresses an array of strings into the original string
    /// </summary>
    /// <param name="compressedData">array of strings from the file</param>
    /// <returns>decompressed string</returns>
    public string Decompress(string[] compressedData)
    {
        var dictionary = new Dictionary<int, string>();
        string result = string.Empty;
        int codeCounter = 256;
        string auxiliaryString = string.Empty;

        foreach (var a in compressedData)
        {
            int i = int.Parse(a);
            if (i < 256)
            {
                result += (char)i;
                auxiliaryString += (char)i;
            }
            else
            {
                result += dictionary[i];
                dictionary.Add(codeCounter++, auxiliaryString + dictionary[i][0]);
                auxiliaryString = string.Empty;
                auxiliaryString += dictionary[i];
            }

            if (auxiliaryString.Length > 1 && !dictionary.ContainsKey(i))
            {
                dictionary.Add(codeCounter++, auxiliaryString);
                auxiliaryString = auxiliaryString.Substring(auxiliaryString.Length - 1);
            }
        }
        return result;
    }
}
