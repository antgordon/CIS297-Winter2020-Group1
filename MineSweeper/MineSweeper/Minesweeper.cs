using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Minesweeper
    {

        public int flagCount { get; set; }
        public int bombTracker { get; set; }

        public GridEntity[,] gridEntity;

        public Minesweeper(GridDefinition gridDefinition)
        {
            gridEntity = new GridEntity[gridDefinition.width, gridDefinition.height];

        }

    }
}
