using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPTeam.CommonTK;

namespace AndroCtrl
{
    public class AppStatusProvider : IStatusProvider
    {
        StatusStrip statusbar;

        public AppStatusProvider(StatusStrip statusbar)
        {
            this.statusbar = statusbar;
        }

        public void Clear()
        {
            statusbar.Items.Clear();
        }

        public void Write(string message)
        {
            statusbar.Items.Add(message);
        }
    }
}
