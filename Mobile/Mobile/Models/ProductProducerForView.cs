using AdminServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobile.Models
{
    public class ProductProducerForView
    {
        public int IdProductProducer { get; set; }
        public string Title { get; set; }
        public string Destiny { get; set; }
        public string Description { get; set; }

        public ProductProducerForView() { }
        public ProductProducerForView(ProductProducer productProducer)
        {
            IdProductProducer = productProducer.IdProductProducer;
            Title = productProducer.Title;
            Destiny = productProducer.Destiny;
            Description = productProducer.Description;
        }
    }
}
