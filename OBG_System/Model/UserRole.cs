﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class UserRole
    {
        private int uid;

        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private int roleId;

        public int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private string des;

        public string Des
        {
            get { return des; }
            set { des = value; }
        }
    }
}
