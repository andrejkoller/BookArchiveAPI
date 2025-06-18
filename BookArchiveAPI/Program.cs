
using BookArchiveAPI.Data;
using BookArchiveAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BookArchiveAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<BookService>();
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<BookArchiveDbContext>(options =>
               options.UseSqlite("Data Source=bookarchive.db"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BookArchiveDbContext>();
            context.Database.Migrate();
            DataSeeder.Seed(context);

            app.Run();
        }
    }
}
