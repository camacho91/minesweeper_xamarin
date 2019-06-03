using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace deviget_minesweeper
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        #region Variables

        //GrigView container for the game board
        GridView gridGame;

        #endregion


        #region methods
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //Grid initialization
            gridGame = FindViewById<GridView>(Resource.Id.gridGame);

        }
        #endregion
    }
}