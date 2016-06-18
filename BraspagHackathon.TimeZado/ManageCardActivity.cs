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
    [Activity(Label = "Gerenciar cartões")]
    public class ManageCardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ManageCard);

            ConfigureListView();

            var button = FindViewById<Button>(Resource.Id.OpenInsertCardWindowButton);
            button.Click += OpenInsertCardActivity;
        }

        private void OpenInsertCardActivity(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof());
        }

        private void ConfigureListView()
        {
            var listview = FindViewById<ListView>(Resource.Id.CardsList);

            var data = new[] { "1111", "2222", "3333" };
            var adapter = new ArrayAdapter<string>(this, Resource.Layout.CardsListTemplate, data);
            listview.Adapter = adapter;
        }
    }
}