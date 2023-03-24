using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPTeam.CommonTK;

namespace AndroCtrl
{
    public class AppStatusProvider : IProgressStatusProvider
    {
        StatusStrip statusbar;
        ToolStripProgressBar progressbar;

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

        public void Write(string message, ProgressBarType type)
        {
            Write(message);

            switch (type)
            {
                case ProgressBarType.None:
                    throw new ArgumentException("type can't be None.");
                case ProgressBarType.Wait:
                    progressbar = new();
                    progressbar.Style = ProgressBarStyle.Marquee;
                    statusbar.Items.Add(progressbar);
                    break;
                case ProgressBarType.Block:
                    progressbar = new();
                    statusbar.Items.Add(progressbar);
                    break;
            }
        }

        public void Increment(int value)
        {
            if (value == -1)
            {
                progressbar.PerformStep();
            }
            else
            {
                progressbar.Increment(value);
            }
        }
    }
}
