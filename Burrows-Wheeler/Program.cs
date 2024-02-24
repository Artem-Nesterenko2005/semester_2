void sort(char[,] array)
{
    for (int i = 0; i < array.GetLength(1) - 1; i++)
    {
        for (int j = i + 1; j < array.GetLength(1); ++j)
        {
            for (int m = 0; m < array.GetLength(1); ++m)
            {
                if (array[i, m] == array[j, m])
                {
                    continue;
                }

                if (array[i, m] > array[j, m])
                {
                    for (int k = 0; k < array.GetLength(1); ++k)
                    {
                        char swap = array[i, k];
                        array[i, k] = array[j, k];
                        array[j, k] = swap;
                    }
                }
                break;
            }
        }
    }
}

string convertBack(string convertedString, int position, string sortArray)
{
    string result = "";
    for (int i = 0; i < convertedString.Length; ++i)
    {
        result += sortArray[position];

        int numberCoincidences = 0;
        for (int k = 0; k < position + 1; k++)
        {
            if (sortArray[k] == sortArray[position])
            {
                ++numberCoincidences;
            }
        }

        int newPosition = 0;
        int j = 0;
        while (newPosition != numberCoincidences)
        {
            if (convertedString[j] == result[i])
            {
                ++newPosition;
            }
            ++j;
        }
        position = j - 1;
    }
    return result;
}

void fillArray(char[,] array, string expression)
{
    for (int i = 0; i < expression.Length; ++i)
    {
        array[0, i] = expression[i];
    }

    for (int i = 1; i < expression.Length; ++i)
    {
        for (int j = 0; j < expression.Length; ++j)
        {
            array[i, j] = array[i - 1, (j + 1) % expression.Length];
        }
    }
}

int checkPosition(string expression, char[,] array)
{
    int position = 0;
    for (int i = 0; i < expression.Length; ++i)
    {
        if (position != 0)
        {
            break;
        }
        for (int j = 0; j < expression.Length; ++j)
        {
            if (expression[j] != array[i, j])
            {
                position = 0;
                break;
            }
            position = i;
        }
    }
    return position;
}

bool test()
{
    string expression = "abacaba";
    char[,] array = new char[expression.Length, expression.Length];
    fillArray(array, expression);
    sort(array);
    string result = "";
    for (int i = 0; i < expression.Length; ++i)
    {
        result += array[i, expression.Length - 1];
    }
    if (!string.Equals(result,"bcabaaa"))
    {
        return false;
    }
    int position = checkPosition(expression, array);
    if (position != 2)
    {
        return false;
    }
    string sortingString = "";
    for (int i = 0; i < expression.Length; ++i)
    {
        sortingString += array[i, 0];
    }
    return string.Equals(convertBack(result, position, sortingString), expression);
}

if (!test())
{
    Console.WriteLine("Error test");
    return;
}
Console.Write("Enter the string ");
string expression = Console.ReadLine();
if (expression == null)
{
    Console.WriteLine("Empty string");
    return;
}

char[,] array = new char[expression.Length, expression.Length];
fillArray(array, expression);
sort(array);

string result = "";
for (int i = 0; i < expression.Length; ++i)
{
    result += array[i, expression.Length - 1];
}
Console.WriteLine($"Converted string: {result}");

int position = checkPosition(expression, array);
Console.WriteLine($"Original string position: {position}");

string sortingString = "";
for (int i = 0; i < expression.Length; ++i)
{
    sortingString += array[i, 0];
}
Console.Write($"Original string: {convertBack(result, position, sortingString)}");
return;
