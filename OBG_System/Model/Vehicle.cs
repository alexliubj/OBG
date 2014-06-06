using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Vehicle
    {
        private int vehicleId;

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }

        private int wheelsId;

        public int WheelsId
        {
            get { return wheelsId; }
            set { wheelsId = value; }
        }

        private string vehicleName;

        public string VehicleName
        {
            get { return vehicleName; }
            set { vehicleName = value; }
        }

    }
}
