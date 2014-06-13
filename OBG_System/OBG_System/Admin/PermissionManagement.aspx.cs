using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Default : System.Web.UI.Page
{
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
            Gridview1_Bind();
        }

    }

    #region Permission
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public void Gridview1_Bind()
    {

        DataTable permissionTable = PermissionBLO.GetPermissions();

        GridView1.DataSource = permissionTable;
        GridView1.DataKeyNames = new string[] { "UserID" };
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox checkBoxWheel = (e.Row.FindControl("checkBoxWheel") as CheckBox);
            CheckBox checkBoxTire = (e.Row.FindControl("checkBoxTire") as CheckBox);
            CheckBox checkBoxAccessory = (e.Row.FindControl("checkBoxAccessory") as CheckBox);

            int userID = int.Parse((e.Row.FindControl("Label3") as Label).Text);

            List<int> permissions = PermissionBLO.GetPermissionByUserID(userID);
            if (permissions[0] == 1)
            {
                checkBoxWheel.Checked = true;
            }
            else
            {
                checkBoxWheel.Checked = false;
            }
            if (permissions[1] == 1)
            {
                checkBoxTire.Checked = true;
            }
            else
            {
                checkBoxTire.Checked = false;
            }
            if (permissions[2] == 1)
            {
                checkBoxAccessory.Checked = true;
            }
            else
            {
                checkBoxAccessory.Checked = false;
            }
        }
    }

    protected void checkBoxWheel_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        GridViewRow gdv = (GridViewRow)checkBox.NamingContainer;
        int index = gdv.RowIndex;

        int userID;
        userID = int.Parse((((Label)(GridView1.Rows[index].FindControl("Label3"))).Text));
        List<int> permissions = PermissionBLO.GetPermissionByUserID(userID);

        if (((CheckBox)(GridView1.Rows[index].FindControl("checkBoxWheel"))).Checked == true)
        {
            permissions[0] = 1;
        }
        else
        {
            permissions[0] = 0;
        }
        int update = 0;
        update = PermissionBLO.UpdatePermission(userID, permissions);
        if (update > 0)
        {
            Gridview1_Bind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                   "err_msg",
                                   "alert('Sorry, Changing permission for user failed.');",
                                   true);
        }
    }

    protected void checkBoxTire_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        GridViewRow gdv = (GridViewRow)checkBox.NamingContainer;
        int index = gdv.RowIndex;

        int userID;
        userID = int.Parse((((Label)(GridView1.Rows[index].FindControl("Label3"))).Text));
        List<int> permissions = PermissionBLO.GetPermissionByUserID(userID);

        if (((CheckBox)(GridView1.Rows[index].FindControl("checkBoxTire"))).Checked == true)
        {
            permissions[1] = 1;
        }
        else
        {
            permissions[1] = 0;
        }
        int update = 0;
        update = PermissionBLO.UpdatePermission(userID, permissions);
        if (update > 0)
        {
            Gridview1_Bind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                   "err_msg",
                                   "alert('Sorry, Changing permission for user failed.');",
                                   true);
        }
    }
    protected void checkBoxAccessory_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        GridViewRow gdv = (GridViewRow)checkBox.NamingContainer;
        int index = gdv.RowIndex;

        int userID;
        userID = int.Parse((((Label)(GridView1.Rows[index].FindControl("Label3"))).Text));
        List<int> permissions = PermissionBLO.GetPermissionByUserID(userID);

        if (((CheckBox)(GridView1.Rows[index].FindControl("checkBoxAccessory"))).Checked == true)
        {
            permissions[2] = 1;
        }
        else
        {
            permissions[2] = 0;
        }
        int update = 0;
        update = PermissionBLO.UpdatePermission(userID, permissions);
        if (update > 0)
        {
            Gridview1_Bind();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                                   "err_msg",
                                   "alert('Sorry, Changing permission for user failed.');",
                                   true);
        }
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
        DataTable dataTable = PermissionBLO.GetPermissions();

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

}