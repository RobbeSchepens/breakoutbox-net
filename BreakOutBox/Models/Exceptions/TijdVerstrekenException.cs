using System;

public class TijdVerstrekenException : Exception
{
    public TijdVerstrekenException()
    {
    }

    public TijdVerstrekenException(string message)
        : base(message)
    {
    }

    public TijdVerstrekenException(string message, Exception inner)
        : base(message, inner)
    {
    }
}