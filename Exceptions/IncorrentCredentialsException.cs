namespace hakaton_2022_backend.Exceptions;

public class IncorrentCredentialsException : ApiException
{
    public override int StatusCode => StatusCodes.Status403Forbidden;
    public override string Message => "Wrong credentials";
}