using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Wox.Plugin.AwsToolkit
{
    public class AwsConsoleServicesPlugin : IPlugin
    {
        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            
            results.Add();
            throw new NotImplementedException();
        }

        public void Init(PluginInitContext context)
        {
            // read in the yaml
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            using (Stream stream = File.OpenRead("console-services.yml"))
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    var services = deserializer.Deserialize<List<ConsoleService>>(reader);
                    foreach (var s in services)
                    {
                        Console.WriteLine(s.Title);
                    }
                }

            }
            
            // 
            throw new NotImplementedException();
        }
    }
}