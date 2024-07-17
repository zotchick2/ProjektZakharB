using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjektZakharB.Models;
using System;
using System.IO;
using System.Windows;

namespace ProjektZakharB
{
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlite(context.Configuration.GetConnectionString("DefaultConnection")));

                    // Регистрация MainWindow с фабричным методом
                    services.AddSingleton<MainWindow>(provider =>
                    {
                        var dbContext = provider.GetRequiredService<ApplicationDbContext>();
                        return new MainWindow(dbContext);
                    });

                    // Регистрация AddUserWindow и ViewUsersWindow
                    services.AddTransient<AddUserWindow>(provider =>
                    {
                        var dbContext = provider.GetRequiredService<ApplicationDbContext>();
                        return new AddUserWindow(dbContext);
                    });

                    services.AddTransient<ViewUsersWindow>(provider =>
                    {
                        var dbContext = provider.GetRequiredService<ApplicationDbContext>();
                        return new ViewUsersWindow(dbContext);
                    });

                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
