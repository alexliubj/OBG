using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using OBGModel;


public partial class Products_viewByVehicle : System.Web.UI.Page
{
    string strProductID = "";
    private DataSet wheelsDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridview4_Bind();
            //DataListDepartMent.DataSource = CategoryBLO.GetAllCategory();
            //DataListDepartMent.DataBind();
            //PopuControl();
        }

    }

    private void Gridview4_Bind()
    {

        DataTable wheelsAll = WheelsBLO.GetAllProducts();
        wheelsDataSet = new DataSet();
        wheelsDataSet.Tables.Add(wheelsAll);

        GridView4.DataSource = wheelsDataSet;
        GridView4.DataKeyNames = new string[] { "ProductId" };
        GridView4.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView4.EditIndex = e.NewEditIndex;
        Gridview4_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int productID = Convert.ToInt32(GridView4.DataKeys[e.RowIndex].Value.ToString());
        WheelsBLO.DeleteProductById(productID);
        Gridview4_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView4.EditIndex = -1;
        Gridview4_Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView4.EditIndex = -1;
        Gridview4_Bind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    //private void Gridview1_Bind()
    //{
    //    throw new NotImplementedException();
    //}

    private void PopuLateControl()
    {
        throw new NotImplementedException();
    }
    //protected void PopuControl()
    //{
    //    string strQuestring = Request.QueryString["Brand"];
    //    if (strQuestring != null)
    //    {
    //        DataListCateGory.DataSource = CategoryBLO.GetAllCategory();
    //        DataListCateGory.DataBind();
            
    //    }
    //}
    protected void AddBt_Click(object sender, EventArgs e)
    {
        Wheels wheels = new Wheels();
        WheelsBLO.AddNewProduct(wheels);
        Response.Redirect("~/ShoppingCart.aspx?ProductId=" + strProductID + "&Num=1");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        Gridview4_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        DataTable dataTable = WheelsBLO.GetAllProducts();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView4.DataSource = dataView;
            GridView4.DataBind();
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
}