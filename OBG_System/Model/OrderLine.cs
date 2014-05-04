using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class OrderLine
    {
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        private float discountRate;

        public float DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }
        private int OrderId;

        public int OrderId1
        {
            get { return OrderId; }
            set { OrderId = value; }
        }
    }
}
