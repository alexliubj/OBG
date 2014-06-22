using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;

public partial class Account_Special : System.Web.UI.Page
{
    private DataSet wheelsDataSet;
    private DataSet tiresDataSet;
    private DataSet accessoriesDataSet;
    int userID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItem ms = new MenuItem();
        if (Session["UserID"] != null)
        {
            userID = (int)Session["UserID"];

            if (Session["Permissions"] != null)
            {
                int wheelPermission = ((List<int>)(Session["Permissions"]))[0];
                if (wheelPermission == 0)
                {
                    Response.Write("<script language='javascript'>alert('Your account does not have permission to access this page');</script>");
                    Server.Transfer("~/Account/UserCenter.aspx", true);
                }
            }
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        if (!IsPostBack)
        {
            ms = NavigationMenu.FindItem("Wheels");
            ms.Selectable = false;

            Gridview1_Bind();
            GridView2_Bind();
            GridView3_Bind();
        }
    }

    public void Gridview1_Bind()
    {

        DataTable specialwheel = SpecialBLO.GetAllSpecialWheels(userID);
        wheelsDataSet = new DataSet();
        wheelsDataSet.Tables.Add(specialwheel);

        GridView1.DataSource = wheelsDataSet;
        GridView1.DataKeyNames = new string[] { "ProductId" };
        GridView1.DataBind();


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (GridView1.SelectedIndex > -1)
        {
            GridView1.SelectedIndex = -1;
        }
        Gridview1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = SpecialBLO.GetAllSpecialWheels(userID);

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
    }

    public void GridView2_Bind()
    {

        DataTable Specialtire = SpecialBLO.GetAllSpecialTires(userID);
        tiresDataSet = new DataSet();
        tiresDataSet.Tables.Add(Specialtire);

        GridView2.DataSource = tiresDataSet;
        GridView2.DataKeyNames = new string[] { "TireId" };
        GridView2.DataBind();
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (GridView1.SelectedIndex > -1)
        {
            GridView1.SelectedIndex = -1;
        }
        Gridview1_Bind();
    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = SpecialBLO.GetAllSpecialTires(userID);

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
    }

    public void GridView3_Bind()
    {

        DataTable specialacc = SpecialBLO.GetAllSpecialAcces(userID);
        accessoriesDataSet = new DataSet();
        accessoriesDataSet.Tables.Add(specialacc);

        GridView3.DataSource = accessoriesDataSet;
        GridView3.DataKeyNames = new string[] { "AccId" };
        GridView3.DataBind();
    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        if (GridView3.SelectedIndex > -1)
        {
            GridView3.SelectedIndex = -1;
        }
        GridView3_Bind();
    }

    protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = SpecialBLO.GetAllSpecialAcces(userID);

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView3.DataSource = dataView;
            GridView3.DataBind();
        }
    }
    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Wheels")
        {
            divWheel.Visible = true;
            divTire.Visible = false;
            divAcc.Visible = false;
        }
        if (e.Item.Text == "Tires")
        {
            divWheel.Visible = false;
            divTire.Visible = true;
            divAcc.Visible = false;
        }
        if (e.Item.Text == "Accessories")
        {
            divWheel.Visible = false;
            divTire.Visible = false;
            divAcc.Visible = true;
        }

        MenuItem ms = NavigationMenu.FindItem(e.Item.Text);
        if (ms != null)
        {
            ms.Selectable = false;
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

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView1.PageIndex = 0;
        Gridview1_Bind();
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

    protected void dropDownRecordsPerPage2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView2.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView2.PageIndex = 0;
        GridView2_Bind();
    }

    protected void GridView2_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

    protected void dropDownRecordsPerPage3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView3.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView3.PageIndex = 0;
        GridView3_Bind();
    }

    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClick")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView1.Rows[rowindex];
            List<ShopingCart> shoppingcart;

            if (Session["Cart"] == null)
            {
                shoppingcart = new List<ShopingCart>();

            }
            else
            {
                shoppingcart = (List<ShopingCart>)Session["Cart"];
            }
            ShopingCart sc = new ShopingCart();
            int pID, qty;
            double price;
            string partNo;
            string image;
            float special;
            special = (float)Convert.ToSingle(((Label)GridView3.Rows[rowindex].FindControl("LBSpecial")).Text);
            pID = Convert.ToInt32(GridView1.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView1.Rows[rowindex].FindControl("Label14")).Text;
            image = ((Image)GridView1.Rows[rowindex].FindControl("Image1")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView1.Rows[rowindex].FindControl("QTYTextBox")).Text);
            price = Convert.ToDouble(((Label)GridView1.Rows[rowindex].FindControl("Label13")).Text.Substring(1)) * special;
            sc.ProductId = pID;
            sc.Qty = qty;
            sc.Pricing = price;
            sc.PartNo = partNo;
            sc.Image = image;
            shoppingcart.Add(sc);
            Session["Cart"] = shoppingcart;

        }
    }

    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClickt")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView2.Rows[rowindex];
            List<ShopingCart> shoppingcart;
            if (Session["Cart"] == null)
            {
                shoppingcart = new List<ShopingCart>();

            }
            else
            {
                shoppingcart = (List<ShopingCart>)Session["Cart"];
            }

            ShopingCart sc = new ShopingCart();
            int tID, qty;
            double price;
            string image;
            string partNo;
            float special;
            special = (float)Convert.ToSingle(((Label)GridView3.Rows[rowindex].FindControl("LBSpecial")).Text);
            tID = Convert.ToInt32(GridView2.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView2.Rows[rowindex].FindControl("Label2")).Text;
            image = ((Image)GridView2.Rows[rowindex].FindControl("Image1")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView2.Rows[rowindex].FindControl("QTYTextBox")).Text);
            price = Convert.ToDouble(((Label)GridView2.Rows[rowindex].FindControl("Label4")).Text.Substring(1)) * (1 - special);
            sc.TireId = tID;
            sc.Image = image;
            sc.PartNo = partNo;
            sc.Qty = qty;
            sc.Pricing = price;
            shoppingcart.Add(sc);
            Session["Cart"] = shoppingcart;
        }
    }
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClicka")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView3.Rows[rowindex];

            List<ShopingCart> shoppingcart;
            if (Session["Cart"] == null)
            {
                shoppingcart = new List<ShopingCart>();

            }
            else
            {
                shoppingcart = (List<ShopingCart>)Session["Cart"];
            }
            ShopingCart sc = new ShopingCart();
            int pID, qty;
            double price;
            string partNo;
            string image;
            string name, des;
            float special;
            special = (float)Convert.ToSingle(((Label)GridView3.Rows[rowindex].FindControl("LBSpecial")).Text);
            pID = Convert.ToInt32(GridView3.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView3.Rows[rowindex].FindControl("Label2")).Text;
            image = ((Image)GridView3.Rows[rowindex].FindControl("Image1")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView3.Rows[rowindex].FindControl("QTYTextBox")).Text);
            price = Convert.ToDouble(((Label)GridView3.Rows[rowindex].FindControl("accLabel5")).Text.Substring(1)) * special;
            name = ((Label)GridView3.Rows[rowindex].FindControl("Label7")).Text;
            sc.AccId = pID;
            sc.Qty = qty;
            sc.Pricing = price;
            sc.PartNo = partNo;
            sc.Image = image;
            sc.productName = name;
            shoppingcart.Add(sc);
            Session["Cart"] = shoppingcart;
        }
    }
}