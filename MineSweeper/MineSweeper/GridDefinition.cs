namespace MineSweeper
{
    public class GridDefinition
    {

        public int width { get; set; }
        public int height { get; set; }
        public int numOfBomb { get; set; }


        public GridDefinition(int width, int height, int numOfBombs)
        {
            this.width = width;
            this.height = height;
            this.numOfBomb = numOfBombs;
        }


    }
}