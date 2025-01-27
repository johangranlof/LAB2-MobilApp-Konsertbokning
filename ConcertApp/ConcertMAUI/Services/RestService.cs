using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ConcertMAUI.Services.Interfaces;

namespace ConcertMAUI.Services
{
    public class RestService<T> : IRestService<T> where T : class
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        IHttpsClientHandlerService _httpsClientHandlerService;
        string endpoint = GetEndpointForType.GetEndpoint<T>();

        public List<T>? Items { get; private set; }

        public RestService(IHttpsClientHandlerService service)
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<T>> RefreshDataAsync()
        {
            Items = new List<T>();

            Uri uri = new Uri(string.Format(Constants.RestUrl(endpoint, string.Empty)));

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<T>>(content, _serializerOptions);
                }
                else
                {
                    Debug.WriteLine($"Fel: Servern svarade med statuskod {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fel vid förfrågan: {ex.Message}");
            }

            return Items;
        }


        public async Task SaveItemAsync(T item, bool isNewItem)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl(endpoint, string.Empty)));

            try
            {
                string json = JsonSerializer.Serialize<T>(item, _serializerOptions);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("\tItem successfully saved.");
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
                Debug.WriteLine($"\tStack Trace: {ex.StackTrace}");
            }
        }


        public async Task DeleteItemAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl(endpoint, id.ToString())));

            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                    Debug.WriteLine(@"\tItem successfully deleted.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}

