using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class CartsModel
    {
        public List<Cart> carts { get; set; }

    }



    public class Cart
    {
        public int id { get; set; }
        public Product[] products { get; set; }
        public float total { get; set; }
        public float discountedTotal { get; set; }
        public int userId { get; set; }
        public int totalProducts { get; set; }
        public int totalQuantity { get; set; }
    }

   

}
