using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;

public partial class Default2 : System.Web.UI.Page
{
    private DataSet orderDataSet;
    int userID = 0;
    ShopingCart sc = new ShopingCart();
    List<ShopingCart> shoppingcart = new List<ShopingCart>();
    DataTable checkoutTB = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            userID = (int)Session["userID"];
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        shoppingcart = (List<ShopingCart>)Session["Cart"];
        checkoutTB.Columns.Add("ProductId");
        checkoutTB.Columns.Add("ProductType");
        checkoutTB.Columns.Add("PartNo");
        checkoutTB.Columns.Add("Image");
        checkoutTB.Columns.Add("qty");
        checkoutTB.Columns.Add("Price");
        if ((List<ShopingCart>)Session["Cart"] == null)
        {
            Response.Write("~/Account/ShoppingCart.aspx");
        }

        else
        {

            for (int i = 0; i < shoppingcart.Count; i++)
            {
                sc = shoppingcart[i];
                DataRow checkoutRow = checkoutTB.NewRow();
                if (sc.ProductId != 0)
                {
                    checkoutRow["ProductId"] = sc.ProductId.ToString();
                    checkoutRow["ProductType"] = "0";
                }
                if (sc.TireId != 0)
                {
                    checkoutRow["ProductId"] = sc.TireId.ToString();
                    checkoutRow["ProductType"] = "1";
                }
                if (sc.AccId != 0)
                {
                    checkoutRow["ProductId"] = sc.AccId.ToString();
                    checkoutRow["ProductType"] = "2";
                }
                checkoutRow["Image"] = sc.Image;
                checkoutRow["PartNo"] = sc.PartNo.ToString();
                checkoutRow["Price"] = sc.Pricing.ToString();
                checkoutRow["qty"] = sc.Qty.ToString();
                checkoutTB.Rows.Add(checkoutRow);

            }
        }

        if (!IsPostBack)
        {
            GridView1_Bind();
        }
    }
    public void GridView1_Bind()
    {
        CKGridView.DataSource = checkoutTB;
        CKGridView.DataKeyNames = new string[] { "ProductId" };
        CKGridView.DataBind(); 
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        CKGridView.EditIndex = e.NewEditIndex;
        GridView1_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int orderID = Convert.ToInt32(CKGridView.DataKeys[e.RowIndex].Value.ToString());
        OrderBLO.RemoveOrderByOrderId(orderID);
        GridView1_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        CKGridView.EditIndex = -1;
        GridView1_Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        CKGridView.EditIndex = -1;
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
        CKGridView.PageIndex = e.NewPageIndex;
        GridView1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = OrderBLO.GetAllOrder();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            CKGridView.DataSource = dataView;
            CKGridView.DataBind();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int orderID;

        orderID = int.Parse(CKGridView.SelectedRow.Cells[0].Text);

        GridView2_Bind(orderID);

        //divOrderDetail.Visible = true;
    }

    protected void ddlSelectOrderStatus_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow gdv = (GridViewRow)ddl.NamingContainer;
        int index = gdv.RowIndex;

        if (((DropDownList)(CKGridView.Rows[index].FindControl("ddlSelectOrderStatus"))).SelectedValue.ToString() != "Please select")
        {
            int orderID, status;

            orderID = int.Parse((((Label)(CKGridView.Rows[index].FindControl("LabelOrderID"))).Text));

            status = int.Parse((((DropDownList)(CKGridView.Rows[index].FindControl("ddlSelectOrderStatus"))).SelectedValue.ToString()));

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


    #region OrderDetail
    public void GridView2_Bind(int orderID)
    {

        DataTable orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        CKGridView.DataSource = orderDetailTable;
        CKGridView.DataKeyNames = new string[] { "OrderId" };
        CKGridView.DataBind();
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

    protected void CKGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CKGridView.PageIndex = e.NewPageIndex;
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

    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
        Order OrderSaved = new Order();
        OrderLine orderLine = new OrderLine();
        //int userID;
        //int orderId;
        //userID = int.Parse(CKGridView.SelectedRow.Cells[0].Text);
        OrderSaved.UserId = int.Parse(CKGridView.SelectedRow.Cells[0].Text);
        OrderSaved.OrderId = int.Parse(CKGridView.SelectedRow.Cells[1].Text);
        orderLine.ProductId = int.Parse(CKGridView.SelectedRow.Cells[2].Text);
        orderLine.PartNO = CKGridView.SelectedRow.Cells[3].Text;
        orderLine.ProductName = CKGridView.SelectedRow.Cells[4].Text;
        orderLine.ProductType = int.Parse(CKGridView.SelectedRow.Cells[5].Text);
        orderLine.Qty = int.Parse(CKGridView.SelectedRow.Cells[6].Text);
        orderLine.DiscountRate = int.Parse(CKGridView.SelectedRow.Cells[7].Text);

    }
}