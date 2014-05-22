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
    DataTable Cart = new DataTable();
    DataRow dr;
    private const string SESSION_CAR = "Car";
    protected void Page_Load(object sender, EventArgs e)
    {
    }

   // public void AddItem(int pr)

    //    string productId;
    //    if (Session["ShoppingCart"]==null)
    //    {
    //        Cart.Columns.Add(new DataColumn("productid", typeof(string)));
    //        Cart.Columns.Add(new DataColumn("productName", typeof(string)));
    //        Cart.Columns.Add(new DataColumn("productQTY", typeof(string)));
    //        Cart.Columns.Add(new DataColumn("productPrice", typeof(string)));
    //        Session["ShoppingCart"] = Cart;
    //    }
    //    else
    //    {
    //        Cart = (DataTable)Session["ShoppingCart"];
    //    }

    //    if (Request.QueryString["productid"] != null)
    //    {
    //        productId = Request.QueryString["productid"];
    //        addItem(productId);
    //    }
    //   // showItem();
    //}

    //private void addItem(string productId)
    //{
    //    //string pidSql="select Pro"
    //    throw new NotImplementedException();
    //}



    //    if (!IsPostBack)
    //    {
    //        ShoppingCartGridView_Bind();
    //    }
    //}
    //public void ShoppingCartGridView_Bind()
    //{

    //    //DataTable ShoppingTable = OrderBLO.get;

    //}

    //protected void ShoppingCartGridView_RowEditing(object sender, GridViewEditEventArgs e)
    //{


    //}

    ////protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    ////{
    ////    int TireID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
    ////    TiresBLO.DeleteTire(TireID);
    ////    GridView2_Bind();
    ////}


    protected void IBTCheckout_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("~/ShoppingCart.aspx?ProductID=" + strProductID + "&Num=1");
    }
    protected void LBRepost_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

}