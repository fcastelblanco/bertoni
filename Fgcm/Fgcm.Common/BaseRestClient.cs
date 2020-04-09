using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Fgcm.Common
{
    public class BaseRestClient
    {
        protected readonly string BaseUri;

        public BaseRestClient(string baseUri)
        {
            BaseUri = baseUri;
        }


        protected async Task<TOut> Get<TOut>(string requestUri, IDictionary<string, string> aditionalHeaders = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(BaseUri);
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    if (aditionalHeaders != null)
                        foreach (var aditionalHeader in aditionalHeaders)
                            httpClient.DefaultRequestHeaders.Add(aditionalHeader.Key, aditionalHeader.Value);

                    using (var response = await httpClient.GetAsync(requestUri))
                    {
                        response.EnsureSuccessStatusCode();

                        var responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TOut>(responseBody);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        protected async Task<TOut> Post<TOut, TIn>(TIn entity, string requestUri,
            IDictionary<string, string> aditionalHeaders = null, bool? isApplicationException = null)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(BaseUri);
                    httpClient.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    if (aditionalHeaders != null)
                        foreach (var aditionalHeader in aditionalHeaders)
                            httpClient.DefaultRequestHeaders.Add(aditionalHeader.Key, aditionalHeader.Value);

                    using (var response = await httpClient.PostAsync(requestUri,
                        new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json")))
                    {
                        response.EnsureSuccessStatusCode();

                        var responseBody = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<TOut>(responseBody);
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Debug.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}