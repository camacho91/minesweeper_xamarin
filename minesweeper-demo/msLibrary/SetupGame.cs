using msLibrary.setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static msLibrary.setup.GameVariables;

namespace msLibrary
{
    /// <summary>
    /// Main class for game setup
    /// </summary>
    public class SetupGame
    {

        #region Methods

        /// <summary>
        /// Loads all the setup for the game to play acording to the parameter
        /// </summary>
        /// <param name="SelectedMode"></param>
        /// <returns>Game setup</returns>
        public static GameSetting LoadGameSetup(string SelectedMode)
        {
            #region variables
            //Validate the Selected game mode
            GameplayMode _selectedMode = ValidateGameMode(SelectedMode);

            
            //Settings to be returned in LoadGame Method
            GameSettingObj = new GameSetting();
            #endregion

            //Load Gamemode settings
            switch (_selectedMode)
            {
                case GameplayMode.easy:
                    GameSettingObj.xAxis = EasyModeSettings.xAmount;
                    GameSettingObj.yAxis = EasyModeSettings.yAmount;
                    GameSettingObj.mines = EasyModeSettings.mineAmount;
                    break;
                default:
                    throw new Exception("Error");
            }

            return GameSettingObj;
        }
        
        /// <summary>
        /// Validate Game mode against the enum
        /// </summary>
        /// <param name="selectedMode"></param>
        /// <returns>String for game mode</returns>
        private static GameplayMode ValidateGameMode(string selectedMode)
        {
            GameplayMode recordType = new GameplayMode();
            
            recordType = (GameplayMode)System.Enum.Parse(typeof(GameplayMode), selectedMode);
            
            return recordType;
        }
        
        #endregion
    }
}
