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
    public class FirstAccessConfigurationActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FirstAccessConfiguration);

            var createCustomerButton = FindViewById(Resource.Id.CreateCustomerButton);
            createCustomerButton.Click += CreateCustomerButton_Click;
        }

        private void CreateCustomerButton_Click(object sender, EventArgs e)
        {
            //chamar a api para criar o customer. Salvar Local o customer id.
        }
    }
}