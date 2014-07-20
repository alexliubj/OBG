using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;
using System.Text;
using System.Net.Mail;
using System.Net;

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
        checkoutTB.Columns.Add("ProductName");
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
                    checkoutRow["ProductName"] = " ";
                }
                if (sc.TireId != 0)
                {
                    checkoutRow["ProductId"] = sc.TireId.ToString();
                    checkoutRow["ProductType"] = "1";
                    checkoutRow["ProductName"] = " ";
                }
                if (sc.AccId != 0)
                {
                    checkoutRow["ProductId"] = sc.AccId.ToString();
                    checkoutRow["ProductType"] = "2";
                    checkoutRow["ProductName"] = sc.productName;
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
        decimal HST = 0;
        decimal totalPrice = 0;
        decimal hst = (Decimal)(0.13);
        foreach (DataRow row in checkoutTB.Rows)
        {
            total += decimal.Parse(row["Price"].ToString()) * int.Parse(row["qty"].ToString());
            HST += decimal.Parse(row["Price"].ToString()) * int.Parse(row["qty"].ToString()) * hst;
            totalPrice = total + HST;
        }
        LabelTotalPrice.Text = string.Format("${0:n2}", total);
        Label1.Text = string.Format("${0:n2}", HST);
        Label2.Text = string.Format("${0:n2}", totalPrice);
       // CKGridView.DataSource = checkoutTB;
        //CKGridView.DataBind();
    }

    //protected void CKGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    CKGridView.PageIndex = e.NewPageIndex;
    //}



    //private string ConvertSortDirectionToSql(SortDirection sortDirection)
    //{
    //    string newSortDirection = String.Empty;

    //    switch (sortDirection)
    //    {
    //        case SortDirection.Ascending:
    //            newSortDirection = "ASC";
    //            break;

    //        case SortDirection.Descending:
    //            newSortDirection = "DESC";
    //            break;
    //    }

    //    return newSortDirection;
    //}

    protected void BtnConfirm_Click(object sender, EventArgs e)
    {
        if (txtPO.Text == string.Empty)
        {
            Response.Write("<script language='javascript'>alert('Your have to write PO');</script>");
        }
        else
        {
            int orderId;
            Order order = new Order();
 
            List<OrderLine> orderline = new List<OrderLine>();
            //double rate = ;
            //orderId = int.Parse(CKGridView.SelectedRow.Cells[0].Text);
            //order.OrderId = orderId;
            order.UserId = userID;
            order.Status = 1;
            order.OrderDate = DateTime.Today;
            order.PO = txtPO.Text.ToString().Trim();
            for (int i = 0; i < CKGridView.Rows.Count; i++)
            {
                OrderLine line = new OrderLine();
                //int orderID = int.Parse(((Label)CKGridView.Rows[i].Cells[0].FindControl("LabelOrder")).Text.ToString());
                line.ProductId = int.Parse(((Label)CKGridView.Rows[i].Cells[1].FindControl("Label3")).Text.ToString());;
                // line.PartNO = ((Label)CKGridView.Rows[i].Cells[3].FindControl("Label8")).Text.ToString();
                line.PartNO = ((Label)CKGridView.Rows[i].Cells[3].FindControl("Label8")).Text.ToString();;
                //line.OrderId = orderID;
                //line.OrderId = orderId;
                //line.DiscountRate = (float)rate;
                
                line.DiscountRate = float.Parse(((Label)CKGridView.Rows[i].Cells[7].FindControl("Price")).Text.Substring(1).ToString());
                line.ProductName = ((Label)CKGridView.Rows[i].Cells[4].FindControl("Label4")).Text.ToString();
                line.ProductType = int.Parse(((Label)CKGridView.Rows[i].Cells[5].FindControl("Label5")).Text.ToString());
                line.Qty = int.Parse(((Label)CKGridView.Rows[i].Cells[6].FindControl("Label6")).Text.ToString());
                line.Image = ((Image)CKGridView.Rows[i].Cells[2].FindControl("imageLabel")).ImageUrl;
                orderline.Add(line);
            }

            //line = orderline[i];
            //DataRow checkoutRow = checkoutTB.NewRow();
            //checkoutRow["ProductId"] = line.ProductId.ToString();
            //checkoutRow["ProductType"] = "0";

            //checkoutRow["qty"] = line.Qty.ToString();
            //checkoutTB.Rows.Add(checkoutRow);


            //    }
            int ordersave = OrderBLO.AddNewOrder(order, orderline);
            if (ordersave > 0)
            {
                User user = UserBLO.GetUserInfoWithUserId(userID);
                SendMail(user.Email);
                Session.Remove("Cart");
                Response.Redirect("~/Default.aspx");
            }
            else 
            {
                //fail
            }
        }
        
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        CKGridView.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        GridView1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
       // DataTable dataTable = TiresBLO.GetAllTires();

        if (shoppingcart != null)
        {
            DataView dataView = new DataView(checkoutTB);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            CKGridView.DataSource = dataView;
            CKGridView.DataBind();
        }

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


    public bool SendMail(string ToEmail)
    {
        string Email = "alexliu0506@126.com";
        //string Email = "onlineorders@optiwheels.ca";
       // string password = "orders12345";
        string password = "5631247";
        Encoding EnCode = Encoding.UTF8;
        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
        Message.From = new MailAddress(Email, "OBG Master", EnCode);
        Message.To.Add(new MailAddress(ToEmail, "Dear Customer", EnCode));
        Message.Subject = "Your OPIT Order Is Confirmed‏ ";
        Message.SubjectEncoding = EnCode;

        StringBuilder MailContent = new StringBuilder();
        MailContent.Append("Dear Customer：<br/>");
        MailContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;At ");
        MailContent.Append(DateTime.Now.ToLongTimeString());
         string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/");
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have ordered products at <a href='"+host+"'>OBG Order System</a>.");
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For more order details, please see your order history: ");
         MailContent.Append("<br/>Here are your order details: ");
        MailContent.Append(CKGridView);
       
        //string url = host + "Account/UserOrderHistory.aspx";
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='" + url + "'>" + url + "</a>");
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can modify your order before shipping.</p>");
        Message.Body = MailContent.ToString();
        Message.BodyEncoding = EnCode;
        Message.IsBodyHtml = true;

        try
        {
            SmtpClient smtp = new SmtpClient("smtp.126.com", 25);
            //SmtpClient smtp = new SmtpClient("smtp.optiwheels.ca", 25);
            smtp.Credentials = new NetworkCredential(Email, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(Message);
        }
        catch (Exception e)
        {
            return false;
        }
        finally
        {
            Message.Dispose();
        }
        return true;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Account/ShoppingCart.aspx");
    }
}