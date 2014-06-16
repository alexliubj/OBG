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
        private float wheelDisrate;

        public float WheelDisrate
        {
            get { return wheelDisrate; }
            set { wheelDisrate = value; }
        }

        private float tireDisrate;

        public float TireDisrate
        {
            get { return tireDisrate; }
            set { tireDisrate = value; }
        }
        private float accDisrate;

        public float AccDisrate
        {
            get { return accDisrate; }
            set { accDisrate = value; }
        }
    }
}
