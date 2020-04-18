namespace MineSweeper
{
    public class GridEntity
    {
        public int value { get; set; }  //count of -1 means it is a bomb
        bool flagSet { get; set; }
        bool questionSet { get; set; }
        bool blankSet { get; set; }
        bool positionRevealed { get; set; }

        public GridEntity()
        {
            value = 0;
            flagSet = false;
            questionSet = false;
            blankSet = true;
            positionRevealed = false;
        }

        public void cycleState()
        {
            if(flagSet)
            {
                flagSet = false;
                questionSet = true;
            }
            else if(questionSet)
            {
                questionSet = false;
                blankSet = true;
            }
            else if(blankSet)
            {
                blankSet = false;
                flagSet = true;
            }
        }

        /*public void revealBox()
        {
            positionRevealed = true;
        }*/
    }
}