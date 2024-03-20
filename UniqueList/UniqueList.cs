/// <summary>
/// a list with methods for adding, deleting, changing data by index, containing nodes only with unique data.
/// </summary>
/// <typeparam name="T">list data type.</typeparam>
public class UniqueList<T> : List<T>
{
    private bool Contains(T data)
    {
        List<T> ?current = this;
        while (current != null)
        {
            if (Equals(current.data, data) && current.existenceData)
            {
                return true;
            }
            current = current.next;
        }
        return false;
    }

    /// <summary>
    /// adds a new element at the unoccupied index position.
    /// </summary>
    /// <param name="position">index number of the data to be added.</param>
    /// <param name="data">data to add.</param>
    /// <exception cref="RepeatingElement">exception when trying to add data to a position occupied by data.</exception>
    public void AddUniqueList(int position, T data)
    {
        if (Contains(data))
        {
            throw new RepeatingElement("There is already such an element in the list");
        }
        Add(position, data);
    }

    /// <summary>
    /// changes index data.
    /// </summary>
    /// <param name="position">index number of the data to be added.</param>
    /// <param name="data">data to add.</param>
    /// <exception cref="RepeatingElement">exception when trying to add data to a position occupied by data.</exception>
    public void ChangeByIndexUniqueList(int position, T data) 
    {
        if (Contains(data))
        {
            throw new RepeatingElement("There is already such an element in the list");
        }
        ChangeByIndex(position, data);
    }
}
