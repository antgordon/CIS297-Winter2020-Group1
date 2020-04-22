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
            fillBombs(gridDefinition, gridEntity);
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

                if (gridEntity[randomX, randomY].value != -1) //if spot is not already a bomb
                {
                    gridEntity[randomX, randomY].value = -1;
                    updateAdjacentSpaces(gridDefinition, gridEntity, randomX, randomY);
                    bombNum++;
                }
            }


        }

        public void updateAdjacentSpaces(GridDefinition gridDefinition, GridEntity[,] gridEntity, int positionX, int positionY)
        {
            //From https://stackoverflow.com/questions/12471463/find-adjacent-elements-in-a-2d-matrix by Matthew Strawbridge
            for (int row = positionX - 1; row <= positionX + 1; row++)
            {
                for (int column = positionY - 1; column <= positionY + 1; column++)
                {
                    if (row >= 0 && column >= 0 && row < gridDefinition.width && column < gridDefinition.height && !(row == positionX && column == positionY))
                    {
                        if (gridEntity[row, column].value != -1) //if it is not a bomb
                        {
                            gridEntity[row, column].value++;
                        }
                    }    
                }
            }    
        }

        public void revealSpaces(GridDefinition gridDefinition, GridEntity[,] gridEntity, int positionX, int positionY)
        {
            if (gridEntity[positionX, positionY].value != 0 && gridEntity[positionX, positionY].value != -1) //If it is not empty or a bomb
            {
                gridEntity[positionX, positionY].positionRevealed = true; //reveal only 1
                return;
            }
            else if(gridEntity[positionX, positionY].value == -1) //If bomb, dont reveal
            {
                return;
            }
            else  //If empty, reveal itself and adjacent numbered/empty spaces.
            {
                gridEntity[positionX, positionY].positionRevealed = true;

                for (int row = positionX - 1; row <= positionX; row++)
                {
                    for (int column = positionY; column <= positionY; column++)
                    {
                        if (row >= 0 && column >= 0 && row < gridDefinition.width && column < gridDefinition.height && !(row == positionX && column == positionY))
                        {
                            revealSpaces(gridDefinition, gridEntity, row, column);

                        }
                    }
                }

                return;
            }
            
        }

        

    }
}
