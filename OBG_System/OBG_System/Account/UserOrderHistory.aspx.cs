using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class Default2 : System.Web.UI.Page
{
    private DataSet orderDataSet;
    int userId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (int)Session["UserID"];
        if (!IsPostBack)
        {
            //Gridview1_Bind();
            DataListOrder.DataSource = OrderBLO.GetAllOrder();
            DataListOrder.DataBind();
            //lblTatil.Text = string.Format("{0:c}", OrderAccess.GetAllTatil());
        }

       
    }
    public void Gridview1_Bind()
    {

        DataTable order = OrderBLO.GetAllOrderByUserId(userId);
        orderDataSet = new DataSet();
        orderDataSet.Tables.Add(order);

        OrderGridView.DataSource = orderDataSet;
        OrderGridView.DataKeyNames = new string[] { "OrderId" };
        OrderGridView.DataBind();


    }
    protected void DataListOrder_ItemCommand(object source, DataListCommandEventArgs e)
    {
        OrderGridView.DataSource = OrderBLO.GetOrderLineByOrderId(int.Parse(e.CommandArgument.ToString())); 
        OrderGridView.DataBind();
    }
}