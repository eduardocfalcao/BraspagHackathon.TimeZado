using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Inserir Cartão de crédito")]
    public class InsertCardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.InsertCardWindow);

            var button = FindViewById<Button>(Resource.Id.InsertCardButton);

            button.Click += InsertCard;
        }

        private void InsertCard(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}