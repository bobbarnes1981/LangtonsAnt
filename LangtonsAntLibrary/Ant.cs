using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangtonsAntLibrary
{
    public class Ant
    {
        private Dictionary<State, Dictionary<Direction, Direction>> m_stateDictionary = new Dictionary<State,Dictionary<Direction,Direction>>
        {
            {State.Red, new Dictionary<Direction, Direction>
            {
                {Direction.North, Direction.West},
                {Direction.East, Direction.North},
                {Direction.South, Direction.East},
                {Direction.West, Direction.South},
            }},
            {State.White, new Dictionary<Direction, Direction>
            {
                {Direction.North, Direction.East},
                {Direction.East, Direction.South},
                {Direction.South, Direction.West},
                {Direction.West, Direction.North},
            }},
        };

        private Direction m_currentDirection;

        public int X { get; set; }

        public int Y { get; set; }

        public Ant(Direction startingDirection)
        {
            m_currentDirection = startingDirection;
        }

        public Direction Step(State state)
        {
            m_currentDirection = m_stateDictionary[state][m_currentDirection];
            return m_currentDirection;
        }
    }
}
