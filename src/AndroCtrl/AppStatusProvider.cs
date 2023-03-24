using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SAPTeam.CommonTK;

namespace AndroCtrl
{
    public class AppStatusProvider : IProgressStatusProvider, IMultiStatusProvider
    {
        readonly StatusStrip statusbar;
        ToolStripProgressBar progressbar;

        bool gc;

        readonly Dictionary<string, (ToolStripLabel label, ToolStripProgressBar progressBar)> packets = new();

        public AppStatusProvider(StatusStrip statusbar, bool garbageCollection = true)
        {
            this.statusbar = statusbar;
            gc = garbageCollection;
        }

        public void Clear()
        {
            if (statusbar.Items.Count > 0)
            {
                foreach (var packet in packets)
                {
                    if (packet.Value.progressBar != progressbar)
                    {
                        Clear(packet.Key);
                    }
                }

                if (progressbar != null)
                {
                    throw new InvalidOperationException("Can't remove an unfinished progress bar.");
                }
            }
        }

        public void Clear(string message)
        {
            if (packets[message].progressBar == progressbar)
            {
                progressbar = null;
            }

            statusbar.Items.Remove(packets[message].label);
            statusbar.Items.Remove(packets[message].progressBar);
            packets.Remove(message);
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void Write(string message, ProgressBarType type)
        {
            if (progressbar != null && type == ProgressBarType.Block)
            {
                throw new InvalidOperationException("Can't register more than one block progress bar.");
            }
            if (packets.ContainsKey(message))
            {
                throw new ArgumentException("Can't use a duplicated status message: ", message);
            }

            ToolStripLabel label = new(message);
            statusbar.Items.Add(label);

            switch (type)
            {
                case ProgressBarType.None:
                    throw new ArgumentException("type can't be None.");
                case ProgressBarType.Wait:
                    ToolStripProgressBar loadingbar = new();
                    loadingbar.Style = ProgressBarStyle.Marquee;
                    statusbar.Items.Add(loadingbar);
                    packets[message] = (label, loadingbar);
                    break;
                case ProgressBarType.Block:
                    progressbar = new();
                    statusbar.Items.Add(progressbar);
                    packets[message] = (label, progressbar);
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

            if (gc && progressbar.Value >= 100)
            {
                Clear(packets.Where((x) => x.Value.progressBar == progressbar).First().Key);
            }
        }
    }
}
