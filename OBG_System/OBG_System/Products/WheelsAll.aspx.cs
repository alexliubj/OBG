using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using OBGModel;

public partial class Products_wheelall : System.Web.UI.Page
{
     string strProductID = "";
    //Wheels wheels = new Wheels();
    private DataSet wheelsDataSet;
    //private DataSet tiresDataSet;
    //private DataSet accessoriesDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Gridview1_Bind();

        }
        //if (!IsPostBack)
        //    PopuLateControl();
        //strProductID = Request.QueryString["ProductId"];
        //wheels = WheelsBLO.GetAllProducts();
        //lblProductId.Text = wheels.ProductId;
        //ImgProduct.ImageUrl = wheels.Image;


    }

    public void Gridview1_Bind()
    {

        DataTable wheelsAll = WheelsBLO.GetAllProducts();
        wheelsDataSet = new DataSet();
        wheelsDataSet.Tables.Add(wheelsAll);

        GridView1.DataSource = wheelsDataSet;
        GridView1.DataKeyNames = new string[] { "ProductId" };
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Gridview1_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int productID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        WheelsBLO.DeleteProductById(productID);
        Gridview1_Bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void AddBt_Click(object sender, EventArgs e)
    {
        Wheels wheel = new Wheels();

        WheelsBLO.AddNewProduct(wheel);
        Response.Redirect("~/ShoppingCart.aspx?ProductId=" + strProductID + "&Num=1");
    }
    //private void Gridview1_Bind()
    //{
    //    throw new NotImplementedException();
    //}

    private void PopuLateControl()
    {
        throw new NotImplementedException();
    }

    
}