using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class LoginRet
    {
        public enum RoleStatus
        { 
            Admin,
            Customher,
            Other
        }

        public enum UserStatus
        {
            active,
            inactive
        }
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private RoleStatus rs;

        public RoleStatus Rs
        {
            get { return rs; }
            set { rs = value; }
        }
        private UserStatus us;

        public UserStatus Us
        {
            get { return us; }
            set { us = value; }
        }
    }
}
