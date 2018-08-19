using System;

namespace Wox.Plugin.AwsToolkit.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var plugin = new Main();
            plugin.Init(null);

            var r = plugin.Query(new Query());

            foreach (var result in r)
            {
                Console.WriteLine(result.Title);
            }
        }
    }
}