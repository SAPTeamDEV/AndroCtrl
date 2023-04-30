using SAPTeam.CommonTK;

namespace SAPTeam.AndroCtrl;

internal static class Program
{
    /// <summary>
    /// Gets Path of Application.
    /// </summary>
    public static string ProcessPath => Environment.ProcessPath;

    /// <summary>
    /// Gets Directory of Application.
    /// </summary>
    public static string ProcessDirectory => Directory.GetParent(ProcessPath).ToString();

    /// <summary>
    /// Gets Path of Application Config file.
    /// </summary>
    public static string ConfigPath => Path.Join(ProcessDirectory, "config.json");

    /// <summary>
    /// Gets Application's settings writer.
    /// </summary>
    static internal Config<AppliationSettings> Config { get; private set; }

    /// <summary>
    /// Gets Application settings.
    /// </summary>
    static internal AppliationSettings Settings { get; private set; }

    /// <summary>
    /// Gets all supposed search path for finding requirements.
    /// </summary>
    public static List<string> SearchPaths { get; } = new()
    {
        "",
        "bin",
        @"C:\Windows",
        @"C:\Windows\system32",
        @"C:\Windows\adb"
    };

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Config = new(ConfigPath);
        Settings = Config.Prefs;

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
}