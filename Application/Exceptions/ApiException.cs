namespace hakaton_2022_backend.Application.Exceptions;

public abstract class ApiException : Exception
{
    public abstract int StatusCode { get; }
    public abstract string Message { get; }
}