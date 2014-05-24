using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Default : System.Web.UI.Page
{
    DataSet rolesDataSet;
    DataSet userRolesDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Gridview1_Bind();
            Gridview2_Bind();
        }
    }

    #region Role
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Role role = new Role();
        int roleID;
        roleID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        role.RoleName = RoleName.Text;
        role.Des = Des.Text;

        int update = 0;
        update = RoleBLO.ModifyRoleName(roleID, role.RoleName, role.Des);

        if (update == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Role has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Role information failed.');",
                        true);
        }
        Gridview1_Bind();
    }
    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        roleInformation.Visible = false;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int roleID;
        roleID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        Role role = new Role();

        RoleName.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label2"))).Text;
        Des.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label3"))).Text;

        roleInformation.Visible = true;

        BtnAdd.Visible = false;
        BtnSave.Visible = true;
    }
    protected void btnAddRole_Click(object sender, EventArgs e)
    {
        RoleName.Text = null;
        Des.Text = null;

        roleInformation.Visible = true;

        BtnAdd.Visible = true;
        BtnSave.Visible = false;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Role role = new Role();

        role.RoleName = RoleName.Text;
        role.Des = Des.Text;

        int update = 0;
        update = RoleBLO.AddNewRole(role);

        if (update == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Role has been created.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Creating Role information failed.');",
                        true);
        }
        Gridview1_Bind();
    }


    public void Gridview1_Bind()
    {

        DataTable rolesTable = RoleBLO.GetAllRoleList();
        rolesDataSet = new DataSet();
        rolesDataSet.Tables.Add(rolesTable);

        GridView1.DataSource = rolesDataSet;
        GridView1.DataKeyNames = new string[] { "RoleId" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Gridview1_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int roleID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        RoleBLO.DeleteOneRoleById(roleID);
        Gridview1_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // int productID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        // //get product by ID
        //// Wheels wheels = WheelsBLO
        // user.Userid = userID;
        // user.UserName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString().Trim();
        // DropDownList ddl = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1"));
        // if (ddl.SelectedItem.Text == "active")
        // {
        //     user.Status = 1;
        // }
        // else if (ddl.SelectedItem.Text == "inactive")
        // {
        //     user.Status = 0;
        // }
        // user.Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text.ToString().Trim();
        // user.CompanyName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("TextBox5"))).Text.ToString().Trim();
        // user.Phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("TextBox1"))).Text.ToString().Trim();
        // UserBLO.UpdateUserInfo(user);

        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    #endregion


    #region UserRole
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void Gridview2_Bind()
    {

        DataTable userRolesTable = RoleBLO.GetAllUsersWithRole();
        userRolesDataSet = new DataSet();
        userRolesDataSet.Tables.Add(userRolesTable);

        GridView2.DataSource = userRolesDataSet;
        GridView2.DataKeyNames = new string[] { "Uid" };
        GridView2.DataBind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlSelectRoleName = (e.Row.FindControl("ddlSelectRoleName") as DropDownList);

            DataTable rolesTable = RoleBLO.GetAllRoleList();
            rolesDataSet = new DataSet();
            rolesDataSet.Tables.Add(rolesTable);

            ddlSelectRoleName.DataSource = rolesDataSet;
            ddlSelectRoleName.DataTextField = "RoleName";
            ddlSelectRoleName.DataValueField = "RoleID";
            ddlSelectRoleName.DataBind();

            ddlSelectRoleName.Items.Insert(0, new ListItem("Please select"));

            string roleID = (e.Row.FindControl("lblSelectRoleID") as Label).Text;
            ddlSelectRoleName.Items.FindByValue(roleID).Selected = true;
        }
    }

    protected void ddlSelectRoleName_Change(object sender, EventArgs e)
    {
        // DropDownList ddlSelectRoleName = (GridView2.FindControl("ddlSelectRoleName") as DropDownList);
        //string roleID = ddlSelectRoleName.SelectedValue;
        // RoleBLO.
        //TBA

        DropDownList ddl = (DropDownList)sender;
        GridViewRow gdv = (GridViewRow)ddl.NamingContainer;
        int index = gdv.RowIndex;

        int userID, roleID;
        string des;
        userID = int.Parse((((Label)(GridView2.Rows[index].FindControl("Label3"))).Text));
        roleID = int.Parse((((DropDownList)(GridView2.Rows[index].FindControl("ddlSelectRoleName"))).SelectedValue.ToString()));
        //des = (((Label)(GridView2.Rows[index].FindControl("Label5"))).Text);
        int update = 0;
        update = RoleBLO.UpdateUserRole(userID, roleID);
        if (update > 0)
        {
            Gridview2_Bind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                   "err_msg",
                                   "alert('Sorry, Changing role for user failed.');",
                                   true);
        }
    }
    #endregion

    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Role Management")
        {
            roleManagement.Visible = true;
            userRoleManagement.Visible = false;
        }
        if (e.Item.Text == "UserRole Management")
        {
            roleManagement.Visible = false;
            userRoleManagement.Visible = true;
        }
    }
}