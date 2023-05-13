namespace EnvStartup;
public class EnvConfig
{
    public EnvConfig() { }
    public EnvConfig(string dir)
    {
        var projectName = $@"D:/{dir.Split("/").Last()}";
        ProjectDirectory = dir;
        ProjectLogDirectory = $@"D:/{projectName}Info";
        ProjectLogDirectory = $@"D:/{projectName}Log";
    }
    public string ProjectDirectory { get; set; }
    public string ProjectInfoDirectory { get; set; }
    public string ProjectLogDirectory { get; set; }
    public string ServerEnvironment { get; set; } = "prod";
}
