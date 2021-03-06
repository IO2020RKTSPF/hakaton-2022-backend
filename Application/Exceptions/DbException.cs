namespace hakaton_2022_backend.Application.Exceptions;

public class DbException : ApiException
{
    public override int StatusCode => StatusCodes.Status500InternalServerError;
    public override string Message => "Db access error";
}