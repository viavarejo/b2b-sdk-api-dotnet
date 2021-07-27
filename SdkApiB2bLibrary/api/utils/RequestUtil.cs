using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.utils
{
    public class RequestUtil<IN, OUT>
    {
        private readonly string basePath;// = "http://api-integracao-extra.hlg-b2b.net";
        private readonly string basePathMock;// = "http://localhost:8080";
        private readonly string token = "H9xO4+R8GUy+18nUCgPOlg==";

        private readonly HttpClient client = new();

        public RequestUtil()
        {
            basePath = "http://api-integracao-extra.hlg-b2b.net";
            basePathMock = "http://localhost:8080";
            token = "H9xO4+R8GUy+18nUCgPOlg==";
            //basePath = ConfigurationManager.AppSettings["Host"];
            //basePathMock = ConfigurationManager.AppSettings["HostMock"];
            //token = ConfigurationManager.AppSettings["Token"];

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);

        }

        public async Task<HttpResponseMessage> DoGetAsync(string fullPath)
        {
             try
            {
                HttpResponseMessage response = await client.GetAsync(fullPath);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<OUT> GetAsync(string path, Dictionary<String, String> queryParams)
        {
            string fullPath = basePath + path;
            if (queryParams != null)
            {
                fullPath += QueryParamStringBuilder(queryParams);
            }
            try
            {
                HttpResponseMessage response = await DoGetAsync(fullPath);
                //    response.EnsureSuccessStatusCode();
                string jsonContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OUT>(jsonContent);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<HttpResponseMessage> GetDownLoadAsync(string path)
        {
            string fullPath;
            if (string.IsNullOrEmpty(basePathMock))
            {
                fullPath = basePath + path;
            }
            else
            {
                fullPath = basePathMock + path;
            }

            try
            {
                HttpResponseMessage response = await DoGetAsync(fullPath);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return default;
        }

        public async Task<OUT> DoPostAsync(string path, IN entityIn)
        {
            string fullPath = basePath + path;
            string json = System.Text.Json.JsonSerializer.Serialize(entityIn);
            Console.WriteLine($"body entrada: {json}");
            StringContent data = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(fullPath, data);
            string jsonContent = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<OUT>(jsonContent);
            return result;
        }

        public async Task<OUT> DoPatchPostAsync(string path, IN entityIn)
        {
            string fullPath = basePath + path;
            string json = JsonConvert.SerializeObject(entityIn, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            Console.WriteLine($"body entrada: {json}");
            StringContent data = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PatchAsync(fullPath, data);
            string jsonContent = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<OUT>(jsonContent);
            return result;
        }


        private static String QueryParamStringBuilder(Dictionary<String, String> queryParams)
        {
            StringBuilder b = new();
            foreach (var keyValuePair in queryParams)
            {
                if (keyValuePair.Value != null)
                {
                    if (b.Length == 0)
                    {
                        b.Append('?');
                    }
                    else
                    {
                        b.Append('&');
                    }
                    b.Append(keyValuePair.Key).Append('=').Append(keyValuePair.Value);
                }
            }
            return b.ToString();
        }

    }
}
