namespace AndroCtrl.Plugin;

public interface ICommand
{
    string Name { get; }
    string Description { get; }

    int Execute();
}
