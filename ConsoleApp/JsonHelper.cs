using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static ConsoleApp.Model.SampleJson;

namespace ConsoleApp
{
	//Helper Class to Mask the desired properties
    public static class JsonHelper
    {
		//public static void ObscureMatchingValues(JToken token, IEnumerable<string> jsonPaths)
			public static void ObscureMatchingValues(JToken token, JToken jsonPaths)
		{
			foreach (string path in jsonPaths)
			{
				foreach (JToken match in token.SelectTokens(path))
				{
					match.Replace(new JValue(Obscure(match.ToString())));
				}
			}
		}
		public static string Obscure(string s)
		{
			if (string.IsNullOrEmpty(s)) return s;

			int len = s.Length;
			int leftLen = len > 4 ? 1 : 0;
			int rightLen = len > 6 ? Math.Min((len - 6) / 2, 4) : 0;
			return s.Substring(0, leftLen) +
				new string('*', len - leftLen - rightLen) +
				s.Substring(len - rightLen);
		}

        internal static void ObscureMatchingValues(JToken token, string[] jsonPaths)
        {
			foreach (string path in jsonPaths)
			{
				foreach (JToken match in token.SelectTokens(path))
				{
					match.Replace(new JValue(Obscure(match.ToString())));
				}
			}
		}
    }
	public static class ExampleConfigSettings
	{
        public static string[] GetJsonPathsToObscure()
        {
			// read the paths from a config file
			//var builder = new ConfigurationBuilder()
			//	.SetBasePath(Directory.GetCurrentDirectory())
			//	.AddJsonFile("appsettings.json");

			//var configuration = builder.Build();
			//string MaskedJson = configuration["MaskedJson"];

			
			//return new maskDataElements();
            return new string[] { "$..AddressDetails", "$..AddressLine2" };

		}
    }
}
