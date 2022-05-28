namespace hakaton_2022_backend.Application.Exceptions;

public class EnterpriseAlreadyExistsException : ApiException
{
    public override int StatusCode => StatusCodes.Status403Forbidden;
    public override string Message => "Organization already exists.";
}