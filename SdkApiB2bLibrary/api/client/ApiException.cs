using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkApiB2bLibrary.api.client
{
    public class ApiException : Exception
    {
        public int Code { get;  } = 0;
        public Dictionary<String, List<Object>> ResponseHeaders { get;  }
        public String ResponseBody { get;  }

        public ApiException()
        {
        }

        public ApiException(int code, String message) : base(message)
        {
            this.Code = code;            
        }

        public ApiException(int code, String message, Dictionary<String, List<Object>> responseHeaders, String responseBody) : base(message)
        {
            this.Code = code;
            this.ResponseHeaders = responseHeaders;
            this.ResponseBody = responseBody;
        }
    }
}
