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

        if (!Page.IsPostBack)
        {
            MenuItem ms = NavigationMenu.FindItem("Role Management");
            ms.Selected = true;

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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (GridView1.SelectedIndex > -1)
        {
            GridView1.SelectedIndex = -1;
        }
        Gridview1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = RoleBLO.GetAllRoleList();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
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

        if (((DropDownList)(GridView2.Rows[index].FindControl("ddlSelectRoleName"))).SelectedValue.ToString() != "Please select")
        {
            int userID, roleID;
            //string des;
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
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        if (GridView2.SelectedIndex > -1)
        {
            GridView2.SelectedIndex = -1;
        }
        Gridview2_Bind();
    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = RoleBLO.GetAllUsersWithRole();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView2.DataSource = dataView;
            GridView2.DataBind();
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

        MenuItem ms = NavigationMenu.FindItem(e.Item.Text);
        if (ms != null)
        {
            ms.Selected = true;
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

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView1.PageIndex = 0;
        Gridview1_Bind();
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

    protected void dropDownRecordsPerPage2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView2.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView2.PageIndex = 0;
        Gridview2_Bind();
    }

    protected void GridView2_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }
}