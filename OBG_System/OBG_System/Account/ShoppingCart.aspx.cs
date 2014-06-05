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
    //protected System.Web.UI.WebControls.DataGrid ShoppingCartDlt;
    //protected System.Web.UI.WebControls.Button update;
    //protected System.Web.UI.WebControls.Button CheckOut;
    //protected System.Web.UI.HtmlControls.HtmlForm Form1;
    //protected System.Web.UI.WebControls.Label label;
    //protected System.Web.UI.WebControls.CheckBox chkProductID;
    //protected System.Web.UI.WebControls.TextBox txtCount;
    //protected System.Web.UI.WebControls.TextBox CountTb;
    //string AddProID; 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["login"] != "yes" || Session["username"] == null)
            {
                Response.Redirect("error.htm");
            }
        }
        catch
        {
            Response.Redirect("error.htm");
        } 
        if (!IsPostBack)
        {
            //Gridview1_Bind();

        }
    }







    public void Gridview1_Bind()
    {
        //List<ShopingCart> shoppingcart = new List<ShopingCart>();
        //ShopingCart sc = new ShopingCart();
        //shoppingcart = (List<ShopingCart>)Session["Cart"];
        //for (int i = 0; i <= ShoppingCartGridView.Rows.Count; i++)
        //{
        //    sc = shoppingcart[i];
        //    ((Label)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("ProductNameLable"))).Text = sc.ProductId.ToString();
        //}

    }

    protected void IBTCheckout_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect("~/ShoppingCart.aspx?ProductID=" + strProductID + "&Num=1");
    }
    protected void LBRepost_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
    protected void ShoppingCartGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            List<ShopingCart> shoppingcart = new List<ShopingCart>();
            ShopingCart sc = new ShopingCart();
            shoppingcart = (List<ShopingCart>)Session["Cart"];
            for (int i = 0; i <= ShoppingCartGridView.Rows.Count; i++)
            {
                sc = shoppingcart[i];
                ((Label)(e.Row.FindControl("ProductNameLable"))).Text = sc.ProductId.ToString();
            }
        }
    }
}