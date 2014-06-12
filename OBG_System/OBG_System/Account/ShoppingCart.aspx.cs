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
using System.Drawing;

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
    private Int32 Total = 0;
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
        
        //shoppingcarttb.Clear();
        shoppingcarttb.Columns.Add("ProductId");
        //shoppingcarttb.Columns.Add("TireId");
       // shoppingcarttb.Columns.Add("AccId");
        shoppingcarttb.Columns.Add("ProductType");
        shoppingcarttb.Columns.Add("PartNo");
        shoppingcarttb.Columns.Add("Image");
        shoppingcarttb.Columns.Add("Quantity");
        shoppingcarttb.Columns.Add("Price");
        shoppingcarttb.Columns.Add("itemTotal");
        if ((List<ShopingCart>)Session["Cart"] == null)
        {
            Response.Write("~/Account/ShoppingCart.aspx");
        }

        else
        {

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
                scRow["itemTotal"] = sc.Pricing * sc.Qty;
                shoppingcarttb.Rows.Add(scRow);

            }
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
        //foreach (DataRow dr in shoppingcarttb.Rows)
        //{
        //    for(int i=0;i<shoppingcarttb.Columns.Count;i++)
        //    {
        //        Response.Write(dr[i].ToString());
        //    }
        //}
       

        ShoppingCartGridView.DataSource = shoppingcarttb;
        ShoppingCartGridView.DataKeyNames = new string[] { "ProductId" };
        ShoppingCartGridView.DataBind();
            //ShoppingCartGridView.Rows.Count = shoppingcart.Count;
           
    }
    protected void ShoppingCartGridView_EditingBound(object sender, GridViewRowEventArgs e)
    {
        
        

    }

    protected void GridView1_RowDeleting(object sender, GridViewCommandEventArgs  e)
    {
        //wheelInformation.Visible = false;

        int ProId = Convert.ToInt32(e.CommandArgument.ToString());
        if (Session["Cart"] != null)
        {
            //DataTable dt = Session["GoodsCart"] as DataTable;
            for (int i = 0; i < shoppingcarttb.Rows.Count; i++)
            {
                int pId = Convert.ToInt32(shoppingcarttb.Rows[i]["ProductId"].ToString());
                if (ProId == pId)
                {
                    //shoppingcarttb.Rows[i].d;
                }
            }
            Session["GoodsCart"] = shoppingcarttb;
        }
        ShoppingCartGridView_DataBind();
    }

    protected void ShoppingCart_ItemDataBound(object sender, GridViewCommandEventArgs e)
    {
        int rowindex = Convert.ToInt32(e.CommandArgument);
        //用来实现数量文本框中只能输入数字
        int txtQty = Convert.ToInt32(((TextBox)ShoppingCartGridView.Rows[rowindex].FindControl("txtCount")).Text);
        float lblPrice = Convert.ToSingle(((Label)ShoppingCartGridView.Rows[rowindex].FindControl("PriceLabel")).Text);
        if (txtQty != null)
        {
           // txtQty.Attributes["onkeyup"] = "value=value.replace(/[^\\d]/g,'')";
            money += txtQty * lblPrice;
            M_str_Count = money.ToString();
        }
    }

    protected void checkout_DataBound(object sender, GridViewRowEventArgs e)
    {
        //int rowindex = Convert.ToInt32(e.CommandArgument);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //GridView行的加亮显示功能
            e.Row.Attributes.Add("onmouseover", "b=this.style.backgroundColor;this.style.backgroundColor='#E1ECEE'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=b");

            //给+号图片和-号图片添加客户端click事件
            //用JavaScript实现数量的+1和-1
            TextBox tb = (TextBox)e.Row.FindControl("txtCount");
            //((HtmlImage)ShoppingCartGridView.Rows[rowindex].FindControl("imgReduce")).Attributes.Add("onclick", "Reduce(" + tb.ClientID + ")");
            //((HtmlImage)ShoppingCartGridView.Rows[rowindex].FindControl("imgPlus")).Attributes.Add("onclick", "Plus(" + tb.ClientID + ")");

            //根据商品单价和数量计算购物车中商品的总金额
            DataRowView drv = (DataRowView)e.Row.DataItem;
            //Total += Double.Parse(drv["Price"].ToString())* Int32.Parse(tb.Text);
            //}
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //将总金额显示在金额一列对应的Footer单元格
                e.Row.Cells[1].Text = "Total：";
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                e.Row.Cells[2].Text = Total.ToString("c2");
                e.Row.Cells[2].ForeColor = Color.Red;
            }
            //int rowindex = Convert.ToInt32(e.CommandArgument);
            ////Get Row           
            //GridViewRow gvr = ShoppingCartGridView.Rows[rowindex];
            //List<ShopingCart> shoppingcart;

            //shoppingcart = (List<ShopingCart>)Session["CheckOut"];

            //ShopingCart sc = new ShopingCart();
            //int pID, qty;
            //double price;
            //string partNo;
            //string image;
            //pID = Convert.ToInt32(ShoppingCartGridView.DataKeys[rowindex].Value.ToString());
            //partNo = ((Label)ShoppingCartGridView.Rows[rowindex].FindControl("PartNoLabel")).Text;
            //image = ((Image)ShoppingCartGridView.Rows[rowindex].FindControl("imageLabel")).ImageUrl;
            //qty = Convert.ToInt32(((TextBox)ShoppingCartGridView.Rows[rowindex].FindControl("txtCount")).Text);
            //price = Convert.ToDouble(((Label)ShoppingCartGridView.Rows[rowindex].FindControl("PriceLabel")).Text);
            //sc.ProductId = pID;
            //sc.Qty = qty;
            //sc.Pricing = price;
            //sc.PartNo = partNo;
            //sc.Image = image;
            //shoppingcart.Add(sc);
            //Session["CheckOut"] = shoppingcart;
        }
    }

    protected void IBTCheckout_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/Account/CheckOut.aspx");
        Order order = new Order();
        OrderLine orderLine = new OrderLine();
        List<OrderLine> listOrder = new List<OrderLine>();
        //ShopingCart checkOut = new ShopingCart();
        order.UserId = userID;
        order.OrderId = int.Parse(ShoppingCartGridView.SelectedRow.Cells[0].Text);
        order.OrderDate = DateTime.Now.ToLocalTime();
        //orderLine.ProductId = int.Parse(ShoppingCartGridView.SelectedRow.Cells[1].Text);
        //orderLine.Qty = int.Parse(ShoppingCartGridView.SelectedRow.Cells[5].Text);

        int pID, qty;
        double price;
        string partNo;
        string image;
        pID = int.Parse(ShoppingCartGridView.SelectedRow.Cells[1].Text);
        partNo = ShoppingCartGridView.SelectedRow.Cells[3].Text;
        image = ShoppingCartGridView.SelectedRow.Cells[2].Text;
        qty = int.Parse(ShoppingCartGridView.SelectedRow.Cells[5].Text);
        price = double.Parse(ShoppingCartGridView.SelectedRow.Cells[4].Text);
        orderLine.ProductId = pID;
        orderLine.Qty = qty;
        //orderLine.Pricing = price;
        //orderLine.PartNo = partNo;
        //orderLine.Image = image;
        listOrder.Add(orderLine);
        //orderLine.ProductType = 
        int checkout;
        checkout = OrderBLO.AddNewOrder(order, listOrder);
        //if (e.CommandName == "MyButtonClick")
        //{
            //Get rowindex            
           

        //}

        // Response.Redirect("~/ShoppingCart.aspx?ProductID=" + strProductID + "&Num=1");
    }

    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //点击删除时从DataTable中删除对应的数据行
        if (Session["Cart"] != null)
        {
            shoppingcarttb = (DataTable)Session["Cart"];
            shoppingcarttb.Rows.RemoveAt(e.RowIndex);
            shoppingcarttb.AcceptChanges();
            Session["Cart"] = shoppingcarttb;
            Response.Redirect("ShoppingCart.aspx");
        }
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