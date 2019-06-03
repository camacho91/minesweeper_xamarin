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



            if (!objCell.isFlipped)
            {
                objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.untouched);
            }
            else if (objCell.isFlipped && !objCell.containsMine)
            {
                if (objCell.showNumber == 0)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.zero);
                }
                else if (objCell.showNumber == 1)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.one);
                }
                else if (objCell.showNumber == 2)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.two);
                }
                else if (objCell.showNumber == 3)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.three);
                }
                else if (objCell.showNumber == 4)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.four);
                }
                else if (objCell.showNumber == 5)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.five);
                }
                else if (objCell.showNumber == 6)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.six);
                }
                else if (objCell.showNumber == 7)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.seven);
                }
                else if (objCell.showNumber == 8)
                {
                    objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.eight);
                }

            }
            else if (objCell.isFlipped && objCell.containsMine)
            {
                objCellHolderClass.imgValue.SetImageResource(Resource.Drawable.mine);
            }


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