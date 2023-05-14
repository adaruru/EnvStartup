namespace EnvStartup;
public class EnvConfig
{
    public EnvConfig() { }
    public EnvConfig(string dir)
    {
        var root = "D:\\";
        ProjectName = $@"{dir.Split("\\").Last()}";
        ProjectDirectory = dir;
        ProjectInfoDirectory = $"{root}{ProjectName}Info";
        ProjectLogDirectory = $"{root}{ProjectName}Log";
    }
    public string ProjectName { get; set; }
    public string ServerEnvironment { get; set; } = "prodction";
    public string ProjectDirectory { get; set; }
    public string ProjectInfoDirectory { get; set; }
    public string ProjectLogDirectory { get; set; }
    public string AppUser { get; set; }
}
