namespace Core.Domain;

public class InvalidTransitionException : Exception
{
    public InvalidTransitionException(string from, string to) : base($"Invalid state change: {from} -> {to}") { }
}

public class InvalidPropertyException<T> : Exception
{
    public InvalidPropertyException(string prop, T val) : base($"Invalid property {prop}: {val}") { }
}