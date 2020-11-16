using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static ConsoleApp.Model.SampleJson;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json"); //Congifure appsettings for reading json

            var configuration = builder.Build();

            string SampleJson = configuration["SampleJson"];//Read Json from Config
            string MaskedJson = configuration["MaskedJson"];
            Console.WriteLine(MaskedJson);
            Console.WriteLine(MaskedJson);

            try
            {              
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var jsonString = File.ReadAllText(SampleJson); //Read the json and Deserialize
                var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JSONModel>(jsonString);

                JToken token = JToken.Parse(jsonString);
                var jsonPaths = File.ReadAllText(MaskedJson);
                

                JSONModel model = JsonConvert.DeserializeObject<JSONModel>(jsonString);
                MaskedJson maskedDataElements = JsonConvert.DeserializeObject<MaskedJson>(jsonString);
                MaskedJson maskedJson = new MaskedJson();
                //Console.WriteLine(model);
                //Console.WriteLine(jsonElement);
                var data = jsonElement.repositoryLog.moqTransactions[0].returnData.data;
                
                
                //JsonHelper.ObscureMatchingValues(data, jsonPaths); //Compare method
                ExampleLogger.Log(token.ToString(Formatting.None));
                var model2 = JsonConvert.DeserializeObject<JArray>(data);
                
                //Loop through Json to compare against Mask Objects
                foreach (JObject content in model2.Children<JObject>())
                {
                    foreach (JProperty prop in content.Properties())
                    {
                        foreach(string arr in prop.Last)
                        {                            
                            if (prop.Last.Equals(maskedDataElements))
                            {
                                prop.Value = "xxx"; //Todo - Change the logic to mask
                                Console.WriteLine(prop.Name + " - " + prop.Value);
                            }
                            //Console.WriteLine(prop.Name);
                        }
                        Console.WriteLine(prop.Name + " - " + prop.Value);
                        Console.ReadLine();
                        //JsonHelper.ObscureMatchingValues(prop.Name, jsonPaths);
                    }
                }
                
            }
            catch(Exception ex)
            {
                //Log Exception or write to Console
            }
          

        }

        public class AddressDetails
        {
            public string AddressLine1 { get; set; }
            //public List<MaskedJson> addresses { get; set; }

        }
        public static class ExampleLogger
        {
            public static void Log(string s)
            {
                // this would write to a file or SQL table
                Console.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - " + s);
            }
        }


    }

}

