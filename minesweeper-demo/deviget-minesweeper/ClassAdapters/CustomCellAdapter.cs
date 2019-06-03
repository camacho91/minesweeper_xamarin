using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using msLibrary.setup;

namespace deviget_minesweeper.ClassAdapters
{
    public class CustomCellAdapter : BaseAdapter
    {

        AppCompatActivity context;
        internal event Action<int, int> actionMenuSelected;
        List<GameVariables.Cells> listCells = new List<GameVariables.Cells>();

        public CustomCellAdapter(List<GameVariables.Cells> listCells, AppCompatActivity context)
        {
            this.listCells = listCells;
            this.context = context;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            CellHolderClass objCellHolderClass;
            View view;
            view = convertView;

            GameVariables.Cells objCell = listCells[position];
            view = context.LayoutInflater.Inflate(Resource.Layout.custom_cell, parent, false);

            objCellHolderClass = new CellHolderClass();



            objCellHolderClass.imgValue = view.FindViewById<ImageView>(Resource.Id.imgContent);
            objCellHolderClass.layoutButton = view.FindViewById<LinearLayout>(Resource.Id.lytCell);
            objCellHolderClass.initialize(view);
            view.Tag = objCellHolderClass;


            objCellHolderClass.viewClicked = () =>
            {
                if (actionMenuSelected != null)
                {
                    actionMenuSelected(objCell.xCoord, objCell.yCoord);
                }
            };



            objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.untouched);

            return view;
        }

        public override int Count => listCells.Count();

    }

    class CellHolderClass : Java.Lang.Object
    {
        internal LinearLayout layoutButton;
        internal ImageView imgValue;

        internal Action viewClicked { get; set; }


        public void initialize(View view)
        {
            imgValue.Click += delegate {
                viewClicked();
            };
        }
    }
}