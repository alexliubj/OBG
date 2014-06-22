using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

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

        DataTable specialwheel = SpecialBLO.GetAllSpecialWheels();
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
        DataTable dataTable = SpecialBLO.GetAllSpecialWheels();

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

        DataTable Specialtire = SpecialBLO.GetAllSpecialTires();
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
        DataTable dataTable = SpecialBLO.GetAllSpecialTires();

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

        DataTable specialacc = SpecialBLO.GetAllSpecialAcces();
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
        DataTable dataTable = SpecialBLO.GetAllSpecialAcces();

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

}