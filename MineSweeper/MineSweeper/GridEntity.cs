namespace MineSweeper
{
    public class GridEntity
    {
        public int value { get; set; }
        public bool flagSet { get; set; }
        public bool questionSet { get; set; }
        public bool positionRevealed { get; set; }

        public GridEntity()
        {
            value = 0;
            flagSet = false;
            questionSet = false;
            positionRevealed = false;
        }

    }
}