using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using BusinessLogic;
using OBGModel;
using System.Data;

public partial class Account_ShoppingCart : System.Web.UI.Page
{
    string strProductID = "";
    private DataSet ShoppingDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShoppingCartGridView_Bind();
        }
    }
    public void ShoppingCartGridView_Bind()
    {

        //DataTable ShoppingTable = OrderBLO.get;

    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }

    //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int TireID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
    //    TiresBLO.DeleteTire(TireID);
    //    GridView2_Bind();
    //}

   
    protected void IBTCheckout_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/ShoppingCart.aspx?ProductID=" + strProductID + "&Num=1");
    }
    protected void LBRepost_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

}