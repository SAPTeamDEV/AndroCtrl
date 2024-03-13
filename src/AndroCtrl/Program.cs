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
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Config = new(ConfigPath);
        Settings = Config.Prefs;
        AddDefaultSearchPaths();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }

    static void AddDefaultSearchPaths()
    {
        List<string> searchPaths = new List<string>()
        {
            "",
            "bin",
            @"C:\Windows",
            @"C:\Windows\system32",
            @"C:\Windows\adb"
        };

        foreach (string path in searchPaths)
        {
            if (!Settings.SearchPaths.Contains(path))
            {
                Settings.SearchPaths.Add(path);
            }
        }
    }
}