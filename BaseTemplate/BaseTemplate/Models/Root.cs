using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BaseTemplate.Models
{
    public class Root
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        [JsonProperty("@odata.count")]
        public int OdataCount { get; set; }
        public List<Value> value { get; set; }
    }

    public class Value 
    {
        public int ID { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedTS { get; set; }
    }
}
