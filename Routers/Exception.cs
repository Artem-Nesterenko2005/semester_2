public class EmptyFileException : SystemException
{
    public EmptyFileException(string text) : base(text)
    {
    }
}

public class DisconnectedGraphException : SystemException
{
    public DisconnectedGraphException(string text) : base(text) 
    {
    }
}
