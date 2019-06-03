using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msLibrary.setup
{
    public class GameVariables
    {
        /// <summary>
        /// Supported Game Modes
        /// </summary>
        public enum GameplayMode { easy }
        

        /// <summary>
        /// Static object for GameSetting
        /// </summary>
        public static GameSetting GameSettingObj { get; set; }
        
        /// <summary>
        /// Main attributes for a setting
        /// </summary>
        public class GameSetting
        {
            public int xAxis { get; set; }
            public int yAxis { get; set; }
            public int mines { get; set; }
        }


        /// <summary>
        /// Easy Mode Settings
        /// </summary>
        public static class EasyModeSettings
        {
            public const int xAmount = 9;
            public const int yAmount = 9;
            public const int mineAmount = 10;

        }



        public class Cells
        {
            public int xCoord { get; set; }
            public int yCoord { get; set; }
            public bool isFlipped { get; set; }
            public bool containsMine { get; set; }
            public int showNumber { get; set; }

            public Cells(int _xCoord, int _yCoord)
            {
                xCoord = _xCoord;
                yCoord = _yCoord;
            }

        }

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

        }


    }
}
