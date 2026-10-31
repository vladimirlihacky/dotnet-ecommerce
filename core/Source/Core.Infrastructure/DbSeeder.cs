namespace Core.Infrastructure;

public class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.SaveChangesAsync();
        return;
    }
}