using System;

namespace BraspagHackaton.TimeZado.Services.ApiClient.Response
{
    public class CreditCardCreateResponse
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Token { get; set; }

        public string MaskedValue { get; set; }

        public int CustomerId { get; set; }
    }
}