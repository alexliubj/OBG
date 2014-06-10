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
    public static int userID;
    ShopingCart sc = new ShopingCart(); 
    List<ShopingCart> shoppingcart = new List<ShopingCart>();
    DataTable shoppingcarttb = new DataTable();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            userID = (int)Session["UserID"];
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        shoppingcart = (List<ShopingCart>)Session["Cart"];
        
        shoppingcarttb.Clear();
        shoppingcarttb.Columns.Add("ProductId");
        //shoppingcarttb.Columns.Add("TireId");
       // shoppingcarttb.Columns.Add("AccId");
        shoppingcarttb.Columns.Add("ProductType");
        shoppingcarttb.Columns.Add("PartNo");
        shoppingcarttb.Columns.Add("Image");
        shoppingcarttb.Columns.Add("Quantity");
        shoppingcarttb.Columns.Add("Price");

        for (int i = 0; i < shoppingcart.Count; i++)
        {
            sc = shoppingcart[i];
            DataRow scRow = shoppingcarttb.NewRow();
            if (sc.ProductId != 0)
            {
                scRow["ProductId"] = sc.ProductId.ToString();
                scRow["ProductType"] = "0";
            }
            if (sc.TireId != 0)
            {
                scRow["ProductId"] = sc.TireId.ToString();
                scRow["ProductType"] = "1";
            }
            if (sc.AccId != 0)
            {
                scRow["ProductId"] = sc.AccId.ToString();
                scRow["ProductType"] = "2";
            }
            scRow["Image"] = sc.Image;
            scRow["PartNo"] = sc.PartNo.ToString();
            scRow["Price"] = sc.Pricing.ToString();
            scRow["Quantity"] = sc.Qty.ToString();


        }

        if (!IsPostBack)
        {


            ShoppingCartGridView_DataBind();
           
        }
    }

    //public void Bind()
    //{
    //    if (Session["Cart"] != null)
    //    {
    //        DataTable dt = Session["Cart"] as DataTable;
    //        ShoppingCartGridView.DataSource = dt;
    //        ShoppingCartGridView.DataBind();
    //        //if (dt.Rows.Count == 0)
    //        //{
    //        //    money = 0.0f;
    //        //    M_str_Count = money.ToString();
    //        //}
    //    }
    //}





    public void ShoppingCartGridView_DataBind()
    {

        ShoppingCartGridView.DataSource = shoppingcarttb;
        ShoppingCartGridView.DataKeyNames = new string[] { "ProductId" };
        ShoppingCartGridView.DataBind();
            //ShoppingCartGridView.Rows.Count = shoppingcart.Count;
           
    }
    protected void ShoppingCartGridView_EditingBound(object sender, GridViewRowEventArgs e)
    {
        
        

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