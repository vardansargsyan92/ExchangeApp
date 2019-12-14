using System.Threading;
using System.Threading.Tasks;

namespace ExchangeApp.Core.Api
{
    public interface IDataClient
    {
        Task<T> GetAsync<T>(string path, CancellationToken token = default);
        Task<T> GetAsync<T>(string path, string query, CancellationToken token = default);
        Task PutAsync<T>(string path, T obj, CancellationToken token = default);
        Task PutJsonAsync(string path, string json, CancellationToken token = default);
        Task PostAsync<T>(string path, T obj, CancellationToken token = default);
        Task PostJsonAsync(string path, string json, CancellationToken token = default);
        Task<TK> PostAsync<T, TK>(string path, T obj, CancellationToken token = default);
        Task DeleteAsync(string path, CancellationToken token = default);
        Task PostFileAsync(string path, string fileName, byte[] content, CancellationToken token = default);
        Task<T> PostFileAsync<T>(string path, string fileName, byte[] content, CancellationToken token = default);
    }
}