using Microsoft.VisualStudio.TestTools.UnitTesting;
using SdkApiB2bLibrary.model.response;
using SdkApiLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SdkApiB2bTest
{
    [TestClass]
    public class SegurancaApiTest
    {
        readonly SegurancaApi api = new();

        private static readonly String chave = "MIIENTCCAx2gAwIBAgIJAJ5ApEGl2oaIMA0GCSqGSIb3DQEBBQUAMIGwMQswCQYDVQQGEwJCUjELMAkGA1UECAwCU1AxFDASBgNVBAcMC1NBTyBDQUVUQU5PMRMwEQYDVQQKDApWSUEgVkFSRUpPMSAwHgYDVQQLDBdTRUdVUkFOQ0EgREEgSU5GT1JNQUNBTzEOMAwGA1UEAwwFUFJPWFkxNzA1BgkqhkiG9w0BCQEWKHRpLnNlZ3VyYW5jYS5pbmZvcm1hY2FvQHZpYXZhcmVqby5jb20uYnIwHhcNMTgwODE2MTIzNjQ2WhcNMjEwODE1MTIzNjQ2WjCBsDELMAkGA1UEBhMCQlIxCzAJBgNVBAgMAlNQMRQwEgYDVQQHDAtTQU8gQ0FFVEFOTzETMBEGA1UECgwKVklBIFZBUkVKTzEgMB4GA1UECwwXU0VHVVJBTkNBIERBIElORk9STUFDQU8xDjAMBgNVBAMMBVBST1hZMTcwNQYJKoZIhvcNAQkBFih0aS5zZWd1cmFuY2EuaW5mb3JtYWNhb0B2aWF2YXJlam8uY29tLmJyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAqObNb7KAP09WsV9h76Dw3tj2qa3l97K+slfzLkOBvi0xjacuKCnvsMSGEBosvWY/qNmSLE1YaoyFt7ZaeOiALKh2AFckJRM+/zvQzqi6cPnW0cGsEE/9WO48Fgh894pKjHpukATFb9tBYGTBEW46AH2WiAR735KEnDfFAHG//pkLKriPWEZBr9tf4gdNvyJ/ybs5JrBRU1RKE9MM7qnMkCouKTPwY/lS/2Xb1IYkyZulCf3Uyl7zpB6hQUhprS1R5meRocpGgHJCFfiWD/uXa5nREuGuQxcImwzvf+enwT6CooRoM2rN6IQWSY+uQ64dhSt4FMajZFmHVpLfUIOjEwIDAQABo1AwTjAdBgNVHQ4EFgQUZ22K62aMm/lI5LfblgINPvz8ae8wHwYDVR0jBBgwFoAUZ22K62aMm/lI5LfblgINPvz8ae8wDAYDVR0TBAUwAwEB/zANBgkqhkiG9w0BAQUFAAOCAQEAj23IDXLPkQpFDbgAtgKuO9N66o61edbJ1+BMjdSsfO0vMVpmBDlKdinxlh509/qJm/WLYswKkKOi7VHojBSV5HyrO5YGCSJFvVGJqF4JUxy7GrWTHqgwcylmX5B5lNd5aMIxwG6AF4o2cp6IPe+Uwaroa8kLTrtM0eRgAInHbQA7MXbvOZY+pzE4s6jFbA1O321zVg4C4Y3C4e30yf9YJNK5XjUP26duvwGqQrZg49ZU3W/t6GYY1kQhSeBG0FPg2GOIHX03WPZpaJ7i1uCv6Ial07pxDxqcT8oCJalY9tW9sv7zBJRaJgTIf5oz5jElb9kWd2D6XwaGB5PJfD6CTQ==";

        [TestMethod]
        public async Task TestValidaChaveAsync()
        {
            ChaveDTO dto = await api.GetChave();
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine($"Response:{JsonSerializer.Serialize(dto, options)}");
            Assert.IsNotNull(dto);
            Assert.AreEqual(chave, dto.Data.ChavePublica);

        }
    }
}
