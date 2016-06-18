﻿using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "BraspagHackathon.TimeZado", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            string dbName = "timezado.db";
            var dataProvider = new DataProvider(dbName);
            dataProvider.InitDatabase();

            CheckIfIsFirstAccess(dataProvider);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.OpenManageCardButton);
            Button nearbyMerchantsButton = FindViewById<Button>(Resource.Id.OpenNearbyMerchantsButton);

            button.Click += OpenManageCardsActivity;
            nearbyMerchantsButton.Click += NearbyMerchantsButton_Click;
        }

        private void CheckIfIsFirstAccess(DataProvider dataProvider)
        {
            var firstAccess = dataProvider.Read<GlobalConfiguration>()
                                          .Any(x => x.Key == GlobalConfigurationKeys.CostumerId) == false;

            if(firstAccess)
            {
                OpenFirstAccessConfigurationActivity();
            }
        }

        private void OpenFirstAccessConfigurationActivity()
        {
            var intent = new Intent(this, typeof(FirstAccessConfigurationActivity));
            StartActivity(intent);
        }

        private void NearbyMerchantsButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(NearbyMerchantsActivity));
            StartActivity(intent);
        }

        private void OpenManageCardsActivity(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ManageCardActivity));
            StartActivity(intent);
        }
    }
}

