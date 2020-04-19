namespace MineSweeper
{
    public class GridEntity
    {
        public int value { get; set; }
        public bool flagSet { get; set; }
        public bool questionSet { get; set; }
        public bool positionRevealed { get; set; }
        public bool blankSet { get; set; }


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