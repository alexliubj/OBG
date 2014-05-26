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
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
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

        public string BillingHouseNo
        {
            get { return billAddress; }
            set { billAddress = value; }
        }

        private string billingStreet;

        public string BillingStreet
        {
            get { return billingStreet; }
            set { billingStreet = value; }
        }
        private string billingCity;

        public string BillingCity
        {
            get { return billingCity; }
            set { billingCity = value; }
        }
        private string billingProvince;

        public string BillingProvince
        {
            get { return billingProvince; }
            set { billingProvince = value; }
        }

        private string shippingStreet;

        public string ShippingStreet
        {
            get { return shippingStreet; }
            set { shippingStreet = value; }
        }
        private string shippingCity;

        public string ShippingCity
        {
            get { return shippingCity; }
            set { shippingCity = value; }
        }
        private string shippingProvince;

        public string ShippingProvince
        {
            get { return shippingProvince; }
            set { shippingProvince = value; }
        }

        private string billPostCode;

        public string BillPostCode
        {
            get { return billPostCode; }
            set { billPostCode = value; }
        }
        private string shippingHouseNo;

        public string ShippingHouseNo
        {
            get { return shippingHouseNo; }
            set { shippingHouseNo = value; }
        }
        private string shippingPostCode;

        public string ShippingPostCode
        {
            get { return shippingPostCode; }
            set { shippingPostCode = value; }
        }

        private bool isSameAddress;

        public bool IsSameAddress
        {
            get { return isSameAddress; }
            set { isSameAddress = value; }
        }
    }
}
