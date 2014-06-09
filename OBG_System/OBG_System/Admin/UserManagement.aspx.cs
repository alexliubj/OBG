using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Default : System.Web.UI.Page
{
    private DataSet userDataSet;
    int adminID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            adminID = (int)Session["AdminID"];
        }
        else
        {
            Response.Redirect("~/Admin/Login.aspx");
        }

        if (!IsPostBack)
        {
            bind();
        }

    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes.Add("onmouseover", "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#C0C0FF';this.style.cursor='hand';");
        //    //当鼠标移走时还原该行的背景色
        //    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
        //    //选择任意处都选择
        //    e.Row.Attributes.Add("onClick", "javascript:__doPostBack('" + GridView1.ID + "','Select$" + e.Row.RowIndex + "');");
        //}
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        UserBLO.RemoveUserById(userID);
        userInformation.Visible = false;
        bind();

    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //int userID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        //User user = UserBLO.GetUserInfoWithUserId(userID);
        //user.Userid = userID;
        //user.UserName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString().Trim();
        //DropDownList ddl = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1"));
        //if (ddl.SelectedItem.Text == "active")
        //{
        //    user.Status = 1;
        //}
        //else if (ddl.SelectedItem.Text == "inactive")
        //{
        //    user.Status = 0;
        //}
        //user.Status = int.Parse(((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("TextBox3"))).Text.ToString().Trim());
        //user.Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text.ToString().Trim();
        //user.CompanyName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("TextBox5"))).Text.ToString().Trim();
        //user.Phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("TextBox1"))).Text.ToString().Trim();
    }

    public void bind()
    {

        DataTable usersTable = UserBLO.GetAllUsers();
        userDataSet = new DataSet();
        userDataSet.Tables.Add(usersTable);

        GridView1.DataSource = userDataSet;
        GridView1.DataKeyNames = new string[] { "userid" };
        GridView1.DataBind();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text.ToString().Trim() == "0")
            {
                ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text = "Inactive";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("activeButton")).Text = "Active";

            }
            else if (((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text.ToString().Trim() == "1")
            {
                ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text = "Active";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("activeButton")).Text = "Inactive";
            }
        }
    }

    //http://hi.baidu.com/utxqrqhkvhbgmwd/item/6f5562e5bd14f301570f1d07
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes["OnClick"] = ClientScript.GetPostBackEventReference(e.Row.Parent.Parent, "Select$" + e.Row.RowIndex);
        //    e.Row.Attributes.Add("onMouseOver", "t=this.style.backgroundColor;this.style.backgroundColor='#ebebce'");
        //    e.Row.Attributes.Add("onMouseOut", " this.style.backgroundColor=t");
        //    e.Row.Attributes.CssStyle.Add("cursor", "hand");
        //}

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    ((Button)e.Row.Cells[8].Controls[0]).OnClientClick = "return confirm('Do you really want to delete?');";
        //}

        //DataTable myTable = new DataTable();

        //DataColumn userIDColumn = new DataColumn("UserID");

        //DataColumn statusColumn = new DataColumn("Status");

        //myTable.Columns.Add(userIDColumn);

        //myTable.Columns.Add(statusColumn);

        //DataSet ds = new DataSet();

        //ds = bind();

        //int userID = 0;

        //string expression = String.Empty;

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    userID = Int32.Parse(e.Row.Cells[0].Text);

        //    expression = "UserID = " + userID;

        //    DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList1");

        //    DataRow[] rows = ds.Tables[0].Select(expression);



        //    foreach (DataRow row in rows)
        //    {

        //        DataRow newRow = myTable.NewRow();

        //        newRow["UserID"] = row["UserID"];

        //        newRow["Status"] = row["Status"];

        //        myTable.Rows.Add(newRow);

        //    }

        //    Label lb = ((Label)e.Row.FindControl("Label3"));

        //    ddl.DataSource = myTable;

        //    ddl.DataTextField = "Status";

        //    ddl.DataValueField = "UserID";

        //    ddl.SelectedValue = lb.Text;

        //    ddl.DataBind();

        //}

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        User userSaved = new User();
        int userID;
        userID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        userSaved.Userid = userID;
        userSaved.UserName = UserName.Text.ToString().Trim();
        userSaved.Email = Email.Text.ToString().Trim();
        userSaved.FirstName = FirstName.Text.ToString().Trim();
        userSaved.LastName = LastName.Text.ToString().Trim();
        userSaved.CompanyName = Company.Text.ToString().Trim();
        userSaved.Phone = Phone.Text.ToString().Trim();

        userSaved.ShippingHouseNo = ShippingHouseNo.Text.ToString().Trim();
        userSaved.ShippingPostCode = ShippingPostCode.Text.ToString().Trim();
        userSaved.ShippingCity = ShippingCity.Text.ToString().Trim();
        userSaved.ShippingProvince = ShippingPro.SelectedValue;
        userSaved.ShippingStreet = ShippingStreet.Text.ToString().Trim();
        userSaved.BillingHouseNo = BillingHouseNo.Text.ToString().Trim();
        userSaved.BillPostCode = BillingPostCode.Text.ToString().Trim();
        userSaved.BillingCity = BillingCity.Text.ToString().Trim();
        userSaved.BillingProvince = BillingPro.SelectedValue;
        userSaved.BillingStreet = BillingStreet.Text.ToString().Trim();

        int update = 0;
        update = UserBLO.UpdateUserInfo(userSaved);


        if (update == 1)
        {
            bind();
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
        userInformation.Visible = false;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int userID;
        userID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        User user = new User();

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

        userInformation.Visible = true;
        PasswordLabel.Visible = false;
        Password.Visible = false;
        ConfirmPasswordLabel.Visible = false;
        ConfirmPassword.Visible = false;
        BtnAdd.Visible = false;
        BtnSave.Visible = true;
    }
    protected void activeButton_Click(object sender, EventArgs e)
    {
        //if (GridView1.SelectedValue != null)
        //{
        //    int userID = Convert.ToInt32(GridView1.SelectedValue.ToString());

        //    User user = new User();
        //    user = UserBLO.GetUserInfoWithUserId(userID);
        //    if (user.Status == 0)
        //    {
        //        UserBLO.AdminActiveUserStatus(userID, 1);
        //    }
        //    else if (user.Status == 1)
        //    {
        //        UserBLO.AdminActiveUserStatus(userID, 0);
        //    }
        //    bind();
        //}
    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Active")
        {
            int rowindex = Convert.ToInt32(e.CommandArgument);

            int userID = Convert.ToInt32(GridView1.DataKeys[rowindex].Value.ToString());

            User user = new User();
            user = UserBLO.GetUserInfoWithUserId(userID);
            if (user.Status == 0)
            {
                UserBLO.AdminActiveUserStatus(userID, 1);
            }
            else if (user.Status == 1)
            {
                UserBLO.AdminActiveUserStatus(userID, 0);
            }
            bind();
        }
    }

    protected void btnAddUser_Click(object sender, EventArgs e)
    {
        UserName.ReadOnly = false;
        UserName.Text = null;
        Email.Text = null;
        FirstName.Text = null;
        LastName.Text = null;
        Company.Text = null;
        Phone.Text = null;

        ShippingHouseNo.Text = null;
        ShippingPostCode.Text = null;
        ShippingCity.Text = null;
        ShippingPro.SelectedValue = null;
        ShippingStreet.Text = null;

        BillingHouseNo.Text = null;
        BillingPostCode.Text = null;
        BillingCity.Text = null;
        BillingPro.SelectedValue = null;
        BillingStreet.Text = null;

        userInformation.Visible = true;
        PasswordLabel.Visible = true;
        Password.Visible = true;
        ConfirmPasswordLabel.Visible = true;
        ConfirmPassword.Visible = true;
        BtnAdd.Visible = true;
        BtnSave.Visible = false;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        User userSaved = new User();

        userSaved.UserName = UserName.Text.ToString().Trim();
        userSaved.Email = Email.Text.ToString().Trim();
        userSaved.FirstName = FirstName.Text.ToString().Trim();
        userSaved.LastName = LastName.Text.ToString().Trim();
        userSaved.CompanyName = Company.Text.ToString().Trim();
        userSaved.Phone = Phone.Text.ToString().Trim();
        userSaved.ShippingHouseNo = ShippingHouseNo.Text.ToString().Trim();
        userSaved.ShippingPostCode = ShippingPostCode.Text.ToString().Trim();
        userSaved.ShippingCity = ShippingCity.Text.ToString().Trim();
        userSaved.ShippingProvince = ShippingPro.SelectedValue;
        userSaved.ShippingStreet = ShippingStreet.Text.ToString().Trim();
        userSaved.BillingHouseNo = BillingHouseNo.Text.ToString().Trim();
        userSaved.BillPostCode = BillingPostCode.Text.ToString().Trim();
        userSaved.BillingCity = BillingCity.Text.ToString().Trim();
        userSaved.BillingProvince = BillingPro.SelectedValue;
        userSaved.BillingStreet = BillingStreet.Text.ToString().Trim();
        userSaved.Userpwd = Password.Text;
        userSaved.RegionId = 1;

        int newId = UserBLO.Registration(userSaved);

        if (newId > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                            "err_msg",
                            "alert('success.');", true);
            bind();
            //add To role
        }
    }

    protected void CheckBoxIsSameAddress_Clicked(Object sender, EventArgs e)
    {
        if (checkBoxIsSameAddress.Checked == true)
        {
            BillingHouseNo.Text = ShippingHouseNo.Text.ToString().Trim();
            BillingPostCode.Text = ShippingPostCode.Text.ToString().Trim();
            BillingCity.Text = ShippingCity.Text.ToString().Trim();
            BillingPro.SelectedValue = ShippingPro.SelectedValue;
            BillingStreet.Text = ShippingStreet.Text.ToString().Trim();
            //billingAddressDiv.Visible = false;
        }
        else if (checkBoxIsSameAddress.Checked == false)
        {
            BillingHouseNo.Text = null;
             BillingPostCode.Text = null;
            BillingCity.Text = null;
            BillingPro.SelectedValue = "";
            BillingStreet.Text = null;
            billingAddressDiv.Visible = true;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = UserBLO.GetAllUsers();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            if (((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text.ToString().Trim() == "0")
            {
                ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text = "Inactive";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("activeButton")).Text = "Active";

            }
            else if (((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text.ToString().Trim() == "1")
            {
                ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text = "Active";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("activeButton")).Text = "Inactive";
            }
        }
    }

    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }
}
