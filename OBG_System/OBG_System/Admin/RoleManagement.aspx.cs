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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Gridview1_Bind();
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
        //need method getwheelInfoByProductID
        // wheel = WheelsBLO.getwheelInfoByProductID(productID);

        RoleName.Text = role.RoleName;
        Des.Text = role.Des;

        roleInformation.Visible = true;

        BtnAdd.Visible = false;
        BtnSave.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
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

        RoleBLO.AddNewRole(role);
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
        int Uid;
        Uid = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        UserRole userRole = new UserRole();
        //need method getwheelInfoByProductID
        // wheel = WheelsBLO.getwheelInfoByProductID(productID);
    }

    public void Gridview2_Bind()
    {

       // DataTable userRolesTable = RoleBLO.
        //rolesDataSet = new DataSet();
        //rolesDataSet.Tables.Add(rolesTable);

        GridView2.DataSource = rolesDataSet;
        GridView2.DataKeyNames = new string[] { "Uid" };
        GridView2.DataBind();
    }
    #endregion
}