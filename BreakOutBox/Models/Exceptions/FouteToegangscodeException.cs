using System;

public class FouteToegangscodeException : Exception
{
    public FouteToegangscodeException()
    {
    }

    public FouteToegangscodeException(string message)
        : base(message)
    {
    }

    public FouteToegangscodeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}