using Microsoft.EntityFrameworkCore;

namespace hakaton_2022_backend.Data;

public class DbPrep
{
    public static void PrepDb(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
            if (dbContext is not null)
            {
                dbContext.Database.Migrate();
            } 

        }
    }
}