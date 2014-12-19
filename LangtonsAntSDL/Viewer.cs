using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LangtonsAntLibrary;
using SdlDotNet.Core;
using SdlDotNet.Graphics;

namespace LangtonsAntSDL
{
    public class Viewer
    {
        private Surface m_video;

        private Grid m_grid;

        private float m_elapsed;

        private float m_step = 0.02f;

        private int m_xScale;

        private int m_yScale;

        private int m_width;

        private int m_height;

        public Viewer(int gridWidth, int gridHeight, int scale, float step)
        {
            m_grid = new Grid(gridWidth, gridHeight);
            m_xScale = scale;
            m_yScale = scale;
            m_width = gridWidth*m_xScale;
            m_height = gridHeight*m_yScale;
        }

        public void Run()
        {
            m_elapsed = 0;
            m_video = Video.SetVideoMode(m_width, m_height, 32, false, false, false, true);
            Events.Quit += new EventHandler<QuitEventArgs>(ApplicationQuitEventHandler);
            Events.Tick += new EventHandler<TickEventArgs>(ApplicationTickEventHandler);
            Events.Run();
        }

        private void ApplicationTickEventHandler(object sender, TickEventArgs args)
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
                    int xa = x * m_xScale;
                    int xb = (x * m_xScale) + m_xScale;
                    int ya = y * m_yScale;
                    int yb = (y * m_yScale) + m_yScale;
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

        private void ApplicationQuitEventHandler(object sender, QuitEventArgs args)
        {
            Events.QuitApplication();
        }
    }
}
