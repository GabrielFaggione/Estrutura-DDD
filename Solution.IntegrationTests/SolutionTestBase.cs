using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Solution.Application;
using Solution.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.IntegrationTests
{
    public class SolutionTestBase : IDisposable
    {

        private readonly string _database = "main";
        private readonly string _username = "sa";
        private readonly string _password = "pa$$word";
        private readonly int _port = 1433;

        private IContainer _container;
        public WebApplicationFactory<Program> _factory;

        public SolutionTestBase()
        {
            _container = new ContainerBuilder()
                .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
                .WithPortBinding(_port, true)
                .WithEnvironment("ACCEPT_EULA", "Y")
                .WithEnvironment("SQLCMDUSER", _username)
                .WithEnvironment("SQLCMDPASSWORD", _password)
                .WithEnvironment("MSSQL_SA_PASSWORD", _password)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(_port))
                .Build();

            _container.StartAsync().Wait();

            var host = _container.Hostname;
            var port = _container.GetMappedPublicPort(_port);

            var connectionString = $"Server={host},{port};Database={_database};User Id={_username};Password={_password};TrustServerCertificate=True";
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.AddDbContext<SolutionContext>(options =>
                            options.UseSqlServer(connectionString));
                    });
                });

            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<SolutionContext>();
            dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            _container.StopAsync().Wait();
            _container.DisposeAsync().GetAwaiter().GetResult();
            _factory.Dispose();
        }
    }
}
