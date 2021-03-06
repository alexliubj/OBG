﻿using System;
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
    private Double Total = 0;
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
        shoppingcarttb.Columns.Add("ProductName");
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
                    scRow["ProductName"] = " ";
                }
                if (sc.TireId != 0)
                {
                    scRow["ProductId"] = sc.TireId.ToString();
                    scRow["ProductType"] = "1";
                    scRow["ProductName"] = " ";
                }
                if (sc.AccId != 0)
                {
                    scRow["ProductId"] = sc.AccId.ToString();
                    scRow["ProductType"] = "2";
                    scRow["ProductName"] = sc.productName;
                }
                scRow["Image"] = sc.Image;
                scRow["PartNo"] = sc.PartNo.ToString();
                scRow["Price"] = sc.Pricing.ToString();
                scRow["Quantity"] = sc.Qty.ToString();
                scRow["itemTotal"] = sc.Pricing * sc.Qty;
                shoppingcarttb.Rows.Add(scRow);
                totalPrice();
            }
        }

        if (!IsPostBack)
        {


            ShoppingCartGridView_DataBind();
           
        }
    }

    public void ShoppingCartGridView_DataBind()
    {
      
       

        ShoppingCartGridView.DataSource = shoppingcarttb;
        ShoppingCartGridView.DataKeyNames = new string[] { "ProductId" };
        ShoppingCartGridView.DataBind();
            //ShoppingCartGridView.Rows.Count = shoppingcart.Count;
           
    }

    //protected void totalPrice()
    //{
    //    decimal total = 0;
    //    decimal HST = 0;
    //    decimal totalPrice = 0;
    //    decimal hst = (Decimal)(0.13);
    //    foreach (DataRow row in shoppingcarttb.Rows)
    //    {
    //        total += decimal.Parse(row["Price"].ToString()) * int.Parse(row["Quantity"].ToString());
    //        HST += decimal.Parse(row["Price"].ToString()) * int.Parse(row["Quantity"].ToString()) * hst;
    //        totalPrice = total + HST;
    //    }
    //    LabelTotalPrice.Text = string.Format("${0:n2}", total);
    //    Label1.Text = string.Format("${0:n2}", HST);
    //    Label2.Text = string.Format("${0:n2}", totalPrice);
    //    ShoppingCartGridView.DataSource = shoppingcarttb;
    //    ShoppingCartGridView.DataBind();
    //}

    protected void totalPrice()
    {
        double regionid = RegionBLO.GetReginIDByUserId(userID);
        decimal total = 0;
        decimal HST = 0;
        decimal totalPrice = 0;
        decimal hst = (Decimal)(0.13);
        decimal shipfee = (Decimal)regionid;
        foreach (DataRow row in shoppingcarttb.Rows)
        {
            total += decimal.Parse(row["Price"].ToString()) * int.Parse(row["Quantity"].ToString());
            //HST += (decimal.Parse(row["Price"].ToString()) * int.Parse(row["Quantity"].ToString()) + shipfee) * hst;
            HST = (total + shipfee) * hst;
            totalPrice = total + HST + shipfee;
        }
        LabelTotalPrice.Text = string.Format("${0:n2}", total);
        Label1.Text = string.Format("${0:n2}", HST);
        Label2.Text = string.Format("${0:n2}", totalPrice);
        Label10.Text = string.Format("${0:n2}", regionid);
        // CKGridView.DataSource = checkoutTB;
        //CKGridView.DataBind();
    }

    //protected void LBUpdate_Click(object sender, EventArgs e)
    //{
    //    int rowCount;
    //    rowCount = ShoppingCartGridView.Rows.Count;
    //    GridViewRow ViewCart;
    //    TextBox productQuatity;

    //    for (int i = 0; i < rowCount; i++)
    //    {
    //        ViewCart = ShoppingCartGridView.Rows[i];
    //        string strProductID = ShoppingCartGridView.DataKeys[i].Value.ToString();
    //        productQuatity = (TextBox)ViewCart.FindControl("txtCount");

    //    }
    //    totalPrice();
    //}

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

    //protected void ShoppingCart_ItemDataBound(object sender, GridViewCommandEventArgs e)
    //{
    //    int rowindex = Convert.ToInt32(e.CommandArgument);
    //    //用来实现数量文本框中只能输入数字
    //    int txtQty = Convert.ToInt32(((TextBox)ShoppingCartGridView.Rows[rowindex].FindControl("txtCount")).Text);
    //    float lblPrice = Convert.ToSingle(((Label)ShoppingCartGridView.Rows[rowindex].FindControl("PriceLabel")).Text);
    //    if (txtQty != null)
    //    {
    //       // txtQty.Attributes["onkeyup"] = "value=value.replace(/[^\\d]/g,'')";
    //        money += txtQty * lblPrice;
    //        M_str_Count = money.ToString();
    //    }
    //}

    protected void checkout_DataBound(object sender, GridViewCommandEventArgs e)
    {
        
    }

    protected void IBTCheckout_Click(object sender, EventArgs e)
    {
        //int rowindex = Convert.ToInt32(e.CommandArgument);
        //Get Row           
        //GridViewRow gvr = ShoppingCartGridView.Rows[rowindex];
        //List<ShopingCart> shoppingcart;

        //if (Session["Cart"] == null)
        //{
        //    shoppingcart = new List<ShopingCart>();

        //}
        //else
        //{
        //    shoppingcart = (List<ShopingCart>)Session["Cart"];
        //}
        //ShopingCart sc = new ShopingCart();



        //int pID, qty;
        //double price;
        //string partNo;
        //string image;
        //int rowCount;
        //rowCount = ShoppingCartGridView.Rows.Count;
        //GridViewRow gvr;
        //List<ShopingCart> shoppingcart1 = new List<ShopingCart>();
        //for (int i = 0; i < rowCount; i++)
        //{
        //    gvr = ShoppingCartGridView.Rows[i];
        //    pID = Convert.ToInt32(((Label)(ShoppingCartGridView.Rows[i].Cells[1].FindControl("idLabel"))).Text.ToString());
        //    partNo = ((Label)(ShoppingCartGridView.Rows[i].Cells[3].FindControl("PartNoLabel"))).Text.ToString();
        //    image = ((Image)(ShoppingCartGridView.Rows[i].Cells[2].FindControl("imageLabel"))).ImageUrl;
        //    qty = Convert.ToInt32(((TextBox)(gvr.FindControl("txtCount"))).Text.ToString());
        //    price = Convert.ToDouble(((Label)(ShoppingCartGridView.Rows[i].Cells[4].FindControl("Price"))).Text.Substring(1)) * special;
        //    sc.ProductId = pID;
        //    sc.Qty = qty;
        //    sc.Pricing = price;
        //    sc.PartNo = partNo;
        //    sc.Image = image;
        //    shoppingcart1.Add(sc);
        //}
        //    Session["Cart"] = shoppingcart1;




            Response.Redirect("~/Account/CheckOut.aspx");
            //Order order = new Order();
            //OrderLine orderLine = new OrderLine();
            //List<OrderLine> listOrder = new List<OrderLine>();
            ////ShopingCart checkOut = new ShopingCart();
            //userID = 1;
            //order.UserId = userID;
            //order.OrderId = int.Parse(ShoppingCartGridView.SelectedRow.Cells[0].Text);
            //order.OrderDate = DateTime.Now.ToLocalTime();
            ////orderLine.ProductId = int.Parse(ShoppingCartGridView.SelectedRow.Cells[1].Text);
            ////orderLine.Qty = int.Parse(ShoppingCartGridView.SelectedRow.Cells[5].Text);

            //int pID, qty;
            //double price;
            //string partNo;
            //string image;
            //pID = int.Parse(ShoppingCartGridView.SelectedRow.Cells[1].Text);
            //partNo = ShoppingCartGridView.SelectedRow.Cells[3].Text;
            //image = ShoppingCartGridView.SelectedRow.Cells[2].Text;
            //qty = int.Parse(ShoppingCartGridView.SelectedRow.Cells[5].Text);
            //price = double.Parse(ShoppingCartGridView.SelectedRow.Cells[4].Text);
            //orderLine.ProductId = pID;
            //orderLine.Qty = qty;
            ////orderLine.Pricing = price;
            ////orderLine.PartNo = partNo;
            ////orderLine.Image = image;
            //listOrder.Add(orderLine);
            ////orderLine.ProductType = 
            //int checkout;
            //checkout = OrderBLO.AddNewOrder(order, listOrder);
            //if (e.CommandName == "MyButtonClick")
            //{
            //Get rowindex            


            //}
       // }

        // Response.Redirect("~/ShoppingCart.aspx?ProductID=" + strProductID + "&Num=1");
    }


    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //点击删除时从DataTable中删除对应的数据行
        if (Session["Cart"] != null)
        {
            shoppingcart = (List<ShopingCart>)Session["Cart"];
            shoppingcart.RemoveAt(e.RowIndex);
            //shoppingcart.AcceptChanges();
            Session["Cart"] = shoppingcart;
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