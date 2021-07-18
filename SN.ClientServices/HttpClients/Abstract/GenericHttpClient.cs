using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SN.Entity;

namespace SN.ClientServices.HttpClients.Abstract
{
    public abstract class GenericHttpClient<TEntity, TKey> where TEntity : IEntity<TKey>
    {

        protected string Url;
        protected HttpClient Http;

        protected GenericHttpClient(HttpClient http)
        {
            Http = http;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            Console.WriteLine(Http.BaseAddress + Url);
            var response = await Http.GetAsync(Url);
            
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<TEntity>>(responseStream);
        }
        
        public async Task<TEntity> GetAsync(TKey id)
        {
            Console.WriteLine(Http.BaseAddress + Url+$"/{id}");
            var response = await Http.GetAsync(Url+$"/{id}");
           
            
            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TEntity>(responseStream);
        }

        public async Task PostAsync(TEntity entity)
        {
            var entityJson = new StringContent(JsonSerializer.Serialize(entity),
                Encoding.UTF8, "application/json");

            using var httpResponse = await Http.PostAsync(Url, entityJson);
            httpResponse.EnsureSuccessStatusCode();
        }
        
        public async Task PutAsync(TEntity entity)
        {
            var entityJson = new StringContent(JsonSerializer.Serialize(entity),
                Encoding.UTF8, "application/json");

            using var httpResponse = await Http.PutAsync(Url + $"/{entity.Id}", entityJson);
            httpResponse.EnsureSuccessStatusCode();
        }
        
        public async Task DeleteAsync(TKey id)
        {
            using var httpResponse = await Http.DeleteAsync(Url + $"/{id}");
            httpResponse.EnsureSuccessStatusCode();
        }
    }
}