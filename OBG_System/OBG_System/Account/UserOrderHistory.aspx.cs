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
    List<OrderLine> orderine = new List<OrderLine>();
    int orderID = 0;
    DataTable orderDetailTable;
    string statusLabel = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (int)Session["UserID"];
        if (!IsPostBack)
        {
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
        foreach (DataRow row in orderDetailTable.Rows)
        {
            tatil += decimal.Parse(row["DiscountRate"].ToString()) * int.Parse(row["Qty"].ToString());
        }
        lblTatil.Text = string.Format("{0:n2}", tatil);
        OrderGridView.DataSource = orderDetailTable;
        OrderGridView.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //wheelInformation.Visible = false;
        //orderine = (List<OrderLine>)Session["orderline"];
        //int ProId = Convert.ToInt32(((Label)(OrderGridView.Rows[i].Cells[1].FindControl("LBProductID"))).Text.ToString());
        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        statusLabel = ((Label)(GridView1.SelectedRow.Cells[3].FindControl("Label5"))).Text;
        if (statusLabel == "Pending")
        {

            if (orderDetailTable != null)
            {
                //DataTable dt = Session["GoodsCart"] as DataTable;
                //for (int i = 0; i < orderDetailTable.Rows.Count; i++)
                //{
                int pId = Convert.ToInt32(((Label)(OrderGridView.Rows[e.RowIndex].Cells[1].FindControl("LBProductID"))).Text.ToString());
                int orderConfirm = OrderBLO.DeleteProductById(pId);
                GridView2_Bind(orderID);
                // }
                //Session["GoodsCart"] = orderDetailTable;
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('You cannot modify your order after pending');</script>");
        }
        //if (Session["orderline"] != null)
        //{
        //    orderine = (List<OrderLine>)Session["orderline"];
        //    orderine.RemoveAt(e.RowIndex);
        //    //shoppingcart.AcceptChanges();
        //    Session["orderline"] = orderine;
        //    Response.Redirect("ShoppingCart.aspx");
        //}
        //orderine.Add(orderDetailTable);
        //OrderGridView.DataSource = orderDetailTable;
        //OrderGridView.DataBind();
        //int ProductID = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text.ToString());
        //DataTable orderline = OrderBLO.ModifyOneOrder(order)
        //OrderGridView.DataSource = orderline;
        //GridView2_Bind(orderID);
        //Populacontorl(orderID);
    }

    protected void Confirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}