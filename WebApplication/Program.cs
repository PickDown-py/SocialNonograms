using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SN.ClientServices.Authentication;
using SN.ClientServices.HttpClients;
using SN.ClientServices.Services;
using SN.ClientServices.Services.Abstract;
using SN.Model.Board.Listener;
using SN.Model.Board.Solver;
using SN.Model.Solver;


namespace WebApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri("https://localhost:5001")});

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<IGameService, GameService>();
            builder.Services.AddScoped<IBoardListener, BoardListener>();
            builder.Services.AddScoped<IBoardSolver, BoardSolver>();

            builder.Services.AddScoped<FinishedGameHttpClient>();
            builder.Services.AddScoped<GameHttpClient>();
            builder.Services.AddScoped<GridStateHttpClient>();
            builder.Services.AddScoped<RankHttpClient>();
            builder.Services.AddScoped<RatingHttpClient>();
            builder.Services.AddScoped<UnfinishedGameHttpClient>();
            builder.Services.AddScoped<UserHttpClient>();

            
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            builder.Services.AddCors();
            
            await builder.Build().RunAsync();
        }
    }
}