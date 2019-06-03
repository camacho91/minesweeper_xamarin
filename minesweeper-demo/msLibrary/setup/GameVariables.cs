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
            public int xCoord;
            public int yCoord;

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

        }


    }
}
