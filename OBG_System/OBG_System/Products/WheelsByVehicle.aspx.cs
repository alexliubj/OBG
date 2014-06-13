using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using OBGModel;
using DataAccess;


public partial class Products_viewByVehicle : System.Web.UI.Page
{
    string strProductID = "";
    private DataSet wheelsDataSet;
    int userID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClick")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView4.Rows[rowindex];
            List<ShopingCart> shoppingcart;

            if (Session["Cart"] == null)
            {
                shoppingcart = new List<ShopingCart>();

            }
            else
            {
                shoppingcart = (List<ShopingCart>)Session["Cart"];
            }
            ShopingCart sc = new ShopingCart();
            int pID, qty;
            double price;
            string partNo;
            string image;
            pID = Convert.ToInt32(GridView4.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView4.Rows[rowindex].FindControl("PNLabel")).Text;
            image = ((Image)GridView4.Rows[rowindex].FindControl("ImageLable")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView4.Rows[rowindex].FindControl("QTYTextBox")).Text);
            price = Convert.ToDouble(((Label)GridView4.Rows[rowindex].FindControl("PriceLabel")).Text);
            sc.ProductId = pID;
            sc.Qty = qty;
            sc.Pricing = price;
            sc.PartNo = partNo;
            sc.Image = image;
            shoppingcart.Add(sc);
            Session["Cart"] = shoppingcart;

        }
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
        //WheelsBLO.AddNewProduct(wheels);
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

    protected void chk_SelectedIndexChanged(object sender, EventArgs e)
    {
        int vehicleid = 0;
        vehicleid = int.Parse(rdVehicle.SelectedValue);
        DataTable wheel = WheelsBLO.GetAllProducts();
        DataTable wheelsVehicle = WheelsBLO.GetProductIdByVehicle(vehicleid);
        String sqlText = string.Empty;
        List<int> wheelsids = new List<int>();
        
        for(int i = 0; i< wheelsVehicle.Rows.Count; i++)
        {

            wheelsids.Add(Convert.ToInt32(wheelsVehicle.Rows[i]["wheelsid"]));

        }
        List<int> distictWheels = (from id in wheelsids select id).Distinct().ToList();
        String sqlFilterVehicle = string.Empty;
        for (int i = 0; i < distictWheels.Count; i++)
        {


            if (sqlFilterVehicle != string.Empty)
            {
                sqlFilterVehicle += " or productid = " + "'" + distictWheels[i] + "'";
            }
            else
            {
                sqlFilterVehicle += "productid = " + "'" + distictWheels[i] + "'";
            }
            
        }
        wheel.DefaultView.RowFilter = sqlFilterVehicle;
        GridView4.DataSource = wheel.DefaultView;
        GridView4.DataBind();
    }
}