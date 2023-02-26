using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Donations
    {
        public int DonationId { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
