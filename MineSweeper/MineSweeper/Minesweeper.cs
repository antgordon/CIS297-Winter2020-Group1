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

        public GridEntity[,] gridEntity { get; set; }

        public Minesweeper(GridDefinition gridDefinition)
        {
            gridEntity = new GridEntity[gridDefinition.width, gridDefinition.height];

        }

        public void fillBombs(GridDefinition gridDefinition, GridEntity[,] gridEntity)
        {
            Random rand = new Random();
            int randomY;
            int randomX;

            for (int bombNum = 0; bombNum < gridDefinition.numOfBomb; bombNum++)
            {
                randomX = rand.Next(0, gridDefinition.width);
                randomY = rand.Next(0, gridDefinition.height);

                if (gridEntity[randomX, randomY].value != -1)
                {
                    gridEntity[randomX, randomY].value = -1;
                    bombNum++;
                }
            }


        }

    }
}
