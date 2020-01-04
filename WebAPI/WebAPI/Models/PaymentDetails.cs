using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class PaymentDetails
    {
        public int PMId { get; set; }
        public string CardOwnerName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
    }
}
