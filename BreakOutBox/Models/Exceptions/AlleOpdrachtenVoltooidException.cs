using System;

public class AlleOpdrachtenVoltooidException : Exception
{
    public AlleOpdrachtenVoltooidException()
    {
    }

    public AlleOpdrachtenVoltooidException(string message)
        : base(message)
    {
    }

    public AlleOpdrachtenVoltooidException(string message, Exception inner)
        : base(message, inner)
    {
    }
}