using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace GetRandomQuotes
{
    class JsonController
    {
        public JsonInstance DeserializeJson<JsonInstance>(string json)
        {
            return JsonConvert.DeserializeObject<JsonInstance>(json);
        }
        

    }
}
