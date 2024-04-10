
using Microsoft.EntityFrameworkCore;
using Solution.Domain.Interfaces.Infrastructures;
using Solution.Domain.Interfaces.Services;
using Solution.Domain.Services;
using Solution.Infrastructure;
using Solution.Infrastructure.Repositories;

namespace Solution.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<ITodoService, TodoService>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SolutionContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
