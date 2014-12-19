using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using LangtonsAntLibrary;

namespace LangtonsAntSDL
{
    public class Program
    {

        static void Main(string[] args)
        {
            new Viewer(128, 96, 5, 0.1f).Run();
        }
    }
}
