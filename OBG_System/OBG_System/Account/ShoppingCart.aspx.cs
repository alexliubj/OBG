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
    //public List<cartitem> items { get;private;set; };
    //protected System.Web.UI.WebControls.DataGrid ShoppingCartDlt;
    //protected System.Web.UI.WebControls.Button update;
    //protected System.Web.UI.WebControls.Button CheckOut;
    //protected System.Web.UI.HtmlControls.HtmlForm Form1;
    //protected System.Web.UI.WebControls.Label label;
    //protected System.Web.UI.WebControls.CheckBox chkProductID;
    //protected System.Web.UI.WebControls.TextBox txtCount;
    //protected System.Web.UI.WebControls.TextBox CountTb;
    //string AddProID; 
    public static string M_str_Count;
    public float money = 0.0f;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            if (Session["UserID"] != null)
            {
                Bind();
            }
            else
            {
                RegisterStartupScript("", "<script>alert('Please login first！')</script>");
            }
        }
    }

    public void Bind()
    {
        //if (Session["Cart"] != null)
        //{
        //    DataTable dt = Session["Cart"] as DataTable;
        //    dlShoppingCart.DataSource = dt;
        //    dlShoppingCart.DataBind();
        //    if (dt.Rows.Count == 0)
        //    {
        //        money = 0.0f;
        //        M_str_Count = money.ToString();
        //    }
        //}
    }
    //protected void dlShoppingCart_ItemDataBound(object sender, DataListItemEventArgs e)
    //{
    //    TextBox txtGoodsNum = (TextBox)e.Item.FindControl("txtGoodsNum");
    //    Label lblprice = (Label)e.Item.FindControl("labGoodsPrice");
    //    if (txtGoodsNum != null)
    //    {
    //        txtGoodsNum.Attributes["onkeyup"] = "value=value.replace(/[^\\d]/g,'')";
    //        int num = Convert.ToInt32(txtGoodsNum.Text);
    //        float price = Convert.ToSingle(lblprice.Text);
    //        money += num * price;
    //        M_str_Count = money.ToString();
    //    }
    //}
    ////清空购物车
    //protected void lnkbtnClear_Click(object sender, EventArgs e)
    //{
    //    if (Session["Cart"] != null)
    //    {
    //        DataTable dt = Session["Cart"] as DataTable;
    //        dt.Rows.Clear(); ;
    //        Session["Cart"] = dt;
    //    }
    //    Bind();
    //}

    //protected void lnkbtnClear_Load(object sender, EventArgs e)
    //{
    //    //lnkbtnClear.Attributes["onclick"] = "javascript:return confirm('你确定要清空购物车吗？')";
    //}

    //protected void lnkbtnContinue_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Default.aspx");
    //}

    //protected void dlShoppingCart_DeleteCommand(object source, DataListCommandEventArgs e)
    //{
    //    int ProId = Convert.ToInt32(e.CommandArgument.ToString());
    //    if (Session["Cart"] != null)
    //    {
    //        DataTable dt = Session["Cart"] as DataTable;
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            int pId = Convert.ToInt32(dt.Rows[i]["ProId"].ToString());
    //            if (ProId == pId)
    //            {
    //                dt.Rows[i].Delete();
    //                break;
    //            }
    //        }
    //        Session["Cart"] = dt;
    //    }
    //    Bind();
    //}
    ////更新购物车
    //protected void dlShoppingCart_ItemCommand(object source, DataListCommandEventArgs e)
    //{
    //    if (e.CommandName == "updateNum")
    //    {
    //        TextBox txtGoodsNum = (TextBox)e.Item.FindControl("txtGoodsNum");
    //        int ProId = Convert.ToInt32(e.CommandArgument.ToString());
    //        if (Session["Cart"] != null)
    //        {
    //            DataTable dt = Session["Cart"] as DataTable;
    //            for (int i = 0; i < dt.Rows.Count; i++)
    //            {
    //                int pId = Convert.ToInt32(dt.Rows[i]["ProId"].ToString());
    //                if (ProId == pId)
    //                {
    //                    dt.Rows[i]["num"] = txtGoodsNum.Text;
    //                    break;
    //                }
    //            }
    //            Session["Cart"] = dt;
    //        }
    //        Bind();
    //    }
    //}






    public void Gridview1_Bind()
    {
    }
    protected void ShoppingCartGridView_EditingBound(object sender, GridViewRowEventArgs e)
    {
        List<ShopingCart> shoppingcart = new List<ShopingCart>();
        ShopingCart sc = new ShopingCart();
        shoppingcart = (List<ShopingCart>)Session["Cart"];
        for (int i = 0; i <= ShoppingCartGridView.Rows.Count; i++)
        {
            sc = shoppingcart[i];
            ((Label)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("idLabel"))).Text = sc.ProductId.ToString();
            ((Label)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("idLabel"))).Text = sc.TireId.ToString();
            ((Label)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("idLabel"))).Text = sc.AccId.ToString();
            ((Label)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("imageLabel"))).Text = sc.Image;
            ((Label)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("PriceLabel"))).Text = sc.Pricing.ToString();
            ((TextBox)(ShoppingCartGridView.Rows[i].Cells[0].FindControl("txtCount"))).Text = sc.Qty.ToString();
        }

    }

    protected void IBTCheckout_Click(object sender, ImageClickEventArgs e)
    {
        // Response.Redirect("~/ShoppingCart.aspx?ProductID=" + strProductID + "&Num=1");
    }
    //protected void LBRepost_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("~/Default.aspx");
    //}
    //protected void ShoppingCartGridView_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    //{
    //    //int rowindex = Convert.ToInt32(e.CommandArgument);
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        List<ShopingCart> shoppingcart = new List<ShopingCart>();
    //        ShopingCart sc = new ShopingCart();
    //        shoppingcart = (List<ShopingCart>)Session["Cart"];
    //        for (int i = 0; i <= sc.Rows[i].Count; i++)
    //        {
    //            sc = shoppingcart[i];
    //            ((Label)(e.Row.FindControl("ProductNameLable"))).Text = sc.ProductId.ToString();
    //        }
    //    }
    //}
}