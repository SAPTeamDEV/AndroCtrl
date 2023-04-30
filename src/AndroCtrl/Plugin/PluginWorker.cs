using System.Reflection;

namespace SAPTeam.AndroCtrl.Plugin;

internal class PluginWorker
{
    internal static void LoadPlugins()
    {
        if (!Directory.Exists(Path.Join(AppContext.BaseDirectory, "Plugins")))
        {
            Directory.CreateDirectory(Path.Join(AppContext.BaseDirectory, "Plugins"));
        }

        IEnumerable<ICommand> commands = Directory.EnumerateFiles(Path.Join(AppContext.BaseDirectory, "Plugins"), "*.dll").SelectMany(pluginPath =>
        {
            Assembly pluginAssembly = LoadPlugin(pluginPath);
            return CreateCommands(pluginAssembly);
        }).ToList();

        foreach (ICommand command in commands)
        {
            command.Execute();
        }
    }

    private static Assembly LoadPlugin(string pluginLocation)
    {
        PluginLoadContext loadContext = new(pluginLocation);
        return loadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(pluginLocation));
    }

    private static IEnumerable<ICommand> CreateCommands(Assembly assembly)
    {
        int count = 0;

        foreach (Type type in assembly.GetTypes())
        {
            if (typeof(ICommand).IsAssignableFrom(type))
            {
                if (Activator.CreateInstance(type) is ICommand result)
                {
                    count++;
                    yield return result;
                }
            }
        }

        if (count == 0)
        {
            string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
            throw new ApplicationException(
                $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                $"Available types: {availableTypes}");
        }
    }
}
