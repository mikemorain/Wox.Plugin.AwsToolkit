using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Wox.Plugin.AwsToolkit
{
    public class Main: IPlugin
    {
        private List<ConsoleService> _services;
        private string _pluginDirectory;
        
        public List<Result> Query(Query query)
        {
            var results = new List<Result>();
            if (string.IsNullOrEmpty(query.Search)) return results;
            var keyword = query.Search;

            var searchList = _services.Where(x => x.Title.ToLower().Contains(keyword));
            foreach (var s in searchList)
            {
                var r = new Result();
                r.Title = s.Title;
                r.SubTitle = s.Subtitle;
                r.IcoPath = $"{_pluginDirectory}\\images\\{s.Title}.png";
                r.Action = c =>
                {
                    try
                    {
                        Process.Start(s.Url);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                };
                r.ContextData = s;
                results.Add(r);
            }

            return results;
        }

        public void Init(PluginInitContext context)
        {
            // 
            _pluginDirectory = context.CurrentPluginMetadata.PluginDirectory;
            // read in the yaml
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();
            using (Stream stream = File.OpenRead($"{_pluginDirectory}\\console-services.yml"))
            {
                using (TextReader reader = new StreamReader(stream))
                {
                    _services = deserializer.Deserialize<List<ConsoleService>>(reader);
                }

            }
        }
    }
}