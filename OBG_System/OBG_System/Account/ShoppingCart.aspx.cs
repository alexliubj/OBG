using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess;
using BusinessLogic;
using OBGModel;

public partial class Account_ShoppingCart : System.Web.UI.Page
{
    Order order = new Order();
    OrderLine orderline = new OrderLine();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            
            string strProductID = Request.QueryString["ProductID"];
            string strNum = Request.QueryString["Num"];
            ViewState["UpPage"] = Request.RawUrl.ToString();
            
            //DataTable dt = ShoppingCartAccess.GetItem();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["ProductID"].ToString() == strProductID)
            //    {
            //        Response.Write("<script>alert('You brought【"+dr["ProductName"]+"】，just update quantity！！')</script>");
            //        Populacontorl();
            //        return;
            //    }
            ////}
            //if (strProductID != null && strNum == "1")
            //{
            //    OrderBLO.AddNewOrder(strProductID, lisht<OBGModel.OrderLine>);
            //    Response.Redirect("ShoppingCart.aspx" + "?ProductID=" + strProductID);
            //}
            //Populacontorl();
        }
    }


    protected void LBUpdate_Click(object sender, EventArgs e)
    {

    }
    protected void LBRepost_Click(object sender, EventArgs e)
    {

    }
    protected void IBTatil_Click(object sender, ImageClickEventArgs e)
    {

    }
}