using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class ReturnPolicy
    {
        private string others;

        public string Others
        {
            get { return others; }
            set { others = value; }
        }
        private string returnPolicy;

        public string ReturnPolicy1
        {
            get { return returnPolicy; }
            set { returnPolicy = value; }
        }
        private string price;

        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        private string shipping;

        public string Shipping
        {
            get { return shipping; }
            set { shipping = value; }
        }
        private string defects;

        public string Defects
        {
            get { return defects; }
            set { defects = value; }
        }


    }
}
