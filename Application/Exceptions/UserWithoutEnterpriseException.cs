namespace hakaton_2022_backend.Application.Exceptions;

public class UserWithoutEnterpriseException : ApiException
{
    public override int StatusCode { get; } = 403;
    public override string Message { get; } = "User does not belong to any enterprise";
}