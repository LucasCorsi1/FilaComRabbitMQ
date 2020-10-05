namespace Prb.FilaApiRest.ApiModel
{
    public class OrderViewModel
    {
        public class Request
        {
            public int OrderNumber { get; set; }
            public string Item { get; set; }
            public double Price { get; set; }

        }
        public class Response : Request { }
    }
}
