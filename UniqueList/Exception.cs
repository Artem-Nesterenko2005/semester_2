public class RepeatingElement : SystemException
{
    public RepeatingElement(string text) : base(text)
    {
    }
}

public class NonExistentElement : SystemException
{
    public NonExistentElement(string text) : base(text) 
    {
    }
}

public class BeyondListBoundaries : SystemException
{
    public BeyondListBoundaries(string text) : base(text) 
    {
    }
}

public class IndexOccupiedByElement : SystemException
{
    public IndexOccupiedByElement(string text) : base(text) 
    {
    }
}
