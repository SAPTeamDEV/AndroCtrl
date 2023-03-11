using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using SAPTeam.CommonTK;

namespace AndroCtrl;

internal class Config : JsonWorker
{
    public AppliationSettings Prefs;

    public Config(string configPath) : base(configPath)
    {
        if (!File.Exists(FileName))
        {
            Write(new AppliationSettings());
        }
        JObject cData = Open();
        Prefs = Parse<AppliationSettings>(cData.CreateReader());
    }

    public void Write()
    {
        Write(Prefs);
    }

    private void Write(AppliationSettings cObject)
    {
        StringWriter sw = new();
        JsonTextWriter jw = new(sw);
        ToJson(jw, cObject);
        Save(sw);
    }
}
