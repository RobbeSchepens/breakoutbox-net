using System;

public class DrieFoutePogingenException : Exception
{
    public DrieFoutePogingenException()
    {
    }

    public DrieFoutePogingenException(string message)
        : base(message)
    {
    }

    public DrieFoutePogingenException(string message, Exception inner)
        : base(message, inner)
    {
    }
}