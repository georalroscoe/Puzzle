using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mush
{
    
    public class Move
    {
        public Move(
            int level, char direction, int position)
        {
            Level = level;
            Direction = direction;
            Position = position;
        }

        public int Level { get; set; }
        public char Direction { get; set; }
        public int Position { get; set; }
    }
}

