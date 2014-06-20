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
        //discountRate means price now
        private float discountRate;

        public float DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }
        private int orderId;

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        private int productType;
        public int ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string partNO;

        public string PartNO
        {
            get { return partNO; }
            set { partNO = value; }
        }


    }
}
