namespace EnvStartup;
public class EnvConfig
{
    public EnvConfig() { }
    public EnvConfig(string dir)
    {
        var root = "D:\\";
        var projectName = $@"{dir.Split("\\").Last()}";
        ProjectDirectory = dir;
        ProjectInfoDirectory = $"{root}{projectName}Info";
        ProjectLogDirectory = $"{root}{projectName}Log";
    }
    public string ServerEnvironment { get; set; } = "prodction";
    public string ProjectDirectory { get; set; }
    public string ProjectInfoDirectory { get; set; }
    public string ProjectLogDirectory { get; set; }
}
