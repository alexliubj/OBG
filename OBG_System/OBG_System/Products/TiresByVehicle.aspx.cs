using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using OBGModel;

public partial class Products_tireByVehicle : System.Web.UI.Page
{
    string strProductID = "";
    private DataSet tiresDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView5_Bind();
        }
    }
    public void GridView5_Bind()
    {

        DataTable tiresTable = TiresBLO.GetAllTires();
        tiresDataSet = new DataSet();
        tiresDataSet.Tables.Add(tiresTable);

        GridView5.DataSource = tiresDataSet;
        GridView5.DataKeyNames = new string[] { "TireId" };
        GridView5.DataBind();
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView5.EditIndex = e.NewEditIndex;
        GridView5_Bind();

    }

    //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int TireID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
    //    TiresBLO.DeleteTire(TireID);
    //    GridView2_Bind();
    //}

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView5.EditIndex = -1;
        GridView5_Bind();
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView5.EditIndex = -1;
        GridView5_Bind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void AddBt_Click(object sender, EventArgs e)
    {
        Tire tire = new Tire();
        TiresBLO.CreateNewTire(tire);
        Response.Redirect("~/ShoppingCart.aspx?ProductId=" + strProductID + "&Num=1");
    }
}