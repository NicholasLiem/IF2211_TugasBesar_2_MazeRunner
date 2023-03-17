using System;

namespace src{
    public class Cell{
        public int Row{
            get; set;
        }
        public int Col{
            get; set;
        }
        public bool Visited{
            get; set;
        }
        public int Type{
            get; set;
        }
    }
}