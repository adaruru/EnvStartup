using System.Text.Json;

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

        if (File.Exists(configPath))
        {
            //todo: read file and execute
        }
        else
        {
            //todo: create file and set default value
            File.Create(configPath);
            var env = new EnvConfig(dir);
            var json = JsonSerializer.Serialize(env);
            File.WriteAllText(configPath, json);
        }
    }
}
