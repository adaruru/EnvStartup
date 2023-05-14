using Newtonsoft.Json;

namespace EnvStartup;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        var dir = args[0];
        var configName = "EnvConfig.json";
        var configPath = Path.Combine(dir, configName);

        if (!Directory.Exists(dir))
        {
            Console.WriteLine($"no such directory: {dir}");
            return;
        }

        if (!File.Exists(configPath))
        {
            //todo: create file and set default value
            var env = new EnvConfig(dir);
            var json = JsonConvert.SerializeObject(env, Formatting.Indented);
            File.WriteAllText(configPath, json);
        }
    }
}
