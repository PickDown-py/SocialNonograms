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

namespace SN.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.AddHttpClient<FinishedGameHttpClient>();
            builder.Services.AddHttpClient<GameHttpClient>();
            builder.Services.AddHttpClient<GridStateHttpClient>();
            builder.Services.AddHttpClient<RankHttpClient>();
            builder.Services.AddHttpClient<RatingHttpClient>();
            builder.Services.AddHttpClient<UnfinishedGameHttpClient>();
            builder.Services.AddHttpClient<UserHttpClient>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}