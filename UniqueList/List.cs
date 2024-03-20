/// <summary>
/// a list with methods for adding, deleting, changing data by index.
/// </summary>
/// <typeparam name="T">list data type.</typeparam>
public class List<T>
{
    /// <summary>
    /// next node in list for current node.
    /// </summary>
    public List<T> ?next;

    /// <summary>
    /// checks whether the data in the node was added by the user.
    /// </summary>
    public bool existenceData;

    /// <summary>
    /// list data type.
    /// </summary>
    public T ?data;

    /// <summary>
    /// create new list.
    /// </summary>
    public List()
    {
    }

    /// <summary>
    /// adds a new element at the unoccupied index position.
    /// </summary>
    /// <param name="position">index number of the data to be added.</param>
    /// <param name="data">data to add.</param>
    /// <exception cref="IndexOccupiedByElement">exception caused by an attempt to add data to a position where data already exists.</exception>
    public void Add(int position, T data)
    {
        List<T> ?current = this;
        for (int i = 0; i < position; ++i)
        {
            if (current.next == null)
            {
                current.next = new List<T>();
            }
            current = current.next;
        }

        if (!current.existenceData)
        {
            current.data = data;
            current.existenceData = true;
            return;
        }
        throw new IndexOccupiedByElement("Such an index is already occupied by the element");
    }

    /// <summary>
    /// deletes data from a given node.
    /// </summary>
    /// <param name="position">index number of the data to be removed.</param>
    /// <param name="data">data to add.</param>
    /// <exception cref="BeyondListBoundaries">exception received when trying to delete data from a node that does not exist.</exception>
    public void Remove(int position, T data)
    {
        List<T> ?current = this;
        for (int i = 0; i < position; ++i)
        {
            if (current == null)
            {
                throw new BeyondListBoundaries("There is no given element at this index");
            }
            current = current.next;
        }

        if (current.existenceData && !Equals(current.data, data) || !current.existenceData) 
        {
            throw new BeyondListBoundaries("There is no given element at this index");
        }
        current.data = default(T)!;
        current.existenceData = false;
    }

    /// <summary>
    /// changes index data.
    /// </summary>
    /// <param name="position">index number of the data to be removed.</param>
    /// <param name="data">data to remove.</param>
    /// <exception cref="BeyondListBoundaries">exception received when trying to change data from a node that does not exist.</exception>
    public void ChangeByIndex(int position, T data)
    {
        List<T> ?current = this;
        for (int i = 0; i < position; ++i)
        {
            if (current == null)
            {
                throw new BeyondListBoundaries("Index argument exceeds list length");
            }
            current = current.next;
        }

        if (current == null)
        {
            throw new BeyondListBoundaries("Index argument exceeds list length");
        }

        if (current.existenceData)
        {
            current.data = data;
            return;
        }

        throw new NonExistentElement("The given element does not exist at the given index");
    }
}
