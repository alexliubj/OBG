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
using System.Text.RegularExpressions;

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
        GridView1.DataKeyNames = new string[] { "UserId" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Gridview1_Bind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        //DiscountBLO.DeleteDiscount(userID);
        //Gridview1_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int userID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        Discount discount = new Discount();
        discount.UserId = userID;
        //discount.RoleName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBox2"))).Text.ToString().Trim();
        //discount.DiscountRate = (float)Convert.ToDouble(((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBox3"))).Text.ToString().Trim());
        string disrate = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[0].FindControl("TextBox3"))).Text.ToString().Trim();
        //discount.DiscountRate = (float)double.Parse(disrate.Replace("%", "")) / 100;
        Match mtch = Regex.Match(disrate, @"-?\d+(\.\d{1,x})?");
        if (mtch.Success)
        {
            discount.DiscountRate = (float)double.Parse(disrate);

            DiscountBLO.UpdateDiscount(discount.UserId, discount.DiscountRate);

            GridView1.EditIndex = -1;
            Gridview1_Bind();
        }
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Gridview1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = DiscountBLO.GetAllDiscount();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
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