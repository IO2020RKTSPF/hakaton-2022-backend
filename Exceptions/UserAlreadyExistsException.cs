namespace hakaton_2022_backend.Exceptions;

public class UserAlreadyExistsException : ApiException
{
    
    public override int StatusCode => StatusCodes.Status403Forbidden;
    public override string Message => "Users credentials already in use.";
}