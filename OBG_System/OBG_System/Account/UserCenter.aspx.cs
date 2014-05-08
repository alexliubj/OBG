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
    int userId;
    User user = new User();
    protected void Page_Load(object sender, EventArgs e)
    {
        //for test purpose
        Session["userId"] = 1;

        if (Session["userId"] != null)
        {
             userId = (int)Session["userId"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        //test purpose
        user.UserName = "neobility";
        user.FirstName = "neo";
        user.LastName = "wu";
        user.Phone = "206478990689";
        user.CompanyName = "lol";
        user.ShippingAddress = "address";
        user.ShippingPostCode = "94105-0011";
        user.Email = "neo.wu2@gmail.com";
        user.BillAddress = "dd";
        user.BillPostCode = "x1d3d2";

       // user = UserBLO.GetUserInfoWithUserId(userId);
        UserName.Text = user.UserName;
        Email.Text = user.Email;
        FirstName.Text = user.FirstName;
        LastName.Text = user.LastName;
        Company.Text = user.CompanyName;
        Phone.Text = user.Phone;
        ShippingAddress.Text = user.ShippingAddress;
        ShippingPostCode.Text = user.ShippingPostCode;
        BillingAddress.Text = user.BillAddress;
        BillingPostCode.Text = user.BillPostCode;
    }
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        UserName.ReadOnly = false;
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
        userSaved.UserName = UserName.Text;
        userSaved.Email = Email.Text;
        userSaved.FirstName = FirstName.Text;
        userSaved.LastName = LastName.Text;
        userSaved.CompanyName = Company.Text;
        userSaved.Phone = Phone.Text;
        userSaved.ShippingAddress = ShippingAddress.Text;
        userSaved.ShippingPostCode = ShippingPostCode.Text;
        userSaved.BillAddress = BillingAddress.Text;
        userSaved.BillPostCode = BillingPostCode.Text;

        bool update = false;
        update = UserBLO.UpdateUserInfo(userSaved);

        if (update == true)
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
        UserName.ReadOnly = true;
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
}