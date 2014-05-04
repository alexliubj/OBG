using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class RoleModule
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
        private int moduleId;

        public int ModuleId
        {
            get { return moduleId; }
            set { moduleId = value; }
        }
    }
}
