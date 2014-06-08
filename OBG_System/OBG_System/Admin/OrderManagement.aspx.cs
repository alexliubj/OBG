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
using System.IO;

public partial class Admin_Default : System.Web.UI.Page
{
    private DataSet orderDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1_Bind();
        }
    }

    #region Order
    public void GridView1_Bind()
    {

        DataTable orderTable = OrderBLO.GetAllOrder();
        orderDataSet = new DataSet();
        orderDataSet.Tables.Add(orderTable);

        GridView1.DataSource = orderDataSet;
        GridView1.DataKeyNames = new string[] { "OrderId" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        OrderBLO.RemoveOrderByOrderId(orderID);
        GridView1_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1_Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1_Bind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = OrderBLO.GetAllOrder();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int orderID;

        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);

        GridView2_Bind(orderID);

        divOrderDetail.Visible = true;
    }

    #endregion

    #region OrderDetail
    public void GridView2_Bind(int orderID)
    {

        DataTable orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        GridView2.DataSource = orderDetailTable;
        GridView2.DataKeyNames = new string[] { "OrderId" };
        GridView2.DataBind();
    }

    //protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    //{
        
    //    //DataTable dataTable = ;

    //    if (dataTable != null)
    //    {
    //        DataView dataView = new DataView(dataTable);
    //        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

    //        GridView2.DataSource = dataView;
    //        GridView2.DataBind();
    //    }
    //}

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
    }

    #endregion


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