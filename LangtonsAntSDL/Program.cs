using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Graphics;
using SdlDotNet.Core;

namespace LangtonsAntSDL
{
    class Program
    {
        static void Main(string[] args)
        {
            Video.SetVideoMode(320, 240, 32, false, false, false, true);

            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);

            Events.Run();
        }

        private static void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }
    }
}
