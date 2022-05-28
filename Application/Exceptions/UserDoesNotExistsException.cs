namespace hakaton_2022_backend.Application.Exceptions;

public class UserDoesNotExistsException : ApiException
{
    public override int StatusCode { get; } = 404;
    public override string Message { get; } = "User does not exist";
}