using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPTeam.AndroCtrl;

internal class AppliationSettings
{
    public List<string> IPAddresses { get; set; } = new();
    public List<string> SearchPaths { get; set; } = new();
}
