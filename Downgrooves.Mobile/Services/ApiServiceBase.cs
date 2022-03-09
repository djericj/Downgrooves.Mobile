using RestSharp;
using Serilog;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Downgrooves.Mobile.Services
{
    public abstract class ApiServiceBase
    {
        public ApiServiceBase()
        {
            Client = new RestClient();
            var settings = App.Settings.MobileApi;
            BaseUrl = settings.Url;
        }

        public RestClient Client { get; set; }

        public string BaseUrl
        {
            get => Client.BaseUrl.ToString();
            set => Client.BaseUrl = new Uri(value.TrimEnd('/'));
        }

        public async Task<IRestResponse> GetAsync(string path, CancellationToken cancel = default)
            => await ExecuteAsync(Method.GET, path, cancel);
        public async Task<IRestResponse> PostAsync(string path, object data = null, CancellationToken cancel = default)
            => await ExecuteAsync(Method.POST, path, data, cancel);
        public async Task<IRestResponse> PutAsync(string path, object data = null, CancellationToken cancel = default)
            => await ExecuteAsync(Method.PUT, path, data, cancel);
        public async Task<IRestResponse> DeleteAsync(string path, CancellationToken cancel = default)
            => await ExecuteAsync(Method.DELETE, path, cancel);

        private async Task<IRestResponse> ExecuteAsync(Method method, string path, object data = null, CancellationToken cancel = default, DataFormat format = DataFormat.Json)
        {
            try
            {
                var request = new RestRequest($"{Client.BaseUrl.AbsoluteUri.TrimEnd('/')}{path}", method);
                request.RequestFormat = format;
                request.AddHeader("Authorization", $"Bearer {App.Settings.MobileApi.Token}");
                if (data != null) request.AddJsonBody(data);
                return await Client.ExecuteAsync(request, cancel);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An exception occurred while ExecuteAsync");
                return new RestResponse() { ErrorException = ex, ErrorMessage = ex.Message, StatusCode = HttpStatusCode.InternalServerError };
            }
        }
    }
}
