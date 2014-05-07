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
    protected void Page_Load(object sender, EventArgs e)
    {
        //for test purpose
        Session["userId"] = 1;

        if (Session["userId"] != null)
        {
             int userId = (int)Session["userId"];
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
        User user = new User();

        user.UserName = "Neo";

        //user = UserBLO.GetUserInfoWithUserId(userId);
        UserName.Text = user.UserName;
        //Email.Text = user.Email;
        //FirstName.Text = user.FirstName;
        //LastName.Text = user.LastName;
        Password.Text = user.Userpwd;
        Company.Text = user.CompanyName;
        Phone.Text = user.Phone;
        ShippingAddress.Text = user.ShippingAddress;
        ShippingPostCode.Text = user.ShippingPostCode;
        

    }
    protected void BtnEdit_Click(object sender, EventArgs e)
    {
        UserName.ReadOnly = false;
        Email.ReadOnly = false;
        FirstName.ReadOnly = false;
        LastName.ReadOnly = false;
        Password.ReadOnly = false;
        Company.ReadOnly = false;
        Phone.ReadOnly = false;
        ShippingAddress.ReadOnly = false;
        ShippingPostCode.ReadOnly = false;
        BtnSave.Visible = true;
        BtnCancle.Visible = true;

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        User userSaved = new User();
        userSaved.UserName = UserName.Text;
        userSaved.Userpwd = Password.Text;
        userSaved.CompanyName = Company.Text;
        userSaved.Phone = Phone.Text;
        userSaved.ShippingAddress = ShippingAddress.Text;
        userSaved.ShippingPostCode = ShippingPostCode.Text;
        bool update = false;
        //update = UserBLO.UpdateUserInfo(userSaved);
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
        Password.ReadOnly = true;
        Company.ReadOnly = true;
        Phone.ReadOnly = true;
        ShippingAddress.ReadOnly = true;
        ShippingPostCode.ReadOnly = true;
        BtnSave.Visible = false;
        BtnCancle.Visible = false;
    }
}