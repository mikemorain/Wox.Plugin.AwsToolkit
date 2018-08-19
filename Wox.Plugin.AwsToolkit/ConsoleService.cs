using YamlDotNet.Serialization;

namespace Wox.Plugin.AwsToolkit
{
    public class ConsoleService
    {
        [YamlMember(Alias = "command", ApplyNamingConventions = false)]
        public string Title { get; set;  }
        public string Url { get; set; }
        [YamlMember(Alias = "description", ApplyNamingConventions = false)]
        public string Subtitle { get; set; }
    }
}
