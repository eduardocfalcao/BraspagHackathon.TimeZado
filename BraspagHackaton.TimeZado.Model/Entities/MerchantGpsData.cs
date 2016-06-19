using Android.Locations;

namespace BraspagHackathon.TimeZado.Model.Entities
{
    public class MerchantGpsData
    {
        public Merchant Merchant { get; set; }

        public Address Address { get; set; }

        public double DistanceInKilometers { get; set; }
    }
}