namespace AndroCtrl;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        Plugin.PluginWorker.LoadPlugins();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        new Dialogs.QRCodePair().ShowDialog();
    }
}