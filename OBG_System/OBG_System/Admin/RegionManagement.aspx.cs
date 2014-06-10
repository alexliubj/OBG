using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Default : System.Web.UI.Page
{
    private DataSet regionDataSet;
    private DataSet regionUserDataSet;
    int adminID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminID"] != null)
        {
            adminID = (int)Session["AdminID"];
        }
        else
        {
            Response.Redirect("~/Admin/Login.aspx");
        }

        if (!IsPostBack)
        {
            bind();
            Gridview2_Bind();
        }
    }

    #region region
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int regionID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        RegionBLO.RemoveShippingById(regionID);
        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    public void bind()
    {

        DataTable regionTable = RegionBLO.GetAllShipping();
        regionDataSet = new DataSet();
        regionDataSet.Tables.Add(regionTable);

        GridView1.DataSource = regionDataSet;
        GridView1.DataKeyNames = new string[] { "regionid" };
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Shipping region = new Shipping();
        int regionID;
        regionID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        region.RegionId = regionID;
        region.RegionName = RegionName.Text;
        region.RegionPrice = Math.Round(Convert.ToDouble(Price.Text),2);
        region.DevMethods = DevMethods.Text;

        int update = 0;
        update = RegionBLO.UpdateShipping(region);

        if (update == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Region information has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Region information failed.');",
                        true);
        }
        bind();
    }
    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        regionInformation.Visible = false;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int regionID;
        regionID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        Shipping region = new Shipping();

        // region = UserBLO.GetUserInfoWithUserId(userID);
        RegionName.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label2"))).Text;
        Price.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label3"))).Text;
        DevMethods.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label4"))).Text;

        regionInformation.Visible = true;
        BtnAdd.Visible = false;
        BtnSave.Visible = true;
    }
    protected void btnAddRegion_Click(object sender, EventArgs e)
    {
        RegionName.Text = null;
        Price.Text = null;
        DevMethods.Text = null;

        regionInformation.Visible = true;
        BtnAdd.Visible = true;
        BtnSave.Visible = false;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Shipping region = new Shipping();

        region.RegionName = RegionName.Text;
        region.RegionPrice = Math.Round(Convert.ToDouble(Price.Text), 2);
        region.DevMethods = DevMethods.Text;

        int newId = RegionBLO.AddNewShippping(region);

        if (newId > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                            "err_msg",
                            "alert('success.');", true);
        }
        bind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = RegionBLO.GetAllShipping();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
    }
    #endregion

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

    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Region Management")
        {
            regionManagement.Visible = true;
            regionUserManagement.Visible = false;
        }
        if (e.Item.Text == "Assign Region to User")
        {
            regionManagement.Visible = false;
            regionUserManagement.Visible = true;
        }

        MenuItem ms = NavigationMenu.FindItem(e.Item.Text);
        if (ms != null)
        {
            ms.Selectable = false;
        }
    }

    #region regionUser
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void Gridview2_Bind()
    {
        DataTable userRegionTable = UserBLO.GetAllUsersWithTheirRegionName();
        regionUserDataSet = new DataSet();
        regionUserDataSet.Tables.Add(userRegionTable);

        GridView2.DataSource = regionUserDataSet;
        GridView2.DataKeyNames = new string[] { "UserID" };
        GridView2.DataBind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlSelectRegionName = (e.Row.FindControl("ddlSelectRegionName") as DropDownList);

            DataTable regionsTable = RegionBLO.GetAllShipping();
            regionDataSet = new DataSet();
            regionDataSet.Tables.Add(regionsTable);

            ddlSelectRegionName.DataSource = regionDataSet;
            ddlSelectRegionName.DataTextField = "RegionName";
            ddlSelectRegionName.DataValueField = "RegionID";
            ddlSelectRegionName.DataBind();

            ddlSelectRegionName.Items.Insert(0, new ListItem("Please select"));

            string RegionID = (e.Row.FindControl("lblSelectRegionID") as Label).Text;
            ddlSelectRegionName.Items.FindByValue(RegionID).Selected = true;
        }
    }

    protected void ddlSelectRegionName_Change(object sender, EventArgs e)
    {
        // DropDownList ddlSelectRoleName = (GridView2.FindControl("ddlSelectRoleName") as DropDownList);
        //string roleID = ddlSelectRoleName.SelectedValue;
        // RoleBLO.
        //TBA

        DropDownList ddl = (DropDownList)sender;
        GridViewRow gdv = (GridViewRow)ddl.NamingContainer;
        int index = gdv.RowIndex;

        if (((DropDownList)(GridView2.Rows[index].FindControl("ddlSelectRegionName"))).SelectedValue.ToString() != "Please select")
        {
            int userID, RegionID;

            userID = int.Parse((((Label)(GridView2.Rows[index].FindControl("Label2"))).Text));
            RegionID = int.Parse((((DropDownList)(GridView2.Rows[index].FindControl("ddlSelectRegionName"))).SelectedValue.ToString()));
            User user = UserBLO.GetUserInfoWithUserId(userID);
            user.RegionId = RegionID;
            user.Userid = userID;

            int update = 0;
            update = UserBLO.UpdateUserInfo(user);

            if (update > 0)
            {
                Gridview2_Bind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                       "err_msg",
                                       "alert('Sorry, Changing region for user failed.');",
                                       true);
            }
        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        Gridview2_Bind();
    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = UserBLO.GetAllUsersWithTheirRegionName();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView2.DataSource = dataView;
            GridView2.DataBind();
        }
    }

    #endregion

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView1.PageIndex = 0;
        bind();
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
        Gridview2_Bind();
    }

    protected void GridView2_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }
}