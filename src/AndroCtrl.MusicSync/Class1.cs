using System.Windows.Forms;

using AndroCtrl.Plugin;

namespace AndroCtrl.MusicSync;

public class MusicSync : ICommand
{
    public string Name => "Music Sync";

    public string Description => "Sync Musics between your phone and Computer.";

    public int Execute()
    {
        MessageBox.Show("soon.");
        return 1;
    }
}