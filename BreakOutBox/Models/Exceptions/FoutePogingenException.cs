using System;

public class FoutePogingenException : Exception
{
    public FoutePogingenException()
    {
    }

    public FoutePogingenException(string message)
        : base(message)
    {
    }

    public FoutePogingenException(string message, Exception inner)
        : base(message, inner)
    {
    }
}