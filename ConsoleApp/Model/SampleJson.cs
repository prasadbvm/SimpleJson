using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp.Model
{
    //JSON Model - Based off Json file
    class SampleJson
    {
        public class JSONModel
        {
            [JsonIgnore] //Demonstration Purpose Only
            public Output[] output { get; set; }

            public Repositorylog repositoryLog { get; set; }
        }

        public class Repositorylog
        {
            [JsonIgnore] //Demonstration Purpose Only
            public string scenarioInfo { get; set; }
            [JsonIgnore]
            public Moqtransaction[] moqTransactions { get; set; }
        }

        public class Moqtransaction
        {
            [JsonIgnore]
            public string methodSignature { get; set; }
            [JsonIgnore]
            public string caller { get; set; }
            [JsonIgnore]
            public Inputparam[] inputParams { get; set; }
            public Returndata returnData { get; set; }
        }

        public class Returndata
        {
            public string type { get; set; }
            public object name { get; set; }

            public string data { get; set; }
        }

        public class Inputparam
        {
            public string type { get; set; }
            public string name { get; set; }
            [System.Text.Json.Serialization.JsonIgnore]
            public string data { get; set; }
        }

        public class Output
        {
            public int RequestId { get; set; }
            public int RequestTypeId { get; set; }
            public string accountNum { get; set; }
            public string accountName { get; set; }
            public object accountEngineerName { get; set; }
            public string clientNm { get; set; }
            public string streetAddress { get; set; }
            public string city { get; set; }
            public int stateProvinceId { get; set; }
            public int countyId { get; set; }
            public string postalCode { get; set; }
            public int countryId { get; set; }
            public string createBy { get; set; }
            public DateTime createDt { get; set; }
            public string updateBy { get; set; }
            public DateTime updateDt { get; set; }
            public object addressComment { get; set; }
        }       
    }

}