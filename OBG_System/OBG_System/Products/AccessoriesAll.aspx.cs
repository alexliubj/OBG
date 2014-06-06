using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;

public partial class Products_accAll : System.Web.UI.Page
{
    private DataSet AccDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView6_Bind();
        }
    }
    public void GridView6_Bind()
    {

        DataTable tiresTable = AccessoryBLO.GetAllAccessories();
        AccDataSet = new DataSet();
        AccDataSet.Tables.Add(tiresTable);

        GridView6.DataSource = AccDataSet;
        GridView6.DataKeyNames = new string[] { "AccId" };
        GridView6.DataBind();
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView6.EditIndex = e.NewEditIndex;
        GridView6_Bind();

    }

    //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int TireID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
    //    TiresBLO.DeleteTire(TireID);
    //    GridView2_Bind();
    //}

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView6.EditIndex = -1;
        GridView6_Bind();
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView6.EditIndex = -1;
        GridView6_Bind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView6_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView6.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        GridView6_Bind();
    }

    protected void GridView6_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        DataTable dataTable = AccessoryBLO.GetAllAccessories();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView6.DataSource = dataView;
            GridView6.DataBind();
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

    protected void chk_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable accAll = AccessoryBLO.GetAllAccessories();
        String sqlText = string.Empty;
        String sqlFilterName = string.Empty;
        foreach (ListItem item in ChkName.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterName != string.Empty)
                {
                    sqlFilterName += " or " + "Name = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterName += "Name = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterName))
        {
            sqlText += sorroundWithbrackets(sqlFilterName);
        }

        accAll.DefaultView.RowFilter = sqlText;
        GridView6.DataSource = accAll.DefaultView;
        GridView6.DataBind();
    }

    private string sorroundWithbrackets(string orString)
    {
        return "(" + orString + ")";
    }
}