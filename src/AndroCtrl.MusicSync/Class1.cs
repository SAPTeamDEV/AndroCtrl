using System.Windows.Forms;

using SAPTeam.AndroCtrl.Plugin;

namespace SAPTeam.AndroCtrl.MusicSync;

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