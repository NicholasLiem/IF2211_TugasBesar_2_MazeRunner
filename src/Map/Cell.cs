using System;

namespace src
{
    public class Cell
    {
        private int _row, _col, _type, _visitedCount;
        private bool _visited;

        public Cell(int row, int col, int type)
        {
            _row = row;
            _col = col;
            _type = type;
            _visited = false;
        }

        public int getVisitedCount()
        {
            return _visitedCount;
        }

        public void setVisitedCount(int visitedCount)
        {
            _visitedCount = visitedCount;
        }

        public void addVisitedCount()
        {
            _visitedCount++;
        }

        public int getRow()
        {
            return _row;
        }

        public void setRow(int row)
        {
            _row = row;
        }

        public int getCol()
        {
            return _col;
        }

        public void setCol(int col)
        {
            _col = col;
        }

        public bool isVisited()
        {
            return _visited;
        }

        public void setVisited(bool visited)
        {
            _visited = visited;
        }

        public int getType()
        {
            return _type;
        }

        public void setType(int type)
        {
            _type = type;
        }

        public bool isEqual(ref Cell other)
        {
            return _row == other.getRow() && _col == other.getCol() && _type == other.getType();
        }

        public void printCell()
        {
            int Row = _row;
            int Col = _col;
            int Type = _type;
            String Visited = _visited.ToString();
            String typePrint = "";
            switch (Type)
            {
                case 0:
                    typePrint = "Titik Awal";
                    break;
                case 1:
                    typePrint = "Path";
                    break;
                case 3:
                    typePrint = "Block";
                    break;
                case 9:
                    typePrint = "Treasure";
                    break;
                default:
                    typePrint = "Unknown?";
                    break;
            }
            Console.WriteLine("[" + Row + "," + Col + "]" + " T: " + typePrint + ", " +  "VC: " + _visitedCount + "");
        }
    }
}