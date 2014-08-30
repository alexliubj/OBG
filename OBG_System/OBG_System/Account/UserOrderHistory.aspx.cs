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
    int userId = 0;
    Order order = new Order();
    OrderLine line = new OrderLine();
    List<OrderLine> orderine = new List<OrderLine>();
    int orderID = 0;
    DataTable orderDetailTable;
    string statusLabel = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        userId = (int)Session["UserID"];
        if (!IsPostBack)
        {

            for (int i = 0; i < OrderGridView.Rows.Count; i++)
            {


                line.ProductId = int.Parse(((Label)OrderGridView.Rows[i].Cells[1].FindControl("LBProductID")).Text.ToString()); ;
                line.PartNO = ((Label)OrderGridView.Rows[i].Cells[3].FindControl("Label5")).Text.ToString(); ;
                line.DiscountRate = float.Parse(((Label)OrderGridView.Rows[i].Cells[5].FindControl("Label6")).Text.Substring(1).ToString());
                line.ProductName = ((Label)OrderGridView.Rows[i].Cells[3].FindControl("Label8")).Text.ToString();
                line.Qty = int.Parse(((TextBox)OrderGridView.Rows[i].Cells[4].FindControl("TextBox4")).Text.ToString());
                orderine.Add(line);
            }

                //ViewState["SortOrder"] = "orderid";
                //ViewState["OrderDire"] = "asc";

            Gridview1_Bind();
            
        }

        

       
    }

    
    public void Gridview1_Bind()
    {

        DataTable order = OrderBLO.GetAllOrderByUserId(userId);
        orderDataSet = new DataSet();
        orderDataSet.Tables.Add(order);

        GridView1.DataSource = orderDataSet;
        GridView1.DataKeyNames = new string[] { "OrderId" };
        GridView1.DataBind();

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string status = ((Label)(GridView1.Rows[i].Cells[3].FindControl("Label5"))).Text.ToString().Trim();
            

            switch (status)
            {
                case "0":
                    statusLabel = "Incomplete";
                    break;
                case "1":
                    statusLabel = "Pending";
                    //updatebutton.Visible = true;
                    break;
                case "2":
                    statusLabel = "Processed";
                    break;
                case "3":
                    statusLabel = "Partially Shipped";
                    break;
                case "4":
                    statusLabel = "Shipping";
                    break;
                case "5":
                    statusLabel = "Shipped";
                    break;
                case "6":
                    statusLabel = "Partially Returned";
                    break;
                case "7":
                    statusLabel = "Returned";
                    break;
                case "8":
                    statusLabel = "Canceled";
                    break;
                default:
                    statusLabel = "Unknown";
                    break;
            }
            ((Label)(GridView1.Rows[i].Cells[3].FindControl("Label5"))).Text = statusLabel;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);

        GridView2_Bind(orderID);

        divOrderDetail.Visible = true;
    }
   
    public void GridView2_Bind(int orderID)
    {
        statusLabel = ((Label)(GridView1.SelectedRow.Cells[3].FindControl("Label5"))).Text;
        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);
        if (statusLabel == "Pending")
        {
            updatebutton.Visible = true;
        }
       
        OrderGridView.DataSource = orderDetailTable;
        OrderGridView.DataKeyNames = new string[] { "OrderId" };
        OrderGridView.DataBind();
        Populacontorl(orderID);
    }

   

    protected void LBUpdate_Click(object sender, EventArgs e)
    {
        //int orderID = 0;
        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        int rowCount;
        rowCount = OrderGridView.Rows.Count;
        GridViewRow ViewCart;
        TextBox productQuatity;

        for (int i = 0; i < rowCount; i++)
        {
            ViewCart = OrderGridView.Rows[i];
            //int strProductID = int.Parse(OrderGridView.SelectedRow.Cells[1].Text);
            int strProductID = int.Parse(((Label)(OrderGridView.Rows[i].Cells[1].FindControl("LBProductID"))).Text.ToString());
            productQuatity = (TextBox)ViewCart.FindControl("TextBox4");
            OrderBLO.UpdateQtybyProid(strProductID, Convert.ToInt32(productQuatity.Text));

             //   return;
        }
        statusLabel = ((Label)(GridView1.SelectedRow.Cells[3].FindControl("Label5"))).Text;
       
        Populacontorl(orderID);
    }

    protected void Populacontorl(int orderID)
    {
        //orderID = int.Parse(OrderGridView.SelectedRow.Cells[0].Text);
        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);
        double regionid = RegionBLO.GetReginIDByUserId(userId);
        //double rf = RegionBLO.GetReginFeeByReginID(regionid);
        decimal tatil = 0;
        decimal HST = 0;
        decimal totalPrice = 0;
        decimal hst = (Decimal)(0.13);
        decimal shipfee = (Decimal)regionid;
        foreach (DataRow row in orderDetailTable.Rows)
        {
            tatil += decimal.Parse(row["DiscountRate"].ToString()) * int.Parse(row["Qty"].ToString());
            //HST += (decimal.Parse(row["DiscountRate"].ToString()) * int.Parse(row["Qty"].ToString()) + shipfee) * hst;
            HST = (tatil + shipfee) * hst;
            totalPrice = tatil + HST + shipfee;
        }
        lblTatil.Text = string.Format("${0:n2}", tatil);
        Label2.Text = string.Format("${0:n2}", HST);
        Label7.Text = string.Format("${0:n2}", totalPrice);
        Label10.Text = string.Format("${0:n2}", regionid);
        OrderGridView.DataSource = orderDetailTable;
        OrderGridView.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        orderDetailTable = OrderBLO.GetOrderLineByOrderId(orderID);

        statusLabel = ((Label)(GridView1.SelectedRow.Cells[3].FindControl("Label5"))).Text;
        if (statusLabel == "Pending")
        {

            if (orderDetailTable != null)
            {
                
                int pId = Convert.ToInt32(((Label)(OrderGridView.Rows[e.RowIndex].Cells[1].FindControl("LBProductID"))).Text.ToString());
                int orderConfirm = OrderBLO.DeleteProductById(pId);
                GridView2_Bind(orderID);
               
            }
        }
        else
        {
            Response.Write("<script language='javascript'>alert('You cannot modify your order after pending');</script>");
        }

    }

    protected void Confirm_Click(object sender, EventArgs e)
    {

        //int ordersave = OrderBLO.AddNewOrder(order, orderine);
        //if (ordersave > 0)
        //{
        orderID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
            User user = UserBLO.GetUserInfoWithUserId(userId);
            SendMail(user.Email, orderID);
            Session.Remove("Cart");
            Response.Redirect("~/Default.aspx");

        //}
        //else
        //{
        //    //Response.Redirect("~/Default.aspx");
        //}
        //
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        // DataTable dataTable = TiresBLO.GetAllTires();
        DataTable order = OrderBLO.GetAllOrderByUserId(userId);
        if (order != null)
        {
            DataView dataView = new DataView(order);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        Gridview1_Bind();
    }


    public bool SendMail(string ToEmail, int orderid)
    {
        //MailMessage myMail = new MailMessage();
        //myMail.From = new MailAddress("317844956@qq.com");
        //myMail.To.Add(new MailAddress(""));
        //myMail.Subject = "C#发送Email";
        //myMail.SubjectEncoding = Encoding.UTF8;
        //myMail.Body = "this is a test email from QQ!";
        //myMail.BodyEncoding = Encoding.UTF8;
        //myMail.IsBodyHtml = true;
        //SmtpClient smtp = new SmtpClient();
        //smtp.Host = "smtp.qq.com";
        //smtp.Credentials = new NetworkCredential("", "123456");
        //smtp.Send(myMail);
        //return true;


        //string Email = "alexliu0506@126.com";
        //string Email = "holmeslixu@gmail.com";
        string Email = "orders@optiwheels.ca";
        string password = "orders12345";
        string totoEmail = "min@optiwheels.ca";
        //string password = "5631247";
        //string password = "holmes615";
        Encoding EnCode = Encoding.UTF8;
        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
        Message.From = new MailAddress(Email, "OBG Master", EnCode);
        Message.To.Add(new MailAddress(ToEmail, "Dear Customer", EnCode));
        Message.To.Add(new MailAddress(totoEmail, "Dear Admin"));
        Message.Subject = "Your OPIT Order Is Confirmed‏ ";
        Message.SubjectEncoding = EnCode;

        StringBuilder MailContent = new StringBuilder();
        string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/");
        MailContent.Append("Dear Customer：<br/>");
        MailContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Your orderid is "+ orderid);
        MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have updated your order successfully! ");
        //MailContent.Append("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;At ");
        //MailContent.Append(DateTime.Now.ToLongTimeString());

        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You have ordered products at <a href='" + host + "'>OBG Order System</a>.");
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To check the status of your order, please see your order history: ");
        //MailContent.Append("<br/>Here are your order details: ");
        //MailContent.Append(CKGridView);

        //string url = host + "Account/UserOrderHistory.aspx";
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='" + url + "'>" + url + "</a>");
        //MailContent.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You can modify your order before shipping.</p>");


        Message.Body = MailContent.ToString();
        Message.BodyEncoding = EnCode;
        Message.IsBodyHtml = true;

        try
        {
            //SmtpClient smtp = new SmtpClient("smtp.zoho.com", 587);
            //SmtpClient smtp = new SmtpClient("smtp.qq.com", 25);
            SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net", 25);
            //SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            //smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(Email, password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(Message);

        }
        catch (SmtpException ex)
        {
            string msg = "Mail cannot be sent because of the server problem:";
            msg += ex.Message;
            Label7.Text = msg;
            return false;
        }
        return true;
    }
    
}