using System;

namespace Prb.FilaApiRest.Domain
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
    }
}
