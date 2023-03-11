using System.IO;

namespace AndroCtrl;

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
    public static string ConfigPath => Path.Join(ProcessDirectory, "app.json");

    static internal Config Settings { get; set; }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Settings = new(ConfigPath);

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
}