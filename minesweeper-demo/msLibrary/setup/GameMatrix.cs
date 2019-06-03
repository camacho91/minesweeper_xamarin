using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static msLibrary.setup.GameVariables;

namespace msLibrary.setup
{
    public class GameMatrix
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int MineCount { get; set; }
        public List<Cells> ListCells { get; set; }
        public GameMatrix(int width, int height, int mines)
        {
            Width = width;
            Height = height;
            MineCount = mines;
            ListCells = new List<Cells>();

            for (int i = 1; i <= height; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    ListCells.Add(new Cells(j, i));
                }
            }

        }

        public List<Cells> GetAdjacentCells(int x, int y)
        {
            return GetAdjacentCells(x, y, 1);
        }

        public List<Cells> GetAdjacentCells(int x, int y, int depth)
        {
            var AdjacentCells = ListCells.Where(cell => cell.xCoord >= (x - depth) && cell.xCoord <= (x + depth) && cell.yCoord >= (y - depth) && cell.yCoord <= (y + depth));
            var currentCell = ListCells.Where(cell => cell.xCoord == x && cell.yCoord == y);

            return AdjacentCells.Except(currentCell).ToList();
        }

        /// <summary>
        /// Initial Setup for the game
        /// </summary>
        /// <param name="rand"></param>
        public void InitialSetup(Random rand)
        {
            //List is reordered randomly
            var listRandom = ListCells.OrderBy(x => rand.Next());

            //The first records(Equivalent to the amount of mines) are stored in the collection
            var mineCells = listRandom.Take(MineCount).ToList().Select(z => new { z.xCoord, z.yCoord });

            //Set the ContainsMine property to true to the records that match de mineCells collection
            foreach (var mineCoord in mineCells)
            {
                ListCells.Single(panel => panel.xCoord == mineCoord.xCoord && panel.yCoord == mineCoord.yCoord).containsMine = true;
                
            }

            //Determine if the adjacent mines are safe
            foreach (var safeCell in ListCells.Where(panel => !panel.containsMine))
            {
                var adjacentCells = GetAdjacentCells(safeCell.xCoord, safeCell.yCoord);

                //Sets the number to be shown when the cell is pressed
                safeCell.showNumber = adjacentCells.Count(z => z.containsMine);
            }
        }

        /// <summary>
        /// Main method to flip cell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void FlipCell(int x, int y)
        {
            //Get the current cell position
            var CurrentPanel = ListCells.First(panel => panel.xCoord == x && panel.yCoord == y);

            //Set the current cell as flipped
            CurrentPanel.isFlipped = true;


            //If the number to show is 0 and does not contain mine, then its a blank space
            if (CurrentPanel.showNumber == 0 && !CurrentPanel.containsMine)
            {
                RevealBlank(x, y);
            }



        }


        //Turn Cells with 0 mines around to blank spaces
        public void RevealBlank(int x, int y)
        {
            var AdjacentCells = GetAdjacentCells(x, y).Where(panel => !panel.isFlipped);

            //Turn all adjacent cells as blank if the condition is compatible
            foreach (var cell in AdjacentCells)
            {
                cell.isFlipped = true;

                if (cell.showNumber == 0)
                {
                    RevealBlank(cell.xCoord, cell.yCoord);
                }
            }
        }

        public void RevealMines()
        {
            //Determine if the adjacent mines are mines
            foreach (var mineCell in ListCells.Where(panel => panel.containsMine))
            {
                var adjacentCells = GetAdjacentCells(mineCell.xCoord, mineCell.yCoord);


                //Flips the mine cell
                mineCell.isFlipped = true;
            }
        }


    }
}
