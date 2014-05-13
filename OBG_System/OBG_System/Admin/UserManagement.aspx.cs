﻿using System;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
            for(int i = 0; i <GridView1.Rows.Count; i++ )
            {
                if (((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text.ToString().Trim() == "0")
                {
                    ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text = "inactive";
                }
                else if (((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text.ToString().Trim() == "1")
                {
                    ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label3"))).Text = "active";
                }
            }
        }
        
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
        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        User user = UserBLO.GetUserInfoWithUserId(userID);
        user.Userid = userID;
        user.UserName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString().Trim();
        DropDownList ddl = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1"));
        if (ddl.SelectedItem.Text == "active")
        {
            user.Status = 1;
        }
        else if (ddl.SelectedItem.Text == "inactive")
        {
            user.Status = 0;
        }
        user.Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text.ToString().Trim();
        user.CompanyName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("TextBox5"))).Text.ToString().Trim();
        user.Phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("TextBox1"))).Text.ToString().Trim();
        UserBLO.UpdateUserInfo(user);

        GridView1.EditIndex = -1;
        bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }

    public void bind()
    {
        DataTable usersTable = UserBLO.GetAllUsers();
        userDataSet = new DataSet();
        userDataSet.Tables.Add(usersTable);

        GridView1.DataSource = userDataSet;
        GridView1.DataKeyNames = new string[] { "userid" };
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
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
        ShippingAddress.Text = user.ShippingAddress;
        ShippingPostCode.Text = user.ShippingPostCode;
        BillingAddress.Text = user.BillAddress;
        BillingPostCode.Text = user.BillPostCode;
        userInformation.Visible = true;
    }
    protected void activeButton_Click(object sender, EventArgs e)
    {
        int userID = Convert.ToInt32(GridView1.SelectedValue.ToString());
        UserBLO.AdminActiveUser(userID);
        Response.Redirect("UserManagement.aspx");
    }
}