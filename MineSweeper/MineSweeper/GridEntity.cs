namespace MineSweeper
{
    public class GridEntity
    {
        public int count { get; set; }
        bool flagSet { get; set; }
        bool questionSet { get; set; }
        bool positionRevealed { get; set; }

        public GridEntity()
        {
            count = 0;
            flagSet = false;
            questionSet = false;
            positionRevealed = false;
        }
    }
}