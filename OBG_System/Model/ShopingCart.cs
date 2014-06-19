using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class ShopingCart
    {
        private int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        private int tireId;
        public int TireId
        {
            get { return tireId; }
            set { tireId = value; }
        }

        private int accId;
        public int AccId
        {
            get { return tireId; }
            set { tireId = value; }
        }
        
        
        
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        private int qty;

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        private double pricing;
        public double Pricing
        {
            get { return pricing; }
            set { pricing = value; }
        }

        private string partNo;
        public string PartNo
        {
            get { return partNo; }
            set { partNo = value; }
        }

        private string productname;
        public string productName
        {
            get { return productname; }
            set { productname = value; }
        }
    }
}
