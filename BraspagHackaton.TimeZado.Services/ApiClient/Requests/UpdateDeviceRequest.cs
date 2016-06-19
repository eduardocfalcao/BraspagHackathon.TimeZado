using System;

namespace BraspagHackaton.TimeZado.Services.ApiClient.Requests
{
    public class UpdateDeviceRequest
    {
        public Guid Id { get; set; }

        public string Type { get; set; }

        public int CustomerId { get; set; }

        public int OfferId { get; set; }
    }
}