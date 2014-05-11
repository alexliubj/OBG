using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class Tire
    {
        private int tireId;

        public int TireId
        {
            get { return tireId; }
            set { tireId = value; }
        }
        private string partNo;

        public string PartNo
        {
            get { return partNo; }
            set { partNo = value; }
        }
        private string size;

        public string Size
        {
            get { return size; }
            set { size = value; }
        }
        private float width;

        public float Width
        {
            get { return width; }
            set { width = value; }
        }
        private float height;

        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        private float pricing;

        public float Pricing
        {
            get { return pricing; }
            set { pricing = value; }
        }
        private string season;

        public string Season
        {
            get { return season; }
            set { season = value; }
        }
        private int categoryId;

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
    }
}
