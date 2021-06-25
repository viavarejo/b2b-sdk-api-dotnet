using System;
using System.Collections.Generic;
using System.Text;

namespace SdkApiB2bLibrary.model.response
{
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Field> Fields { get; set; }
    }
}
