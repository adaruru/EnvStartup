using Newtonsoft.Json;
using Microsoft.Web.Administration;

namespace EnvStartup;
internal class Program
{
    static void Main(string[] args)
    {
        var dir = args[0];
        var configName = "EnvConfig.json";
        var configPath = Path.Combine(dir, configName);
        var env = new EnvConfig(dir);

        if (!Directory.Exists(dir))
        {
            Console.WriteLine($"no such directory: {dir}");
            return;
        }

        if (!File.Exists(configPath))
        {
            var defaultJson = JsonConvert.SerializeObject(env, Formatting.Indented);
            File.WriteAllText(configPath, defaultJson);
        }
        var json = File.ReadAllText(configPath);
        env = JsonConvert.DeserializeObject<EnvConfig>(json);

        if (!Directory.Exists(env.ProjectInfoDirectory))
        {
            Directory.CreateDirectory(env.ProjectInfoDirectory);
        }
        if (!Directory.Exists(env.ProjectLogDirectory))
        {
            Directory.CreateDirectory(env.ProjectLogDirectory);
        }

        var appUser = Enum.GetNames(typeof(ProcessModelIdentityType)).ToList().FirstOrDefault(a => a == env.AppUser);
        if (appUser == null)
        {
            Console.WriteLine($"user {env.AppUser} not found");
            return;
        }
        else
        {
            //iis app user to asigned user
            using (ServerManager serverManager = new ServerManager())
            {
                ApplicationPool pool = serverManager.ApplicationPools[env.ProjectName];
                pool.ProcessModel.IdentityType = (ProcessModelIdentityType)Enum.Parse(typeof(ProcessModelIdentityType), env.AppUser);
                serverManager.CommitChanges();
            }

            //directories info and log authority open asigned user

        }
        Console.ReadLine();
    }
}
