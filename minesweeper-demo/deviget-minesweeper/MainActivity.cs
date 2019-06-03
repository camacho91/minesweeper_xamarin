using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using msLibrary;
using msLibrary.setup;
using System.Collections.Generic;
using System;

namespace deviget_minesweeper
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        #region Variables

        //GrigView container for the game board
        GridView gridGame;

        //Game Settings obj
        private GameVariables.GameSetting settings;

        //Object with game data
        public GameVariables.GameMatrix GameData { get; private set; }

        //Custom Adapter for Cell objects
        public static deviget_minesweeper.ClassAdapters.CustomCellAdapter objCell;

        #endregion


        #region methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Grid initialization
            gridGame = FindViewById<GridView>(Resource.Id.gridGame);

            //Object with game settings
            settings = SetupGame.LoadGameSetup("easy");

            //Max number of colums for the grid, equivalent to the horizontal spots
            gridGame.NumColumns = settings.xAxis;

            //All Game Data
            GameData = new GameVariables.GameMatrix(settings.xAxis, settings.yAxis, settings.mines);

            //List is sent to the Custom Adapter
            objCell = new deviget_minesweeper.ClassAdapters.CustomCellAdapter(GameData.ListCells, (AppCompatActivity)this);


            objCell.actionMenuSelected += ObjCell_actionMenuSelected;

            //Data populate to the GridView
            gridGame.Adapter = objCell;

            objCell.NotifyDataSetChanged();


        }

        
        /// <summary>
        /// Click event for cells
        /// </summary>
        /// <param name="arg1">X Coordinate</param>
        /// <param name="arg2">Y Coordinate</param>
        private void ObjCell_actionMenuSelected(int xCoord, int yCoord)
        {
            
        }
        #endregion



        #region Classes

       


            #endregion
        }
}