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
        private static Surface m_video;

        private static Grid m_grid;

        private static float m_elapsed;

        private static float m_step = 0.02f;

        private static int m_x;

        private static int m_y;

        private static int m_width = 640;

        private static int m_height = 480;

        static void Main(string[] args)
        {
            m_video = Video.SetVideoMode(m_width, m_height, 32, false, false, false, true);

            m_grid = new Grid(64, 48);

            m_elapsed = 0;

            m_x = m_width / m_grid.Data.GetLength(0);

            m_y = m_height / m_grid.Data.GetLength(1);

            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);

            Events.Tick += new EventHandler<TickEventArgs>(ApplicationTickEventHandler);

            Events.Run();
        }

        private static void ApplicationTickEventHandler(object sender, TickEventArgs args)
        {
            m_elapsed += args.SecondsElapsed;
            if (m_elapsed > m_step)
            {
                m_grid.Step();
                m_elapsed -= m_step;
            }
            for (int y = 0; y < m_grid.Data.GetLength(1); y++)
            {
                for (int x = 0; x < m_grid.Data.GetLength(0); x++)
                {
                    int xa = x * m_x;
                    int xb = (x * m_x) + m_x;
                    int ya = y * m_y;
                    int yb = (y * m_y) + m_y;
                    if (m_grid.Data[x, y] == State.Red)
                    {
                        m_video.Draw(new SdlDotNet.Graphics.Primitives.Box(new Point(xa, ya), new Point(xb, yb)), Color.Red, false, true);
                    }
                    else
                    {
                        m_video.Draw(new SdlDotNet.Graphics.Primitives.Box(new Point(xa, ya), new Point(xb, yb)), Color.White, false, true);
                    }
                }
            }
            m_video.Update();
        }

        private static void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }
    }
}
