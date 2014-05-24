using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Discount
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private float discountRate;

        public float DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }

    }
}
