using System;
using System.Collections.Generic;

namespace PenguinMusic.Data.Models
{
    public partial class Donation
    {
        public Donation(int id, string name, int amount)
        {
            DonationId = id;
            Name = name;
            Amount = amount;
        }
        public int DonationId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public override string ToString()
        {
            return Name + " - " + Amount;
        }
    }
}
