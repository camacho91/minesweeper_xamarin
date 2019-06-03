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
            public bool ContainsFlag { get; internal set; }

            public Cells(int _xCoord, int _yCoord)
            {
                xCoord = _xCoord;
                yCoord = _yCoord;
            }

        }

        


    }
}
