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
    List<OrderLine> orderLine = new List<OrderLine>();
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
            ((Label)(GridView1.Rows[i].Cells[2].FindControl("Label5"))).Text = statusLabel;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int orderID;

        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);

        GridView2_Bind(orderID);

        divOrderDetail.Visible = true;
    }
    //protected void DataListOrder_ItemCommand(object source, DataListCommandEventArgs e)
    //{
    //    OrderGridView.DataSource = OrderBLO.GetOrderLineByOrderId(int.Parse(e.CommandArgument.ToString())); 
    //    OrderGridView.DataBind();
    //    OrderGridView.Visible = true;
    //}
    public void GridView2_Bind(int orderID)
    {

        DataTable orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        OrderGridView.DataSource = orderDetailTable;
        OrderGridView.DataKeyNames = new string[] { "OrderId" };
        OrderGridView.DataBind();
    }

    protected void LBUpdate_Click(object sender, EventArgs e)
    {
        int rowCount;
        rowCount = OrderGridView.Rows.Count;
        GridViewRow ViewCart;
        TextBox productQuatity;

        for (int i = 0; i < rowCount; i++)
        {
            ViewCart = OrderGridView.Rows[i];
            int strProductID = int.Parse(OrderGridView.DataKeys[i].Value.ToString());
            productQuatity = (TextBox)ViewCart.FindControl("TextBox4");
            OrderBLO.UpdateQtybyProid(strProductID, Convert.ToInt32(productQuatity.Text));

                return;
        }
        Populacontorl();
    }

    protected void Populacontorl()
    {
        DataTable shopData = OrderBLO.GetAllOrderByUserId(userId);
        decimal tatil = 0;
        foreach (DataRow row in shopData.Rows)
        {
            tatil += decimal.Parse(row["DiscountRate"].ToString()) * decimal.Parse(row["Qty"].ToString());
        }
        lblTatil.Text = string.Format("{0:n2}", tatil);
        OrderGridView.DataSource = shopData;
        OrderGridView.DataBind();
    }
   
}