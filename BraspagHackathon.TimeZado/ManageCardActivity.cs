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
using BraspagHackathon.TimeZado.Adpaters;
using BraspagHackaton.TimeZado.Model;
using BraspagHackathon.TimeZado.Model.Entities;
using BraspagHackaton.TimeZado.Services.ApiClient;

namespace BraspagHackathon.TimeZado
{
    [Activity(Label = "Gerenciar cartões")]
    public class ManageCardActivity : Activity
    {
        private CreditCardListAdapter creditCardAdapter;

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
            var intent = new Intent(this, typeof(InsertCardActivity));
            StartActivity(intent);
        }

        private void ConfigureListView()
        {
            var listview = FindViewById<ListView>(Resource.Id.CardsList);
            var dataProvider = InMemoryDataProvider.GetDataProvider();
            var gc = dataProvider.Read<GlobalConfiguration>()
                                          .Single(x => x.Key == GlobalConfigurationKeys.CostumerId);

            LoadCreditCardData((data) =>
            {
                creditCardAdapter = new CreditCardListAdapter(this, data);
                listview.Adapter = creditCardAdapter;

                listview.ItemClick += Listview_ItemClick;
            }, int.Parse(gc.Value));
        }

        public async void LoadCreditCardData(Action<List<CreditCard>> callback, int customerId)
        {
            var creditCardApiClient = new CreditCardApiClient();
            var creditCardList = await creditCardApiClient.Get();

            if (callback != null)
            {
                callback(creditCardList.Where(x => x.CustomerId == customerId)
                                       .Select(creditCardResponse => new CreditCard()
                                                   {
                                                       CostumerId = creditCardResponse.CustomerId,
                                                       CreatedOn = creditCardResponse.CreatedOn,
                                                       Id = creditCardResponse.Id,
                                                       MaskedValue = creditCardResponse.MaskedValue,
                                                       Token = creditCardResponse.Token
                                                   })
                                       .ToList());
            }

        }

        private void Listview_ItemClick(object sender, AdapterView.ItemClickEventArgs args)
        {
            var creditCard = creditCardAdapter.GetCreditCard(args.Position);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Confirmar de cartão de crédito para compras");
            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alertDialog.SetMessage(string.Format("Deseja utilizar o cartão {0} como meio de pagamento para suas próximas compras?",creditCard.MaskedValue));
            alertDialog.SetButton("Confirmar", (s, e) =>
            {
                var provider = InMemoryDataProvider.GetDataProvider();

                var customerIdConfiguration = provider.Read<GlobalConfiguration>()
                                                      .FirstOrDefault(x => x.Key == GlobalConfigurationKeys.CostumerId);

                


                alertDialog.Dismiss();
            });

            alertDialog.SetButton2("Cancelar", (s, e) =>
            {
                alertDialog.Dismiss();
            });

            alertDialog.Show();



        }
    }
}