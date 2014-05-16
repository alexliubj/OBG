using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;

public partial class Products_accessories : System.Web.UI.Page
{
    private DataSet accessoriesDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView3_Bind();
        }
    }
    public void GridView3_Bind()
    {

        DataTable accessoriesTable = AccessoryBLO.GetAllAccessories();
        accessoriesDataSet = new DataSet();
        accessoriesDataSet.Tables.Add(accessoriesTable);

        GridView3.DataSource = accessoriesDataSet;
        GridView3.DataKeyNames = new string[] { "AccId" };
        GridView3.DataBind();
    }

    protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView3.EditIndex = e.NewEditIndex;
        GridView3_Bind();

    }

    //protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int AccID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
    //    AccessoryBLO.DeleteOneAccessory(AccID);
    //    GridView3_Bind();
    //}

    protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView3.EditIndex = -1;
        GridView3_Bind();
    }

    protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView3.EditIndex = -1;
        GridView3_Bind();
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}