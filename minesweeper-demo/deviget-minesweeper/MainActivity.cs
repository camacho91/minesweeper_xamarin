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
        public GameMatrix GameData { get; private set; }

        //Custom Adapter for Cell objects
        public static deviget_minesweeper.ClassAdapters.CustomCellAdapter objCell;

        //Random object
        Random rand = new Random();

        //Button to reset game
        ImageView imgResetGame;
        #endregion


        #region methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Grid initialization
            gridGame = FindViewById<GridView>(Resource.Id.gridGame);

            //Imageview Initialization
            imgResetGame = FindViewById<ImageView>(Resource.Id.imgResetGame);

            //Object with game settings
            settings = SetupGame.LoadGameSetup("easy");

            //Max number of colums for the grid, equivalent to the horizontal spots
            gridGame.NumColumns = settings.xAxis;

            //All Game Data
            GameData = new GameMatrix(settings.xAxis, settings.yAxis, settings.mines);

            GameData.InitialSetup(rand);
            //List is sent to the Custom Adapter
            objCell = new deviget_minesweeper.ClassAdapters.CustomCellAdapter(GameData.ListCells, (AppCompatActivity)this);


            objCell.actionMenuSelected += ObjCell_actionMenuSelected;
            imgResetGame.Click += ImgResetGame_Click;

            //Data populate to the GridView
            gridGame.Adapter = objCell;

            objCell.NotifyDataSetChanged();


        }

        private void ImgResetGame_Click(object sender, EventArgs e)
        {
            GameData.ListCells.Clear();
            GameData = new GameMatrix(settings.xAxis, settings.yAxis, settings.mines);
            GameData.InitialSetup(rand);
            updateGameboard();
        }


        /// <summary>
        /// Click event for cells
        /// </summary>
        /// <param name="arg1">X Coordinate</param>
        /// <param name="arg2">Y Coordinate</param>
        private void ObjCell_actionMenuSelected(int xCoord, int yCoord, bool isMine)
        {
            
            if (isMine)
            {
                GameData.RevealMines();
            }
            else
            {
                GameData.FlipCell(xCoord, yCoord);
            }


            updateGameboard();


        }

        /// <summary>
        /// Refresh the Game data
        /// </summary>
        public void updateGameboard()
        {
            gridGame.Adapter = null;
            objCell = new deviget_minesweeper.ClassAdapters.CustomCellAdapter(GameData.ListCells, (AppCompatActivity)this);
            objCell.actionMenuSelected += ObjCell_actionMenuSelected;
            gridGame.Adapter = objCell;
            objCell.NotifyDataSetChanged();

        }
        #endregion




    }
}