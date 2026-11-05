namespace Core.Domain;

[System.Serializable]
public class DomainException : System.Exception
{
    public DomainException() { }
    public DomainException(string message) : base(message) { }
    public DomainException(string message, System.Exception inner) : base(message, inner) { }
}

[System.Serializable]
public class InsufficientFundsException : DomainException
{
    public InsufficientFundsException() { }
    public InsufficientFundsException(string message) : base(message) { }
    public InsufficientFundsException(string message, System.Exception inner) : base(message, inner) { }
}

[System.Serializable]
public class ValidationException : DomainException
{
    public ValidationException() { }
    public ValidationException(string message) : base(message) { }
    public ValidationException(string message, System.Exception inner) : base(message, inner) { }
}

[System.Serializable]
public class InvalidStateTransitionException : DomainException
{
    public InvalidStateTransitionException() { }
    public InvalidStateTransitionException(string message) : base(message) { }
    public InvalidStateTransitionException(string message, System.Exception inner) : base(message, inner) { }
}