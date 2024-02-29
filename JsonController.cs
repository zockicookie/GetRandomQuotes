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
        public List<Quote> DeserializeJson<Quote>(string json)
        {
            List<Quote> temp = JsonConvert.DeserializeObject<List<Quote>>(json);

            return temp;
        }
        

    }
}
