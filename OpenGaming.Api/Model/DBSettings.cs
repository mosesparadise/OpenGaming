namespace OpenGaming.Api.Model;

public class DbSettings
{
    public const string Section = "DBSettings";
    public string ConnectionString { get; set; } = string.Empty;
    public string ServerVersion { get; set; } = "auto";
    public int CommandTimeout { get; set; }
}