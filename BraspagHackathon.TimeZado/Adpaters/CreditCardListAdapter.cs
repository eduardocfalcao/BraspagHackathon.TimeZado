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
using Java.Lang;
using BraspagHackathon.TimeZado.Model.Entities;

namespace BraspagHackathon.TimeZado.Adpaters
{
    public class CreditCardListAdapter : BaseAdapter
    {
        private Activity context;
        private List<CreditCard> creditCards;

        public CreditCardListAdapter(Activity context, List<CreditCard> creditCards)
        {
            this.context = context;
            this.creditCards = creditCards;
        }

        public override int Count
        {
            get
            {
                return this.creditCards.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return GetCreditCard(position).Id;
        }

        public CreditCard GetCreditCard(int position)
        {
            return this.creditCards.ElementAt(position);
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var creditCard = GetCreditCard(position);

            if (convertView == null)
            {
                convertView = LayoutInflater.From(context).Inflate(Resource.Layout.CardsListTemplate, null);
            }

            convertView.FindViewById<TextView>(Resource.Id.CardInfo_CardNumber).Text = creditCard.MaskedValue;

            return convertView;
        }
    }
}