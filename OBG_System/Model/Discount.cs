using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Discount
    {
        private int roleId;

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        private float discountRate;

        public float DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }

        private int roleName;

        public int RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
