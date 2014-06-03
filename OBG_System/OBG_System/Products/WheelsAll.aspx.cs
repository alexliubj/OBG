using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using OBGModel;
using System.Data.SqlClient;
using System.Configuration;

public partial class Products_wheelall : System.Web.UI.Page
{
    //string strProductID = "";
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
        ////Wheels wheel = new Wheels();
        //List<ShopingCart> shoppingcart = new List<ShopingCart>();
        //ShopingCart sc = new ShopingCart();
        //int pID, qty;
        //double price;
        //pID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        //qty = int.Parse(GridView1.SelectedRow.Cells[13].Text);
        //price = double.Parse(GridView1.SelectedRow.Cells[12].Text);
        //sc.ProductId = pID;
        //sc.Qty = qty;
        //sc.Pricing = price;
        //shoppingcart.Add(sc);
        //Session["Cart"] = shoppingcart;


    }
    //private void Gridview1_Bind()
    //{
    //    throw new NotImplementedException();
    //}

    private void PopuLateControl()
    {
        throw new NotImplementedException();
    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClick")
        {            
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView1.Rows[rowindex];


            List<ShopingCart> shoppingcart = new List<ShopingCart>();
            ShopingCart sc = new ShopingCart();
            int pID, qty;
            double price;
            pID = Convert.ToInt32(GridView1.DataKeys[rowindex].Value.ToString());
            qty = Convert.ToInt32(((TextBox)GridView1.Rows[rowindex].FindControl("QTYTextBox")).Text);
            price = Convert.ToDouble(((Label)GridView1.Rows[rowindex].FindControl("PriceLabel")).Text);
            sc.ProductId = pID;
            sc.Qty = qty;
            sc.Pricing = price;
            shoppingcart.Add(sc);
            Session["Cart"] = shoppingcart;
        }
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        Gridview1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        DataTable dataTable = WheelsBLO.GetAllProducts();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
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

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SqlConnection cnn = new SqlConnection(
        //    ConfigurationManager.ConnectionStrings["OBG_Local"].ConnectionString.Trim());
        //SqlCommand cmd = new SqlCommand();
        DataTable wheelsAll = WheelsBLO.GetAllProducts();
        wheelsDataSet = new DataSet();

        String sqlText = "SELECT * FROM WHEELS";
        String sqlFilterText = "";
        int index = 0;
        foreach (ListItem item in chkCountries.Items)
        {
            index += 1;
            if (item.Selected)
            {
                //String paramName ="@param" +item.Value.Trim();
                //String paramName = "@param" + index.ToString().Trim();

                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
               //param.Value = new Guid(item.Value.Trim());
                //cmd.Parameters.Add(param);
               // sqlFilterText += item.Value + paramName + " or ";
              // sqlFilterText += " ProductId = " + paramName + " or ";
                //sizeLB.Text = (Master.FindControl("sizeLB") as Label).Text;
                sqlFilterText += sizeLB.Text + " = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterText))
        {
            sqlText += " Where " + sqlFilterText.Substring(0, sqlFilterText.Length - 3);
            //sqlText += " Where " + sqlFilterText.Substring(0, sqlFilterText.Length - 4);
        }
        //cmd.CommandText = sqlText;
        //cmd.Connection = cnn;

        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable tbl = new DataTable();
        //adapter.Fill(wheelsDataSet, "Wheels");
        //adapter.Fill(wheelsAll);

        wheelsAll.DefaultView.RowFilter = sqlText;
        GridView1.DataSource = wheelsAll;
        Gridview1_Bind();
    }

}