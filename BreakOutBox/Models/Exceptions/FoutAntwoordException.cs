using System;

public class FoutAntwoordException : Exception
{
    public FoutAntwoordException()
    {
    }

    public FoutAntwoordException(string message)
        : base(message)
    {
    }

    public FoutAntwoordException(string message, Exception inner)
        : base(message, inner)
    {
    }
}