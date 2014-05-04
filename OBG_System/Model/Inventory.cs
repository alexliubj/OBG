using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Inventory
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
    }
}
