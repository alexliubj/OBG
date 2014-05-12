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
        //for test purpose
        //Session["userID"] = 1;
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
            //test purpose
            //user.UserName = "neobility3";
            //user.FirstName = "neo";
            //user.LastName = "wu";
            //user.Phone = "206478990689";
            //user.CompanyName = "lol";
            //user.ShippingAddress = "address";
            //user.ShippingPostCode = "94105-0011";
            //user.Email = "neo.wu2@gmail.com";
            //user.BillAddress = "dd";
            //user.BillPostCode = "x1d3d2";
            //

            user = UserBLO.GetUserInfoWithUserId(userID);
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

        //test purpose
        //userSaved.Userid = 2;
        //
        userSaved.Userid = userID;
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