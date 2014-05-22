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
using System;

public partial class Admin_Default : System.Web.UI.Page
{
    private DataSet disDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridview1_Bind();
        }
    }

    public void Gridview1_Bind()
    {
        DataTable disTable = DiscountBLO.GetAllDiscount();
        disDataSet = new DataSet();
        disDataSet.Tables.Add(disTable);

        GridView1.DataSource = disDataSet;
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
        DiscountBLO.DeleteDiscount(roleID);
        Gridview1_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int roleID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        Discount discount = new Discount();
        discount.RoleId = roleID;
        //discount.RoleName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBox2"))).Text.ToString().Trim();
        discount.DiscountRate = (float)Convert.ToInt32(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBox3"))).Text.ToString().Trim());

        DiscountBLO.UpdateDiscount(discount.RoleId, discount.DiscountRate);

        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_OnRowCommand1(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName.Equals("Insert"))
        //{
        //    Discount discount = new Discount();
        //    discount.RoleName = ((TextBox)(GridView1.Controls[0].Controls[0].FindControl("TextBox2"))).Text.ToString().Trim();
        //    discount.DiscountRate = (float)Convert.ToInt32(((TextBox)(GridView1.Controls[0].Controls[0].FindControl("TextBox3"))).Text.ToString().Trim());

        //    DiscountBLO.AddDiscount(1,discount.DiscountRate);

        //    Gridview1_Bind();
        //}

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
}