namespace Core.Application;

public class NotFoundException : Exception
{
    public NotFoundException() { }
    public NotFoundException(string message) : base(message) { }
}

public class InvalidRequestException : Exception
{
    public InvalidRequestException() { }
    public InvalidRequestException(string message) : base(message) { }
    public InvalidRequestException(string message, Exception inner) : base(message, inner) { }
}

public class InternalException : Exception
{
    public InternalException() { }
}