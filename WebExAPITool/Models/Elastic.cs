using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Nest;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models
{
    public class ElasticStructure
    {
        public KafkaStructure Source { get; set; }
        public FieldStruct fields { get; set; }
    }

    public class FieldStruct
    {
        public string  mod_date_time {get;set;}
        public string last_tr_date_time { get;set;}
        public string time { get;set;}
        public string creation_date_time { get;set;}
    }
    public class Elastic
    {
        private readonly IConfiguration _Config;
        public Elastic(WebExDBContext context, IConfiguration config)
        {
            _Config = config;
        }

        public async Task<bool> SendDataToelastic(KafkaStructure outputJson, string indexName)
        {
            //var objElasticStruct = new ElasticStructure();
            //objElasticStruct.Source = outputJson;
            //objElasticStruct.fields = new FieldStruct();
            //objElasticStruct.fields.creation_date_time = outputJson.payload.creation_date_time;
            //objElasticStruct.fields.mod_date_time  = outputJson.payload.mod_date_time ;
            //objElasticStruct.fields.last_tr_date_time   = outputJson.payload.last_tr_date_time;
            //objElasticStruct.fields.time    = outputJson.payload.time;

            // Make the componenet for the 
            var host = _Config.GetSection("ElasticSettings").GetValue<string>("host");
            var connSettings = new ConnectionSettings(new Uri(host));
            connSettings.DisableDirectStreaming(true);
            
            
            var client = new ElasticClient(connSettings);
            //var document = objElasticStruct;
            var indexResponse = client.Index(new IndexRequest<Payload>(outputJson.payload , indexName));
           
            return true;
        }
    }
}
