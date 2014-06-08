using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;

public partial class Default2 : System.Web.UI.Page
{
    int userID = 0;
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            userID = (int)Session["UserID"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }

        if (!IsPostBack)
        {
            user = UserBLO.GetUserInfoWithUserId(userID);
            UserName.Text = user.UserName;
            Email.Text = user.Email;
            FirstName.Text = user.FirstName;
            LastName.Text = user.LastName;
            Company.Text = user.CompanyName;
            Phone.Text = user.Phone;
            ShippingHouseNo.Text = user.ShippingHouseNo;
            ShippingPostCode.Text = user.ShippingPostCode;
            ShippingCity.Text = user.ShippingCity;
            ShippingPro.SelectedValue = user.ShippingProvince;
            ShippingStreet.Text = user.ShippingStreet;
            BillingHouseNo.Text = user.BillingHouseNo;
            BillingPostCode.Text = user.BillPostCode;
            BillingCity.Text = user.BillingCity;
            BillingPro.SelectedValue = user.BillingProvince;
            BillingStreet.Text = user.BillingStreet;
        }
    }
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        Email.ReadOnly = false;
        FirstName.ReadOnly = false;
        LastName.ReadOnly = false;
        Company.ReadOnly = false;
        Phone.ReadOnly = false;
        ShippingHouseNo.ReadOnly = false;
        ShippingPostCode.ReadOnly = false;
        ShippingStreet.ReadOnly = false;
        ShippingCity.ReadOnly = false;
        ShippingPro.Enabled = true;
        BillingHouseNo.ReadOnly = false;
        BillingPostCode.ReadOnly = false;
        BillingStreet.ReadOnly = false;
        BillingCity.ReadOnly = false;
        BillingPro.Enabled = true;
        BtnSave.Visible = true;
        BtnCancle.Visible = true;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        User userSaved = new User();
        userSaved = UserBLO.GetUserInfoWithUserId(userID);

        userSaved.Userid = userID;
        userSaved.Email = Email.Text.ToString().Trim();
        userSaved.FirstName = FirstName.Text.ToString().Trim();
        userSaved.LastName = LastName.Text.ToString().Trim();
        userSaved.CompanyName = Company.ToString().Trim();
        userSaved.Phone = Phone.Text.ToString().Trim();
        userSaved.ShippingHouseNo = ShippingHouseNo.Text.ToString().Trim();
        userSaved.ShippingPostCode = ShippingPostCode.Text.ToString().Trim();
        userSaved.ShippingCity = ShippingCity.Text.ToString().Trim();
        userSaved.ShippingProvince = ShippingPro.SelectedValue;
        userSaved.ShippingStreet = ShippingStreet.Text.ToString().Trim();
        userSaved.BillingHouseNo = BillingHouseNo.Text;
        userSaved.BillPostCode = BillingPostCode.Text;
        userSaved.BillingCity = BillingCity.Text.ToString().Trim();
        userSaved.BillingProvince = BillingPro.SelectedValue;
        userSaved.BillingStreet = BillingStreet.Text.ToString().Trim();

        //userSaved.IsSameAddress = false;
        //userSaved.RegionId = 0;

        int update = 0;
        update = UserBLO.UpdateUserInfo(userSaved);

        if (update == 1)
        {
            Email.ReadOnly = true;
            FirstName.ReadOnly = true;
            LastName.ReadOnly = true;
            Company.ReadOnly = true;
            Phone.ReadOnly = true;
            ShippingHouseNo.ReadOnly = true;
            ShippingPostCode.ReadOnly = true;
            ShippingStreet.ReadOnly = true;
            ShippingCity.ReadOnly = true;
            ShippingPro.Enabled = false;
            BillingHouseNo.ReadOnly = true;
            BillingPostCode.ReadOnly = true;
            BillingStreet.ReadOnly = true;
            BillingCity.ReadOnly = true;
            BillingPro.Enabled = false;
            BtnSave.Visible = false;
            BtnCancle.Visible = false;

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Account information has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Account information failed.');",
                        true);
        }
    }
    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        Email.ReadOnly = true;
        FirstName.ReadOnly = true;
        LastName.ReadOnly = true;
        Company.ReadOnly = true;
        Phone.ReadOnly = true;
        ShippingHouseNo.ReadOnly = true;
        ShippingPostCode.ReadOnly = true;
        ShippingStreet.ReadOnly = true;
        ShippingCity.ReadOnly = true;
        ShippingPro.Enabled = false;
        BillingHouseNo.ReadOnly = true;
        BillingPostCode.ReadOnly = true;
        BillingStreet.ReadOnly = true;
        BillingCity.ReadOnly = true;
        BillingPro.Enabled = false;
        BtnSave.Visible = false;
        BtnCancle.Visible = false;
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/ChangePassword.aspx");
    }
}