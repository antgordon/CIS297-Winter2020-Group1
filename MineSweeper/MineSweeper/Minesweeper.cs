using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    class Minesweeper
    {

        //public int flagCount { get; set; }
        public int bombTracker { get; set; }
        public int numberOfNonBombSpots { get; set; }
        public int numberOfRevealedSpots { get; set; }
        public bool bombTriggered { get; set; }
        public bool gameOver { get; set; }

        public bool isWinner { get; set; }
        public DateTime StartTime { get; }

        public int Duration { get
            {
                TimeSpan span = DateTime.Now - StartTime;
                return (int)span.TotalSeconds;
            }
            
         }


        public GridDefinition Definition { get; }
        public GridEntity[,] gridEntity { get; set; }

        public GameNotifier Notifier { get;  }

        public Minesweeper(GridDefinition gridDefinition)
        {
            gridEntity = new GridEntity[gridDefinition.width, gridDefinition.height];
            Definition = gridDefinition;
            for (int x = 0; x < gridDefinition.width; x += 1) {
                for (int y = 0; y < gridDefinition.height; y += 1) {
                    gridEntity[x, y] = new GridEntity();
                }
            }

            fillBombs();
            numberOfNonBombSpots = (gridDefinition.height * gridDefinition.width) - gridDefinition.numOfBomb;
            numberOfRevealedSpots = 0;
            bombTriggered = false;
            gameOver = false;
            isWinner = false;
            StartTime = DateTime.Now;
            Notifier = new NotifierImp(this);
           
        }

        public void fillBombs()
        {
            Random rand = new Random();
            int randomY;
            int randomX;

            for (int bombNum = 0; bombNum < Definition.numOfBomb;)
            {
                randomX = rand.Next(0, Definition.width);
                randomY = rand.Next(0, Definition.height);

                if (gridEntity[randomX, randomY].value != -1) //if spot is not already a bomb
                {
                    gridEntity[randomX, randomY].value = -1;
                    updateAdjacentSpaces(randomX, randomY);
                    bombNum++;
                }
            }


        }

        public void updateAdjacentSpaces(int positionX, int positionY)
        {
            //From https://stackoverflow.com/questions/12471463/find-adjacent-elements-in-a-2d-matrix by Matthew Strawbridge
            for (int row = positionX - 1; row <= positionX + 1; row++)
            {
                for (int column = positionY - 1; column <= positionY + 1; column++)
                {
                    if (row >= 0 && column >= 0 && row < Definition.width && column < Definition.height && !(row == positionX && column == positionY))
                    {
                        if (gridEntity[row, column].value != -1) //if it is not a bomb
                        {
                            gridEntity[row, column].value++;
                        }
                    }
                }
            }
        }

        public void revealSpaces(int positionX, int positionY)
        {
            if (gridEntity[positionX, positionY].positionRevealed == true || gridEntity[positionX, positionY].questionSet || gridEntity[positionX, positionY].flagSet) //position is already revealed
            {
                return;
            }
            else if (gridEntity[positionX, positionY].isBomb) //If bomb, trigger game over
            {
                gridEntity[positionX, positionY].positionRevealed = true; //reveal only 1 spot
                numberOfRevealedSpots++;
                bombTriggered = true;
                IsGameOver();
                return;
            }
            else if (gridEntity[positionX, positionY].value != 0) //If it is not empty or a bomb
            {
                gridEntity[positionX, positionY].positionRevealed = true; //reveal only 1 spot
                numberOfRevealedSpots++;

                return;
            }
            else  //If empty, reveal itself and adjacent numbered/empty spaces.
            {
                gridEntity[positionX, positionY].positionRevealed = true;
                numberOfRevealedSpots++;

                for (int row = positionX - 1; row <= positionX + 1; row++)
                {
                    for (int column = positionY - 1; column <= positionY + 1; column++)
                    {
                        if (row >= 0 && column >= 0 && row < Definition.width && column < Definition.height && !(row == positionX && column == positionY))
                        {
                            revealSpaces( row, column);

                        }
                    }
                }

             
            }
            

        }

        public int GetFlagCount()
        {
            int counter = 0; 

            for (int row = 0; row < Definition.width; row++)
            {
                for (int column = 0; column < Definition.height; column++)
                {
                    if (gridEntity[row, column].flagSet)
                    {
                        counter++;
                    }

                }
            }

            return counter;
        }

        public void IsGameOver()
        {
            if (gameOver)
            {
                return;
            }

            if (numberOfRevealedSpots == numberOfNonBombSpots)
            {
                isWinner = true;
                gameOver = true;
            }
            else if (bombTriggered)
            {
                gameOver = true;
                isWinner = false;
                Notifier.RaiseBombClick(0, 0, false);
            }

        }


        private class NotifierImp : GameNotifier { 
            private Minesweeper game;

            public NotifierImp(Minesweeper game) {
                this.game = game;
            }

            public override void OnClick(int x, int y)
            {

                GridEntity entity = game.gridEntity[x,y];
                 if (!entity.positionRevealed)
                {
                    game.revealSpaces(x, y);


                }
                else {
                
                }
            }

            public override void OnRightClick(int x, int y)
            {
                GridEntity entity = game.gridEntity[x, y];

                entity.cycleState();
            }
        }


    }
}
