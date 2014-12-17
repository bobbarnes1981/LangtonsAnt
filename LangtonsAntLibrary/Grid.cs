using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonsAntLibrary
{
    public class Grid
    {
        private Dictionary<State, State> m_stateDictionary = new Dictionary<State, State>
        {
            { State.Red, State.White},
            { State.White, State.Red},
        };

        private Ant m_ant;

        private State[,] m_data;

        private int m_width;

        private int m_height;

        public Grid(int width, int height)
        {
            m_width = width;
            m_height = height;
            m_data = new State[width, height];
            m_ant = new Ant(Direction.North);
        }

        public void Step()
        {
            // get new direction
            Direction d = m_ant.Step(m_data[m_ant.X, m_ant.Y]);
            // change grid state
            m_data[m_ant.X, m_ant.Y] = m_stateDictionary[m_data[m_ant.X, m_ant.Y]];
            // move ant
            switch(d)
            {
                case Direction.North:
                    m_ant.Y++;
                    break;
                case Direction.East:
                    m_ant.X++;
                    break;
                case Direction.South:
                    m_ant.Y--;
                    break;
                case Direction.West:
                    m_ant.X--;
                    break;
            }
            // wrap grid coordinates
            if (m_ant.Y == m_width)
            {
                m_ant.Y = 0;
            }
            if (m_ant.Y == -1)
            {
                m_ant.Y = m_width - 1;
            }
            if (m_ant.X == m_height)
            {
                m_ant.X = 0;
            }
            if (m_ant.X == -1)
            {
                m_ant.X = m_height - 1;
            }
        }

        public State[,] Data
        {
            get
            {
                return m_data;
            }
        }
    }
}
