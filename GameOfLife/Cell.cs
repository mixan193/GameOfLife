namespace GameOfLife
{
    internal class Cell
    {
        private Cell[] neighbours = new Cell[8];
        public Cell[] Neighbours
        {
            get
            {
                return neighbours;
            }
            set
            {
                neighbours = value;
            }
        }
        private int activeNeighbours = 0;
        private bool isEnabled = false;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
            }
        }
        private bool isEnabledInNextGeneration = false;
        public bool IsEnabledInNextGeneration
        {
            get
            {
                return isEnabledInNextGeneration;
            }
            set
            {
                isEnabledInNextGeneration = value;
            }
        }
        private int x;
        private int y;
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool ComputeBehaviorInNextGeneration()
        {
            activeNeighbours = 0;
            foreach (Cell cell in neighbours)
            {
                if (cell.IsEnabled)
                {
                    activeNeighbours++;
                }
            }
            if (!IsEnabled)
            {
                if(activeNeighbours == 3)
                {
                    IsEnabledInNextGeneration = true;
                }
            }
            else
            {
                if(activeNeighbours > 3 || activeNeighbours < 2)
                {
                    IsEnabledInNextGeneration= false;
                }
                else
                {
                    IsEnabledInNextGeneration = true;
                }
            }
            return isEnabledInNextGeneration;
        }


    }
}
