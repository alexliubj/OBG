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




    protected void chkSize_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataTable wheelsAll = WheelsBLO.GetAllProducts();

        String sqlTextSize = "", sqlTextPCD = "", sqlTextFinish = "", sqlTextOffset = "", sqlTextSeat = "", sqlTextBore = "";  
        String sqlFilterSize = "", sqlFilterPCD = "", sqlFilterFinish = "", sqlFilterOffset = "", sqlFilterSeat = "", sqlFilterBore = "";
        int index = 0;
        foreach (ListItem item in chkSize.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
                sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterFinish += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterOffset += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSeat += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterBore += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD) )
        {
            sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        }


        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }

        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            sqlTextFinish += sqlFilterSize.Substring(0, sqlFilterFinish.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + sqlTextPCD + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }

        if (!String.IsNullOrEmpty(sqlTextOffset))
        {
            sqlTextOffset += sqlFilterOffset.Substring(0, sqlFilterOffset.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextPCD + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + sqlTextPCD + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextOffset;
        }

        if (!String.IsNullOrEmpty(sqlTextSeat))
        {
            sqlTextSeat += sqlFilterSeat.Substring(0, sqlFilterSeat.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + sqlTextFinish + sqlTextBore; 
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + sqlTextPCD + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextPCD + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat + sqlTextBore;
        }


        if (!String.IsNullOrEmpty(sqlTextBore))
        {
            sqlTextBore += sqlFilterBore.Substring(0, sqlFilterBore.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlTextBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterOffset + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterSeat + " and " + sqlTextBore + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterFinish + " and " + sqlTextBore + sqlTextOffset + sqlTextSeat + sqlTextSize + sqlTextPCD;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat;
        }

        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }
    protected void chkPCD_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataTable wheelsAll = WheelsBLO.GetAllProducts();

        //String sqlTextSize = "", sqlTextPCD = "";
        //String sqlFilterSize = "", sqlFilterPCD = "";
        //int index = 0;
        //foreach (ListItem item in chkSize.Items)
        //{
        //    index += 1;
        //    if (item.Selected)
        //    {
        //        SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

        //        sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
        //    }
        //}
        //foreach (ListItem item in chkPCD.Items)
        //{
        //    index += 1;
        //    if (item.Selected)
        //    {
        //        SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
        //        sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
        //    }
        //}

        //if (!String.IsNullOrEmpty(sqlFilterPCD))
        //{
        //    sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        //}

        //if (!String.IsNullOrEmpty(sqlFilterSize))
        //{
        //    sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        //}
        //if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        //{
        //    wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize;
        //}
        //else
        //{
        //    wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize;
        //}
        //GridView1.DataSource = wheelsAll.DefaultView;
        //GridView1.DataBind();
        ////SqlConnection cnn = new SqlConnection(
        ////    ConfigurationManager.ConnectionStrings["OBG_Local"].ConnectionString.Trim());
        ////SqlCommand cmd = new SqlCommand();
        //DataTable wheelsAll = WheelsBLO.GetAllProducts();
        //wheelsDataSet = new DataSet();

        ////String sqlText = "SELECT * FROM WHEELS";
        //String sqlText = "";
        //String sqlFilterText = "";
        //int index = 0;
        //foreach (ListItem item in chkPCD.Items)
        //{
        //    index += 1;
        //    if (item.Selected)
        //    {
        //        //String paramName ="@param" +item.Value.Trim();
        //        //String paramName = "@param" + index.ToString().Trim();

        //        SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
        //        //param.Value = new Guid(item.Value.Trim());
        //        //cmd.Parameters.Add(param);
        //        // sqlFilterText += item.Value + paramName + " or ";
        //        // sqlFilterText += " ProductId = " + paramName + " or ";
        //        //sizeLB.Text = (Master.FindControl("sizeLB") as Label).Text;
        //        sqlFilterText += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
        //    }
        //}

        //if (!String.IsNullOrEmpty(sqlFilterText))
        //{
        //    //if (Session["sqlText"] != null)
        //    //{
        //    //    sqlText += Session["sqlText"] + " and" + sqlFilterText.Substring(0, sqlFilterText.Length - 3);
        //    //}
        //    //else
        //    //{
        //        sqlText += sqlFilterText.Substring(0, sqlFilterText.Length - 3);
        //    //}
        //    //sqlText += " Where " + sqlFilterText.Substring(0, sqlFilterText.Length - 4);
        //    //Session["sqlText"] += sqlText;
        //}
        ////cmd.CommandText = sqlText;
        ////cmd.Connection = cnn;

        ////SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        ////DataTable tbl = new DataTable();
        ////adapter.Fill(wheelsDataSet, "Wheels");
        ////adapter.Fill(wheelsAll);
        //wheelsAll.DefaultView.RowFilter = sqlText;
        //GridView1.DataSource = wheelsAll.DefaultView;
        //GridView1.DataBind();

       DataTable wheelsAll = WheelsBLO.GetAllProducts();

        String sqlTextSize = "", sqlTextPCD = "", sqlTextFinish = "", sqlTextOffset = "", sqlTextSeat = "", sqlTextBore = "";  
        String sqlFilterSize = "", sqlFilterPCD = "", sqlFilterFinish = "", sqlFilterOffset = "", sqlFilterSeat = "", sqlFilterBore = "";
        int index = 0;
        foreach (ListItem item in chkSize.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
                sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterFinish += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterOffset += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSeat += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterBore += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD) )
        {
            sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        }


        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }

        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            sqlTextFinish += sqlFilterSize.Substring(0, sqlFilterFinish.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + sqlTextPCD + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }

        if (!String.IsNullOrEmpty(sqlTextOffset))
        {
            sqlTextOffset += sqlFilterOffset.Substring(0, sqlFilterOffset.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextPCD + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + sqlTextPCD + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextOffset;
        }

        if (!String.IsNullOrEmpty(sqlTextSeat))
        {
            sqlTextSeat += sqlFilterSeat.Substring(0, sqlFilterSeat.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + sqlTextFinish + sqlTextBore; 
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + sqlTextPCD + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextPCD + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat + sqlTextBore;
        }


        if (!String.IsNullOrEmpty(sqlTextBore))
        {
            sqlTextBore += sqlFilterBore.Substring(0, sqlFilterBore.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlTextBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterOffset + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterSeat + " and " + sqlTextBore + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterFinish + " and " + sqlTextBore + sqlTextOffset + sqlTextSeat + sqlTextSize + sqlTextPCD;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat;
        }

        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }
    protected void chkFinish_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable wheelsAll = WheelsBLO.GetAllProducts();

        String sqlTextSize = "", sqlTextPCD = "", sqlTextFinish = "", sqlTextOffset = "", sqlTextSeat = "", sqlTextBore = "";  
        String sqlFilterSize = "", sqlFilterPCD = "", sqlFilterFinish = "", sqlFilterOffset = "", sqlFilterSeat = "", sqlFilterBore = "";
        int index = 0;
        foreach (ListItem item in chkSize.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
                sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterFinish += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterOffset += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSeat += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterBore += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD) )
        {
            sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        }


        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }

        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            sqlTextFinish += sqlFilterSize.Substring(0, sqlFilterFinish.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + sqlTextPCD + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }

        if (!String.IsNullOrEmpty(sqlTextOffset))
        {
            sqlTextOffset += sqlFilterOffset.Substring(0, sqlFilterOffset.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextPCD + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + sqlTextPCD + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextOffset;
        }

        if (!String.IsNullOrEmpty(sqlTextSeat))
        {
            sqlTextSeat += sqlFilterSeat.Substring(0, sqlFilterSeat.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + sqlTextFinish + sqlTextBore; 
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + sqlTextPCD + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextPCD + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat + sqlTextBore;
        }


        if (!String.IsNullOrEmpty(sqlTextBore))
        {
            sqlTextBore += sqlFilterBore.Substring(0, sqlFilterBore.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlTextBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterOffset + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterSeat + " and " + sqlTextBore + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterFinish + " and " + sqlTextBore + sqlTextOffset + sqlTextSeat + sqlTextSize + sqlTextPCD;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat;
        }

        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }
 
    protected void chkOffset_SelectedIndexChanged(object sender, EventArgs e)
    {
       DataTable wheelsAll = WheelsBLO.GetAllProducts();

        String sqlTextSize = "", sqlTextPCD = "", sqlTextFinish = "", sqlTextOffset = "", sqlTextSeat = "", sqlTextBore = "";  
        String sqlFilterSize = "", sqlFilterPCD = "", sqlFilterFinish = "", sqlFilterOffset = "", sqlFilterSeat = "", sqlFilterBore = "";
        int index = 0;
        foreach (ListItem item in chkSize.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
                sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterFinish += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterOffset += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSeat += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterBore += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD) )
        {
            sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        }


        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }

        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            sqlTextFinish += sqlFilterSize.Substring(0, sqlFilterFinish.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + sqlTextPCD + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }

        if (!String.IsNullOrEmpty(sqlTextOffset))
        {
            sqlTextOffset += sqlFilterOffset.Substring(0, sqlFilterOffset.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextPCD + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + sqlTextPCD + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextOffset;
        }

        if (!String.IsNullOrEmpty(sqlTextSeat))
        {
            sqlTextSeat += sqlFilterSeat.Substring(0, sqlFilterSeat.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + sqlTextFinish + sqlTextBore; 
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + sqlTextPCD + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextPCD + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat + sqlTextBore;
        }


        if (!String.IsNullOrEmpty(sqlTextBore))
        {
            sqlTextBore += sqlFilterBore.Substring(0, sqlFilterBore.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlTextBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterOffset + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterSeat + " and " + sqlTextBore + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterFinish + " and " + sqlTextBore + sqlTextOffset + sqlTextSeat + sqlTextSize + sqlTextPCD;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat;
        }

        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }
    protected void chkSeat_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable wheelsAll = WheelsBLO.GetAllProducts();

        String sqlTextSize = "", sqlTextPCD = "", sqlTextFinish = "", sqlTextOffset = "", sqlTextSeat = "", sqlTextBore = "";  
        String sqlFilterSize = "", sqlFilterPCD = "", sqlFilterFinish = "", sqlFilterOffset = "", sqlFilterSeat = "", sqlFilterBore = "";
        int index = 0;
        foreach (ListItem item in chkSize.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
                sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterFinish += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterOffset += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSeat += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterBore += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD) )
        {
            sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        }


        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }

        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            sqlTextFinish += sqlFilterSize.Substring(0, sqlFilterFinish.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + sqlTextPCD + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }

        if (!String.IsNullOrEmpty(sqlTextOffset))
        {
            sqlTextOffset += sqlFilterOffset.Substring(0, sqlFilterOffset.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextPCD + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + sqlTextPCD + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextOffset;
        }

        if (!String.IsNullOrEmpty(sqlTextSeat))
        {
            sqlTextSeat += sqlFilterSeat.Substring(0, sqlFilterSeat.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + sqlTextFinish + sqlTextBore; 
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + sqlTextPCD + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextPCD + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat + sqlTextBore;
        }


        if (!String.IsNullOrEmpty(sqlTextBore))
        {
            sqlTextBore += sqlFilterBore.Substring(0, sqlFilterBore.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlTextBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterOffset + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterSeat + " and " + sqlTextBore + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterFinish + " and " + sqlTextBore + sqlTextOffset + sqlTextSeat + sqlTextSize + sqlTextPCD;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat;
        }

        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }
    protected void chkBore_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable wheelsAll = WheelsBLO.GetAllProducts();

        String sqlTextSize = "", sqlTextPCD = "", sqlTextFinish = "", sqlTextOffset = "", sqlTextSeat = "", sqlTextBore = "";  
        String sqlFilterSize = "", sqlFilterPCD = "", sqlFilterFinish = "", sqlFilterOffset = "", sqlFilterSeat = "", sqlFilterBore = "";
        int index = 0;
        foreach (ListItem item in chkSize.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSize += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);
                sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'" + " or ";
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterFinish += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterOffset += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterSeat += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            index += 1;
            if (item.Selected)
            {
                SqlParameter param = new SqlParameter(item.Value.Trim(), SqlDbType.UniqueIdentifier);

                sqlFilterBore += "size = " + "'" + item.Value.Trim() + "'" + " or ";
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD) )
        {
            sqlTextPCD += sqlFilterPCD.Substring(0, sqlFilterPCD.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            sqlTextSize += sqlFilterSize.Substring(0, sqlFilterSize.Length - 3);
        }


        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore + sqlTextFinish;
        }

        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            sqlTextFinish += sqlFilterSize.Substring(0, sqlFilterFinish.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + sqlTextPCD + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextOffset + sqlTextBore;
        }

        if (!String.IsNullOrEmpty(sqlTextOffset))
        {
            sqlTextOffset += sqlFilterOffset.Substring(0, sqlFilterOffset.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextPCD + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + sqlTextPCD + sqlTextFinish + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + sqlTextPCD + sqlTextSize + sqlTextSeat + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextOffset;
        }

        if (!String.IsNullOrEmpty(sqlTextSeat))
        {
            sqlTextSeat += sqlFilterSeat.Substring(0, sqlFilterSeat.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + sqlTextFinish + sqlTextBore; 
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + sqlTextPCD + sqlTextSize + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + sqlTextPCD + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextFinish + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + sqlTextSize + sqlTextOffset + sqlTextPCD + sqlTextBore;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat + sqlTextBore;
        }


        if (!String.IsNullOrEmpty(sqlTextBore))
        {
            sqlTextBore += sqlFilterBore.Substring(0, sqlFilterBore.Length - 3);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlTextBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextFinish + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextFinish + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextOffset + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextSize + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextPCD + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextFinish;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextFinish + " and " + sqlTextSeat + " and " + sqlTextBore + sqlTextSize + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSize) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextSize + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterPCD) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextOffset + sqlTextSize;
        }
        else if (!String.IsNullOrEmpty(sqlFilterOffset) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterOffset + " and " + sqlTextBore + sqlTextSeat + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterSeat) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterSeat + " and " + sqlTextBore + sqlTextOffset + sqlTextFinish + sqlTextSize + sqlTextPCD;
        }
        else if (!String.IsNullOrEmpty(sqlFilterFinish) && !String.IsNullOrEmpty(sqlFilterBore))
        {
            wheelsAll.DefaultView.RowFilter = sqlFilterFinish + " and " + sqlTextBore + sqlTextOffset + sqlTextSeat + sqlTextSize + sqlTextPCD;
        }
        else
        {
            wheelsAll.DefaultView.RowFilter = sqlTextPCD + sqlTextSize + sqlTextFinish + sqlFilterOffset + sqlTextSeat;
        }

        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }
}