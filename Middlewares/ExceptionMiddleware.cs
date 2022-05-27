using hakaton_2022_backend.Exceptions;

namespace hakaton_2022_backend.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            if (e is ApiException apiException)
                context.Response.StatusCode = apiException.StatusCode;
            else
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        }
    }
}