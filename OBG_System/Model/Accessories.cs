using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Accessories
    {
        private int accId;

        public int AccId
        {
            get { return accId; }
            set { accId = value; }
        }
        private string partNo;

        public string PartNo
        {
            get { return partNo; }
            set { partNo = value; }
        }
        private string img;

        public string Img
        {
            get { return img; }
            set { img = value; }
        }
        private string des;

        public string Des
        {
            get { return des; }
            set { des = value; }
        }
        private float pricing;

        public float Pricing
        {
            get { return pricing; }
            set { pricing = value; }
        }
        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

    }
}
