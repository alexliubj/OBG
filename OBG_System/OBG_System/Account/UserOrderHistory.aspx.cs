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
    int userId = 0;
    Order order = new Order();
    OrderLine line = new OrderLine();
    List<OrderLine> orderine = new List<OrderLine>();
    int orderID = 0;
    DataTable orderDetailTable;
    string statusLabel = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (int)Session["UserID"];
        if (!IsPostBack)
        {

            for (int i = 0; i < OrderGridView.Rows.Count; i++)
            {


                line.ProductId = int.Parse(((Label)OrderGridView.Rows[i].Cells[1].FindControl("LBProductID")).Text.ToString()); ;
                line.PartNO = ((Label)OrderGridView.Rows[i].Cells[3].FindControl("Label5")).Text.ToString(); ;
                line.DiscountRate = float.Parse(((Label)OrderGridView.Rows[i].Cells[5].FindControl("Label6")).Text.Substring(1).ToString());
                line.ProductName = ((Label)OrderGridView.Rows[i].Cells[3].FindControl("Label8")).Text.ToString();
                line.Qty = int.Parse(((TextBox)OrderGridView.Rows[i].Cells[4].FindControl("TextBox4")).Text.ToString());
                orderine.Add(line);
            }

            Gridview1_Bind();
            
        }

       
    }

    
    public void Gridview1_Bind()
    {

        DataTable order = OrderBLO.GetAllOrderByUserId(userId);
        orderDataSet = new DataSet();
        orderDataSet.Tables.Add(order);

        GridView1.DataSource = orderDataSet;
        GridView1.DataKeyNames = new string[] { "OrderId" };
        GridView1.DataBind();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string status = ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label5"))).Text.ToString().Trim();
            

            switch (status)
            {
                case "0":
                    statusLabel = "Incomplete";
                    break;
                case "1":
                    statusLabel = "Pending";
                    //updatebutton.Visible = true;
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
            ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label5"))).Text = statusLabel;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);

        GridView2_Bind(orderID);

        divOrderDetail.Visible = true;
    }
   
    public void GridView2_Bind(int orderID)
    {

        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);
        statusLabel = ((Label)(GridView1.SelectedRow.Cells[3].FindControl("Label5"))).Text;
        if (statusLabel == "Pending")
        {
            updatebutton.Visible = true; 
        }

        OrderGridView.DataSource = orderDetailTable;
        OrderGridView.DataKeyNames = new string[] { "OrderId" };
        OrderGridView.DataBind();
        Populacontorl(orderID);
    }

   

    protected void LBUpdate_Click(object sender, EventArgs e)
    {
        //int orderID = 0;
        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        int rowCount;
        rowCount = OrderGridView.Rows.Count;
        GridViewRow ViewCart;
        TextBox productQuatity;

        for (int i = 0; i < rowCount; i++)
        {
            ViewCart = OrderGridView.Rows[i];
            //int strProductID = int.Parse(OrderGridView.SelectedRow.Cells[1].Text);
            int strProductID = int.Parse(((Label)(OrderGridView.Rows[i].Cells[1].FindControl("LBProductID"))).Text.ToString());
            productQuatity = (TextBox)ViewCart.FindControl("TextBox4");
            OrderBLO.UpdateQtybyProid(strProductID, Convert.ToInt32(productQuatity.Text));

             //   return;
        }

        Populacontorl(orderID);
    }

    protected void Populacontorl(int orderID)
    {
        //orderID = int.Parse(OrderGridView.SelectedRow.Cells[0].Text);
        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);
        decimal tatil = 0;
        decimal HST = 0;
        decimal totalPrice = 0;
        decimal hst = (Decimal)(0.13);
        foreach (DataRow row in orderDetailTable.Rows)
        {
            tatil += decimal.Parse(row["DiscountRate"].ToString()) * int.Parse(row["Qty"].ToString());
            HST += decimal.Parse(row["DiscountRate"].ToString()) * int.Parse(row["Qty"].ToString()) * hst;
            totalPrice = tatil + HST;
        }
        lblTatil.Text = string.Format("${0:n2}", tatil);
        Label2.Text = string.Format("${0:n2}", HST);
        Label7.Text = string.Format("${0:n2}", totalPrice);
        OrderGridView.DataSource = orderDetailTable;
        OrderGridView.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        statusLabel = ((Label)(GridView1.SelectedRow.Cells[3].FindControl("Label5"))).Text;
        if (statusLabel == "Pending")
        {

            if (orderDetailTable != null)
            {
                
                int pId = Convert.ToInt32(((Label)(OrderGridView.Rows[e.RowIndex].Cells[1].FindControl("LBProductID"))).Text.ToString());
                int orderConfirm = OrderBLO.DeleteProductById(pId);
                GridView2_Bind(orderID);
               
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('You cannot modify your order after pending');</script>");
        }

    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        

        Response.Redirect("~/Default.aspx");
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        // DataTable dataTable = TiresBLO.GetAllTires();
        DataTable order = OrderBLO.GetAllOrderByUserId(userId);
        if (order != null)
        {
            DataView dataView = new DataView(order);
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        Gridview1_Bind();
    }
}