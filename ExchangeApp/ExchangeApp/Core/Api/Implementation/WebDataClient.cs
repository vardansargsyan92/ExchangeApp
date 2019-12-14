using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExchangeApp.Core.Api.Implementation
{
    public class WebDataClient : IDataClient
    {
        private readonly string _apiBaseAddress;

        public WebDataClient(
            IConfigurationProvider configurationProvider)
        {
            _apiBaseAddress = configurationProvider.BaseAddress;
        }

        public Task<T> GetAsync<T>(string path, CancellationToken token = default)
        {
            return GetAsync<T>(path, null, token);
        }

        public async Task<T> GetAsync<T>(string path, string query, CancellationToken token = default)
        {
            var uriBuilder = new UriBuilder(_apiBaseAddress);
            uriBuilder.Path += path;
            uriBuilder.Query = query;
            T deserializedResponseContent;

            using (var httpClient = GetClient())
            {
                var response = await httpClient.GetAsync(uriBuilder.Uri, token);
                ThrowIfNotSuccess(response);
                var serializedResponseContent = await response.Content.ReadAsStringAsync();
                deserializedResponseContent = JsonConvert.DeserializeObject<T>(serializedResponseContent);
            }

            return deserializedResponseContent;
        }

        public Task PutAsync<T>(string path, T obj, CancellationToken token = default)
        {
            var jsonObject = JsonConvert.SerializeObject(obj);
            return PutJsonAsync(path, jsonObject, token);
        }

        public async Task PutJsonAsync(string path, string json, CancellationToken token = default)
        {
            var uriBuilder = new UriBuilder(_apiBaseAddress);
            uriBuilder.Path += path;

            using (var httpClient = GetClient())
            {
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(uriBuilder.Uri, httpContent, token);
                ThrowIfNotSuccess(response);
            }
        }

        public Task PostAsync<T>(string path, T obj, CancellationToken token = default)
        {
            var jsonObject = JsonConvert.SerializeObject(obj);
            return PostJsonAsync(path, jsonObject, token);
        }

        public async Task PostJsonAsync(string path, string json, CancellationToken token = new CancellationToken())
        {
            var uriBuilder = new UriBuilder(_apiBaseAddress);
            uriBuilder.Path += path;

            using (var httpClient = GetClient())
            {
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uriBuilder.Uri, httpContent, token);
                ThrowIfNotSuccess(response);
            }
        }

        public async Task<TK> PostAsync<T, TK>(string path, T obj, CancellationToken token = default)
        {
            var uriBuilder = new UriBuilder(_apiBaseAddress);
            uriBuilder.Path += path;
            TK deserializedResponseContent;

            using (var httpClient = GetClient())
            {
                var jsonObject = JsonConvert.SerializeObject(obj, Formatting.Indented);
                var httpContent = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uriBuilder.Uri, httpContent, token);
                ThrowIfNotSuccess(response);
                var serializedResponseContent = await response.Content.ReadAsStringAsync();
                deserializedResponseContent = JsonConvert.DeserializeObject<TK>(serializedResponseContent);
            }

            return deserializedResponseContent;
        }

        public async Task DeleteAsync(string path, CancellationToken token = new CancellationToken())
        {
            var uriBuilder = new UriBuilder(_apiBaseAddress);
            uriBuilder.Path += path;

            using (var httpClient = GetClient())
            {
                var response = await httpClient.DeleteAsync(uriBuilder.Uri, token);
                ThrowIfNotSuccess(response);
            }
        }

        public Task PostFileAsync(string path, string fileName, byte[] content,
            CancellationToken token = default)
        {
            return PostFileInternalAsync(path, fileName, content, token);
        }

        public async Task<T> PostFileAsync<T>(string path, string fileName, byte[] content,
            CancellationToken token = default)
        {
            var response = await PostFileInternalAsync(path, fileName, content, token);
            var serializedResponseContent = await response.Content.ReadAsStringAsync();
            var deserializedResponseContent = JsonConvert.DeserializeObject<T>(serializedResponseContent);
            return deserializedResponseContent;
        }

        private HttpClient GetClient()
        {
            var client = new HttpClient();
            return client;
        }

        private void ThrowIfNotSuccess(HttpResponseMessage response)
        {
            //if (response.StatusCode == HttpStatusCode.Unauthorized) _hub.Publish(new WebRequestUnauthorizedMessage());
            //if (response.StatusCode != HttpStatusCode.OK || response.StatusCode != HttpStatusCode.Created)
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw
                    new WebRequestException(response.StatusCode);
        }

        private async Task<HttpResponseMessage> PostFileInternalAsync(string path, string fileName, byte[] content,
            CancellationToken token = default)
        {
            var uriBuilder = new UriBuilder(_apiBaseAddress);
            uriBuilder.Path += path;

            var streamContent = new StreamContent(new MemoryStream(content));
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            using (var httpClient = GetClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(streamContent, "file", fileName);

                var response = await httpClient.PostAsync(uriBuilder.Uri, formData, token);
                ThrowIfNotSuccess(response);
                return response;
            }
        }
    }
}