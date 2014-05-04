using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Shipping
    {
        private int regionId;

        public int RegionId
        {
            get { return regionId; }
            set { regionId = value; }
        }
        private string regionName;

        public string RegionName
        {
            get { return regionName; }
            set { regionName = value; }
        }
        private float regionPrice;

        public float RegionPrice
        {
            get { return regionPrice; }
            set { regionPrice = value; }
        }
        private string devMethods;

        public string DevMethods
        {
            get { return devMethods; }
            set { devMethods = value; }
        }
    }
}
