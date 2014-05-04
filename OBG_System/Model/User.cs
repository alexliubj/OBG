using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OBGModel
{
    public class User
    {
        private int userid;

        public int Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        private string userpwd;

        public string Userpwd
        {
            get { return userpwd; }
            set { userpwd = value; }
        }
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        private string billAddress;

        public string BillAddress
        {
            get { return billAddress; }
            set { billAddress = value; }
        }
        private string billPostCode;

        public string BillPostCode
        {
            get { return billPostCode; }
            set { billPostCode = value; }
        }
        private string shippingAddress;

        public string ShippingAddress
        {
            get { return shippingAddress; }
            set { shippingAddress = value; }
        }
        private string shippingPostCode;

        public string ShippingPostCode
        {
            get { return shippingPostCode; }
            set { shippingPostCode = value; }
        }
    }
}
