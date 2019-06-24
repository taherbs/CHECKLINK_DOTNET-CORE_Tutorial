using System;
using System.Linq;
using System.IO;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace checklinksconsole
{
    class Program
    {
        public class OutputSettings 
        {
            public string Folder { get; set; }
            public string File { get; set; }

            public string GetOutputFile()
            {
                return Path.Combine(Directory.GetCurrentDirectory(), Folder, File);
            }

            public string GetOutputDir()
            {
                return Path.GetDirectoryName(GetOutputFile());
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("\n### START EXEC ###\n");
            var inMemory = new Dictionary<string, string>
            {
                {"APP:SITE", "https://google.com"}, //you can create a sub sections to configuration
                {"OUTPUT:FOLDER", "reports"}, 
                {"OUTPUT:FILE", "report.txt"}
            };
            var configBuilder = new ConfigurationBuilder()
                                    .AddInMemoryCollection(inMemory)
                                    .AddEnvironmentVariables()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("checksettings.json", true)
                                    .AddCommandLine(args); //The Lat one is  the most poweful and will
            var config = configBuilder.Build();


            // create the report dir/file structure
            var output = new OutputSettings();
            config.GetSection("OUTPUT").Bind(output); //map the values of the outputsettings object to the config values

            Directory.CreateDirectory(output.GetOutputDir());

            var client = new HttpClient();
            var body = client.GetStringAsync(config["APP:SITE"]);

            Console.WriteLine("\nLinks:\n");
            var links = LinkChecker.GetLinks(body.Result);
            foreach (string link in links)
            {
                Console.Write($"{link}\n");
            }
            
            var checkedLinks = LinkChecker.CheckLinks(links);
            using (var file = File.CreateText(output.GetOutputFile()))
            {
                foreach (var link in checkedLinks.OrderBy(l => l.Exists))
                {
                    var status = link.IsMissing ? "missing" : "OK";
                    file.WriteLine($"{status} - {link.Link}");
                }
            }

            Console.WriteLine("\n### END EXEC ###\n");
	    }
    }
}
