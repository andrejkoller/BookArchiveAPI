
using System.Text.Json.Serialization;
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowVueApp",
                    policy => policy.WithOrigins("http://localhost:5173")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            builder.Services.AddScoped<BookService>();
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<BookArchiveDbContext>(options =>
               options.UseSqlite("Data Source=bookarchive.db"));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }
            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.UseCors("AllowVueApp");

            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BookArchiveDbContext>();
            context.Database.Migrate();
            DataSeeder.Seed(context);

            app.Run();
        }
    }
}
