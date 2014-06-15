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

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string status = ((Label)(GridView1.Rows[i].Cells[3].FindControl("Label5"))).Text.ToString().Trim();
            string statusLabel = "";

            switch (status)
            {
                case "0":
                    statusLabel = "Incomplete";
                    break;
                case "1":
                    statusLabel = "Pending";
                    break;
                case "2":
                    statusLabel = "Processed";
                    break;
                case "3":
                    statusLabel = "Partially Shipped";
                    break;
                case "4":
                    statusLabel = "Shipping";
                    break;
                case "5":
                    statusLabel = "Shipped";
                    break;
                case "6":
                    statusLabel = "Partially Returned";
                    break;
                case "7":
                    statusLabel = "Returned";
                    break;
                case "8":
                    statusLabel = "Canceled";
                    break;
                default:
                    statusLabel = "Unknown";
                    break;
            }
            ((Label)(GridView1.Rows[i].Cells[3].FindControl("Label5"))).Text = statusLabel;
        }
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlSelectOrderStatus = (e.Row.FindControl("ddlSelectOrderStatus") as DropDownList);

            string status = (e.Row.FindControl("lblSelectStatus") as Label).Text;

            ddlSelectOrderStatus.Items.Insert(0, new ListItem("Please select"));

            ddlSelectOrderStatus.Items.FindByValue(status).Selected = true;
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (GridView1.SelectedIndex > -1)
        {
            GridView1.SelectedIndex = -1;
        }
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

    protected void ddlSelectOrderStatus_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow gdv = (GridViewRow)ddl.NamingContainer;
        int index = gdv.RowIndex;

        if (((DropDownList)(GridView1.Rows[index].FindControl("ddlSelectOrderStatus"))).SelectedValue.ToString() != "Please select")
        {
            int orderID, status;

            orderID = int.Parse((((Label)(GridView1.Rows[index].FindControl("LabelOrderID"))).Text));

            status = int.Parse((((DropDownList)(GridView1.Rows[index].FindControl("ddlSelectOrderStatus"))).SelectedValue.ToString()));

            int update = 0;
            update = OrderBLO.UpdateOrderStatus(orderID, status);
            if (update > 0)
            {
                GridView1_Bind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                       "err_msg",
                                       "alert('Changing status failed.');",
                                       true);
            }
        }
    }
    #endregion

    #region OrderDetail
    public void GridView2_Bind(int orderID)
    {

        DataTable orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        GridView2.DataSource = orderDetailTable;
        GridView2.DataKeyNames = new string[] { "OrderId" };
        GridView2.DataBind();
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            string productType = ((Label)(GridView2.Rows[i].Cells[3].FindControl("Label5"))).Text.ToString().Trim();
            string productTypeLabel = "";

            switch (productType)
            {
                case "1":
                    productTypeLabel = "Wheel";
                    break;
                case "2":
                    productTypeLabel = "Tire";
                    break;
                case "3":
                    productTypeLabel = "Accessory";
                    break;
                default:
                    productTypeLabel = "Unknown";
                    break;
            }
            ((Label)(GridView2.Rows[i].Cells[3].FindControl("Label5"))).Text = productTypeLabel;
        }
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

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView1.PageIndex = 0;
        GridView1_Bind();
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }
}