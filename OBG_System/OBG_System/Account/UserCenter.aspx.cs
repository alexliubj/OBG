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
    int userID;
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            userID = (int)Session["userID"];
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
            ShippingAddress.Text = user.ShippingHouseNo;
            ShippingPostCode.Text = user.ShippingPostCode;
            BillingAddress.Text = user.BillingHouseNo;
            BillingPostCode.Text = user.BillPostCode;
        }
    }
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        Email.ReadOnly = false;
        FirstName.ReadOnly = false;
        LastName.ReadOnly = false;
        Company.ReadOnly = false;
        Phone.ReadOnly = false;
        ShippingAddress.ReadOnly = false;
        ShippingPostCode.ReadOnly = false;
        BillingAddress.ReadOnly = false;
        BillingPostCode.ReadOnly = false;
        BtnSave.Visible = true;
        BtnCancle.Visible = true;
    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        User userSaved = new User();
        userSaved = UserBLO.GetUserInfoWithUserId(userID);

        userSaved.Userid = userID;
        userSaved.Email = Email.Text;
        userSaved.FirstName = FirstName.Text;
        userSaved.LastName = LastName.Text;
        userSaved.CompanyName = Company.Text;
        userSaved.Phone = Phone.Text;
        userSaved.ShippingHouseNo = ShippingAddress.Text;
        userSaved.ShippingPostCode = ShippingPostCode.Text;
        userSaved.BillingHouseNo = BillingAddress.Text;
        userSaved.BillPostCode = BillingPostCode.Text;

        //userSaved.BillingCity = string.Empty;
        //userSaved.BillingProvince = string.Empty;
        //userSaved.BillingStreet = string.Empty;
        //userSaved.IsSameAddress = false;
        //userSaved.RegionId = 0;
        //userSaved.ShippingCity = string.Empty;
        //userSaved.ShippingProvince = string.Empty;
        //userSaved.ShippingStreet = string.Empty;

        int update = 0;
        update = UserBLO.UpdateUserInfo(userSaved);

        if (update == 1)
        {
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
        ShippingAddress.ReadOnly = true;
        ShippingPostCode.ReadOnly = true;
        BillingAddress.ReadOnly = true;
        BillingPostCode.ReadOnly = true;
        BtnSave.Visible = false;
        BtnCancle.Visible = false;
    }
    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/ChangePassword.aspx");
    }
}