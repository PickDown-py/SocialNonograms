using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using SN.Model;
using SN.ClientServices.Authentication;
using SN.ClientServices.Services.Abstract;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SN.ClientServices.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _stateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthenticationService(HttpClient httpClient, 
            AuthenticationStateProvider stateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _stateProvider = stateProvider;
            _localStorage = localStorage;
        }

        public async Task<AuthenticatedUserModel> LoginAsync(AuthenticationUserModel authenticationUserModel)
        {
            Console.WriteLine("Fuck you");
            var content = new StringContent(JsonConvert.SerializeObject(authenticationUserModel), Encoding.UTF8,
                "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var authResult = await _httpClient.PostAsync("api/Token/authenticate", content);
            var authContent = await authResult.Content.ReadAsStringAsync();

            if (!authResult.IsSuccessStatusCode)
            {
                return null;
            }

            Console.WriteLine($"Content: {authContent}");
            
            var result = JsonConvert.DeserializeObject<AuthenticatedUserModel>(authContent);
            
            Console.WriteLine($"Result: {result}");

            await _localStorage.SetItemAsync("authToken", result.AccessToken);
            
            ((AuthStateProvider)_stateProvider).NotifyUserAuthentication(result.AccessToken);

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", result.AccessToken);

            return result;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((AuthStateProvider)_stateProvider).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}