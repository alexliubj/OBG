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
    private DataSet wheelsDataSet;
    private DataSet tiresDataSet;
    private DataSet accessoriesDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridview1_Bind();
            GridView2_Bind();
            GridView3_Bind();
        }
    }
    #region Gridview1
    public void Gridview1_Bind()
    {

        DataTable wheelsTable = WheelsBLO.GetAllProducts();
        wheelsDataSet = new DataSet();
        wheelsDataSet.Tables.Add(wheelsTable);

        GridView1.DataSource = wheelsDataSet;
        GridView1.DataKeyNames = new string[] { "ProductId" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Gridview1_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int productID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        WheelsBLO.DeleteProductById(productID);
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

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Gridview2
    public void GridView2_Bind()
    {

        DataTable tiresTable = TiresBLO.GetAllTires();
        tiresDataSet = new DataSet();
        tiresDataSet.Tables.Add(tiresTable);

        GridView2.DataSource = tiresDataSet;
        GridView2.DataKeyNames = new string[] { "TireId" };
        GridView2.DataBind();
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        GridView2_Bind();

    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int TireID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        TiresBLO.DeleteTire(TireID);
        GridView2_Bind();
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        GridView2.EditIndex = -1;
        GridView2_Bind();
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        GridView2_Bind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region Gridview3
    public void GridView3_Bind()
    {

        DataTable accessoriesTable = AccessoryBLO.GetAllAccessories();
        accessoriesDataSet = new DataSet();
        accessoriesDataSet.Tables.Add(accessoriesTable);

        GridView3.DataSource = accessoriesDataSet;
        GridView3.DataKeyNames = new string[] { "AccId" };
        GridView3.DataBind();
    }

    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        GridView3_Bind();

    }

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int AccID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        AccessoryBLO.DeleteOneAccessory(AccID);
        GridView3_Bind();
    }

    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        GridView3.EditIndex = -1;
        GridView3_Bind();
    }

    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        GridView3_Bind();
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion


    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Wheels")
        {
            GridView1.Visible = true;
            GridView2.Visible = false;
            GridView3.Visible = false;
        }
        if (e.Item.Text == "Tires")
        {
            GridView2.Visible = true;
            GridView1.Visible = false;
            GridView3.Visible = false;
        }
        if (e.Item.Text == "Accessories")
        {
            GridView3.Visible = true;
            GridView1.Visible = false;
            GridView2.Visible = false;
        }

    }
}