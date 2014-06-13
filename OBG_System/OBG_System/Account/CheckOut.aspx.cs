﻿using System;
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
    int userID = 0;
    OrderLine orderLine = new OrderLine();
    ShopingCart sc = new ShopingCart();
    List<ShopingCart> shoppingcart = new List<ShopingCart>();
    //List<OrderLine> orderline = new List<OrderLine>();
    DataTable checkoutTB = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userID"] != null)
        {
            userID = (int)Session["userID"];
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }

        shoppingcart = (List<ShopingCart>)Session["Cart"];
        checkoutTB.Columns.Add("OrderId");
        checkoutTB.Columns.Add("ProductId");
        checkoutTB.Columns.Add("ProductType");
        checkoutTB.Columns.Add("PartNo");
        checkoutTB.Columns.Add("Image");
        checkoutTB.Columns.Add("qty");
        checkoutTB.Columns.Add("Price");
        checkoutTB.Columns.Add("itemTotal");
        if ((List<ShopingCart>)Session["Cart"] == null)
        {
            Response.Write("~/Account/ShoppingCart.aspx");
        }

        else
        {

            for (int i = 0; i < shoppingcart.Count; i++)
            {
                sc = shoppingcart[i];
                DataRow checkoutRow = checkoutTB.NewRow();
                if (sc.ProductId != 0)
                {
                    checkoutRow["ProductId"] = sc.ProductId.ToString();
                    checkoutRow["ProductType"] = "0";
                }
                if (sc.TireId != 0)
                {
                    checkoutRow["ProductId"] = sc.TireId.ToString();
                    checkoutRow["ProductType"] = "1";
                }
                if (sc.AccId != 0)
                {
                    checkoutRow["ProductId"] = sc.AccId.ToString();
                    checkoutRow["ProductType"] = "2";
                }
                //checkoutRow["OrderId"] = sc.or
                checkoutRow["Image"] = sc.Image;
                checkoutRow["PartNo"] = sc.PartNo.ToString();
                checkoutRow["Price"] = sc.Pricing.ToString();
                checkoutRow["qty"] = sc.Qty.ToString();
                checkoutRow["itemTotal"] = sc.Pricing * sc.Qty;
                checkoutTB.Rows.Add(checkoutRow);
                totalPrice();
            }
            // for (int i = 0; i < orderline.Count; i++)
            //{
            //     DataRow checkoutRow = checkoutTB.NewRow();
            //    orderLine = orderline[i];
            //    checkoutRow["OrderId"] = orderLine.OrderId.ToString();
            //    checkoutTB.Rows.Add(checkoutRow);
            //}
        }

        if (!IsPostBack)
        {
            GridView1_Bind();
        }
    }
    public void GridView1_Bind()
    {
        CKGridView.DataSource = checkoutTB;
        CKGridView.DataKeyNames = new string[] { "ProductId" };
        CKGridView.DataBind(); 
    }

    protected void totalPrice()
    {
        decimal total = 0;
        foreach (DataRow row in checkoutTB.Rows)
        {
            total += decimal.Parse(row["Price"].ToString()) * int.Parse(row["qty"].ToString());
        }
        LabelTotalPrice.Text = string.Format("{0:n2}", total);
       // CKGridView.DataSource = checkoutTB;
        //CKGridView.DataBind();
    }
    //protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    //{
        
    //    //DataTable dataTable = ;

    //    if (dataTable != null)
    //    {
    //        DataView dataView = new DataView(dataTable);
    //        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

    //        GridView2.DataSource = dataView;
    //        GridView2.DataBind();
    //    }
    //}

    protected void CKGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CKGridView.PageIndex = e.NewPageIndex;
    }



    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }

    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
        Order order = new Order();
        OrderLine line = new OrderLine();
        List<OrderLine> orderline = new List<OrderLine>();
        int userId, orderId;
        userId = userID;
        //orderId = int.Parse(CKGridView.SelectedRow.Cells[0].Text);
        //order.OrderId = orderId;
        order.OrderDate = DateTime.Now.ToLocalTime();
        order.PO = txtPO.Text.ToString().Trim();
        int productID = int.Parse(CKGridView.SelectedRow.Cells[1].Text);
        line.ProductId = productID;
        //line.OrderId = orderId;
        line.Qty = int.Parse(CKGridView.SelectedRow.Cells[5].Text);
        orderline.Add(line);
            //line = orderline[i];
            //DataRow checkoutRow = checkoutTB.NewRow();
            //checkoutRow["ProductId"] = line.ProductId.ToString();
            //checkoutRow["ProductType"] = "0";

            //checkoutRow["qty"] = line.Qty.ToString();
            //checkoutTB.Rows.Add(checkoutRow);

  
    //    }
        int ordersave = OrderBLO.AddNewOrder(order, orderline);
        Response.Write("~/Account/ShoppingCart.aspx");
    }
}