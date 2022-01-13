namespace OpenGaming.Api.Adapters;

public static class OptionsExtensions
{
    public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string name = null)
        where TOptions : class, new()
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(TOptions).Name;

        var optionsConfig = configuration.GetSection(name);

        var options = new TOptions();
        optionsConfig.Bind(options);

        return options;
    }
}