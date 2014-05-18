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

        private string roleName;

        public string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
