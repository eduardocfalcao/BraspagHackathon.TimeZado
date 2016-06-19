using System;

namespace BraspagHackathon.TimeZado.Model.Entities
{
    public class Device
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string Type { get; set; }

        public int? CustomerId { get; set; }

        public int? OfferId { get; set; }
    }
}