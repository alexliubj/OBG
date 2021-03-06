﻿using System;
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
    int userID = 0;
    //DataTable wheelsAll = WheelsBLO.GetAllProducts(userID);
    String sqlText = string.Empty;
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
                    //Response.Write("<script language='javascript'>alert('Your account does not have permission to access this page');</script>");
                    //Server.Transfer("~/Account/UserCenter.aspx", true);
                    wheelFilter.Visible = false;
                    divWheel.Visible = false;
                    PermissionDenied.Visible = true;
                }
                else
                {
                    wheelFilter.Visible = true;
                    divWheel.Visible = true;
                }
            }
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
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

        DataTable wheelsAll = WheelsBLO.GetAllProducts(userID);
        wheelsDataSet = new DataSet();
        wheelsDataSet.Tables.Add(wheelsAll);

        GridView1.DataSource = wheelsDataSet;
        GridView1.DataKeyNames = new string[] { "ProductId" };
        //double special = (float)Convert.ToSingle(((Label)GridView1.Rows[rowindex].FindControl("LBSpecial1")).Text);
        //double price = Convert.ToDouble(((Label)GridView1.Rows[rowindex].FindControl("PriceLabel")).Text.Substring(1)) * special;
        GridView1.DataBind();


    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        Gridview1_Bind();

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView1.EditIndex = -1;
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

    protected void GridView1_RowDataBound(object sender, GridViewDeleteEventArgs e)
    {
        GridView1.EditIndex = -1;
        Gridview1_Bind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

        //string des = WheelsBLO.GetDesByProductId(ProductId);
        //Response.Write()
    }

    protected void AddBt_Click(object sender, EventArgs e)
    {
        //int productId = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        //string des = WheelsBLO.GetDesByProductId(productId);
        //Response.Write(des);
    }
    //private void Gridview1_Bind()
    //{
    //    throw new NotImplementedException();
    //}

    private void PopuLateControl()
    {
        throw new NotImplementedException();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        //for(int i = 0;)
        //double special1 = (float)Convert.ToSingle(((Label)GridView1..Cell[].Rows[rowindex].FindControl("sPriceLabel")).Text);
        //double price1 = Convert.ToDouble(((Label)GridView1.Rows[rowindex].FindControl("PriceLabel")).Text.Substring(1));
        //if (special1 != price1)
        //{
        //    ((Label)GridView1.Rows[rowindex].FindControl("sPriceLabel")).ForeColor=System.Drawing.Color.Red;
        //}
        if (e.CommandName == "MyButtonClick")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView1.Rows[rowindex];
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
            float special;
            pID = Convert.ToInt32(GridView1.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView1.Rows[rowindex].FindControl("PNLabel")).Text;
            image = ((Image)GridView1.Rows[rowindex].FindControl("Image1")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView1.Rows[rowindex].FindControl("QTYTextBox")).Text);
            special = (float)Convert.ToSingle(((Label)GridView1.Rows[rowindex].FindControl("LBSpecial1")).Text);
            if((bool)((Label)GridView1.Rows[rowindex].FindControl("sPriceLabel")).Visible==true)
            { price = Convert.ToDouble(((Label)GridView1.Rows[rowindex].FindControl("sPriceLabel")).Text.Substring(1)); sc.Pricing = price; }
            if ((bool)((Label)GridView1.Rows[rowindex].FindControl("lbPrice")).Visible == true)
            { price = Convert.ToDouble(((Label)GridView1.Rows[rowindex].FindControl("lbPrice")).Text.Substring(1)); sc.Pricing = price; }

            bool flag = false;
            for (int i = 0; i < shoppingcart.Count(); i++)
            {
                if (shoppingcart[i].ProductId == pID)
                {
                    shoppingcart[i].Qty += qty;
                    flag = true;
                }
            }

            if (flag == false)
            {
                sc.ProductId = pID;
                sc.Qty = qty;

                sc.PartNo = partNo;
                sc.Image = image;
                shoppingcart.Add(sc);
            }

            Session["Cart"] = shoppingcart;

            //string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/");
            //ClientScript.RegisterStartupScript(GetType(), "", "<script>window.location.href=host+products/wheelsall.aspx</script>");
        }

        //if (e.CommandName == "DesClick")
        //{
        //   // int rowindex = Convert.ToInt32(e.CommandArgument);
        //    int productID = Convert.ToInt32(GridView1.DataKeys[rowindex].Value.ToString());
        //    string des = WheelsBLO.GetDesByProductId(productID);
        //    divDes.Visible = true;
        //    lblDes.Text = des;
        //}
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        chkPCD_SelectedIndexChanged(sender, e);
        //Gridview1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        DataTable dataTable = WheelsBLO.GetAllProducts(userID);
        
        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);           
            String sqlText = string.Empty;
            String sqlFilterSize = string.Empty, sqlFilterPCD = string.Empty, sqlFilterFinish = string.Empty,
                sqlFilterOffset = string.Empty, sqlFilterSeat = string.Empty, sqlFilterBore = string.Empty;
            foreach (ListItem item in chkSize.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterSize != string.Empty)
                    {
                        sqlFilterSize += " or " + "size = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterSize += "size = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }
            foreach (ListItem item in chkPCD.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterPCD != string.Empty)
                    {
                        sqlFilterPCD += " or " + "PCD = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }
            foreach (ListItem item in chkFinish.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterFinish != string.Empty)
                    {
                        sqlFilterFinish += " or " + "Finish = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterFinish += "Finish = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            foreach (ListItem item in chkOffset.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterOffset != string.Empty)
                    {
                        sqlFilterOffset += " or " + "Offset = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterOffset += "Offset = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            foreach (ListItem item in chkSeat.Items)
            {
                if (item.Selected)
                {
                    if (
                        sqlFilterSeat != string.Empty)
                    {
                        sqlFilterSeat += " or " + "seat = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterSeat += "seat = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            foreach (ListItem item in chkBore.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterBore != string.Empty)
                    {
                        sqlFilterBore += " or " + "Bore = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterBore += "Bore = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            if (!String.IsNullOrEmpty(sqlFilterPCD))
            {
                sqlText += sorroundWithbrackets(sqlFilterPCD);
            }

            if (!String.IsNullOrEmpty(sqlFilterSize))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD))
                {
                    sqlText += sorroundWithbrackets(sqlFilterSize);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterSize);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterFinish))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                  && String.IsNullOrEmpty(sqlFilterSize))
                {
                    sqlText += sorroundWithbrackets(sqlFilterFinish);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterFinish);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterOffset))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish))
                {
                    sqlText += sorroundWithbrackets(sqlFilterOffset);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterOffset);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterSeat))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish)
                && String.IsNullOrEmpty(sqlFilterOffset))
                {
                    sqlText += sorroundWithbrackets(sqlFilterSeat);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterSeat);
                }
            }

            if (!String.IsNullOrEmpty(sqlFilterBore))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish)
                && String.IsNullOrEmpty(sqlFilterOffset) && String.IsNullOrEmpty(sqlFilterSeat))
                {
                    sqlText += sorroundWithbrackets(sqlFilterBore);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterBore);
                }

            }

            dataTable.DefaultView.RowFilter = sqlText;
            //GridView1.DataSource  = dataView;
            GridView1.DataSource = dataTable.DefaultView;
            GridView1.DataBind();
            //GridView1.DataBind();
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

    protected void chkPCD_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable wheelsAll = WheelsBLO.GetAllProducts(userID);
        //String sqlText = string.Empty;
        String sqlFilterSize = string.Empty, sqlFilterPCD = string.Empty, sqlFilterFinish = string.Empty,
            sqlFilterOffset = string.Empty, sqlFilterSeat = string.Empty, sqlFilterBore = string.Empty;
        foreach (ListItem item in chkSize.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterSize != string.Empty)
                {
                    sqlFilterSize += " or " + "size = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterSize += "size = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }
        foreach (ListItem item in chkPCD.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterPCD != string.Empty)
                {
                    sqlFilterPCD += " or " + "PCD = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }
        foreach (ListItem item in chkFinish.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterFinish != string.Empty)
                {
                    sqlFilterFinish += " or " + "Finish = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterFinish += "Finish = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }

        foreach (ListItem item in chkOffset.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterOffset != string.Empty)
                {
                    sqlFilterOffset += " or " + "Offset = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterOffset += "Offset = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }

        foreach (ListItem item in chkSeat.Items)
        {
            if (item.Selected)
            {
                if (
                    sqlFilterSeat != string.Empty)
                {
                    sqlFilterSeat += " or " + "seat = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterSeat += "seat = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }

        foreach (ListItem item in chkBore.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterBore != string.Empty)
                {
                    sqlFilterBore += " or " + "Bore = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterBore += "Bore = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterPCD))
        {
            sqlText += sorroundWithbrackets(sqlFilterPCD);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            if (String.IsNullOrEmpty(sqlFilterPCD))
            {
                sqlText += sorroundWithbrackets(sqlFilterSize);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterSize);
            }
        }
        if (!String.IsNullOrEmpty(sqlFilterFinish))
        {
            if (String.IsNullOrEmpty(sqlFilterPCD)
              && String.IsNullOrEmpty(sqlFilterSize))
            {
                sqlText += sorroundWithbrackets(sqlFilterFinish);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterFinish);
            }
        }
        if (!String.IsNullOrEmpty(sqlFilterOffset))
        {
            if (String.IsNullOrEmpty(sqlFilterPCD)
            && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish))
            {
                sqlText += sorroundWithbrackets(sqlFilterOffset);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterOffset);
            }
        }
        if (!String.IsNullOrEmpty(sqlFilterSeat))
        {
            if (String.IsNullOrEmpty(sqlFilterPCD)
            && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish)
            && String.IsNullOrEmpty(sqlFilterOffset))
            {
                sqlText += sorroundWithbrackets(sqlFilterSeat);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterSeat);
            }
        }

        if (!String.IsNullOrEmpty(sqlFilterBore))
        {
            if (String.IsNullOrEmpty(sqlFilterPCD)
            && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish)
            && String.IsNullOrEmpty(sqlFilterOffset) && String.IsNullOrEmpty(sqlFilterSeat))
            {
                sqlText += sorroundWithbrackets(sqlFilterBore);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterBore);
            }

        }
        wheelsAll.DefaultView.RowFilter = sqlText;
        GridView1.DataSource = wheelsAll.DefaultView;
        GridView1.DataBind();
    }

    private string sorroundWithbrackets(string orString)
    {
        return "(" + orString + ")";
    }

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView1.PageIndex = 0;
        
        //chkPCD_SelectedIndexChanged(object sender1, EventArgs e1);
        DataTable wheelsAll = WheelsBLO.GetAllProducts(userID);
        //if (wheelsAll.DefaultView.RowFilter == sqlText && GridView1.DataSource == wheelsAll.DefaultView)
        //{
            
           // GridView1.DataBind();
        //}
        if (wheelsAll.DefaultView.RowFilter == null && GridView1.DataSource == null)
        //GridView1.DataSource = wheelsAll.DefaultView;
        //GridView1.DataBind();
        //else
        {
            //GridView1.DataBind();
            Gridview1_Bind();
        }
        else
        {
            String sqlFilterSize = string.Empty, sqlFilterPCD = string.Empty, sqlFilterFinish = string.Empty,
           sqlFilterOffset = string.Empty, sqlFilterSeat = string.Empty, sqlFilterBore = string.Empty;
            foreach (ListItem item in chkSize.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterSize != string.Empty)
                    {
                        sqlFilterSize += " or " + "size = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterSize += "size = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }
            foreach (ListItem item in chkPCD.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterPCD != string.Empty)
                    {
                        sqlFilterPCD += " or " + "PCD = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterPCD += "PCD = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }
            foreach (ListItem item in chkFinish.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterFinish != string.Empty)
                    {
                        sqlFilterFinish += " or " + "Finish = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterFinish += "Finish = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            foreach (ListItem item in chkOffset.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterOffset != string.Empty)
                    {
                        sqlFilterOffset += " or " + "Offset = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterOffset += "Offset = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            foreach (ListItem item in chkSeat.Items)
            {
                if (item.Selected)
                {
                    if (
                        sqlFilterSeat != string.Empty)
                    {
                        sqlFilterSeat += " or " + "seat = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterSeat += "seat = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            foreach (ListItem item in chkBore.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterBore != string.Empty)
                    {
                        sqlFilterBore += " or " + "Bore = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterBore += "Bore = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }

            if (!String.IsNullOrEmpty(sqlFilterPCD))
            {
                sqlText += sorroundWithbrackets(sqlFilterPCD);
            }

            if (!String.IsNullOrEmpty(sqlFilterSize))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD))
                {
                    sqlText += sorroundWithbrackets(sqlFilterSize);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterSize);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterFinish))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                  && String.IsNullOrEmpty(sqlFilterSize))
                {
                    sqlText += sorroundWithbrackets(sqlFilterFinish);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterFinish);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterOffset))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish))
                {
                    sqlText += sorroundWithbrackets(sqlFilterOffset);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterOffset);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterSeat))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish)
                && String.IsNullOrEmpty(sqlFilterOffset))
                {
                    sqlText += sorroundWithbrackets(sqlFilterSeat);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterSeat);
                }
            }

            if (!String.IsNullOrEmpty(sqlFilterBore))
            {
                if (String.IsNullOrEmpty(sqlFilterPCD)
                && String.IsNullOrEmpty(sqlFilterSize) && String.IsNullOrEmpty(sqlFilterFinish)
                && String.IsNullOrEmpty(sqlFilterOffset) && String.IsNullOrEmpty(sqlFilterSeat))
                {
                    sqlText += sorroundWithbrackets(sqlFilterBore);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterBore);
                }

            }
            wheelsAll.DefaultView.RowFilter = sqlText;
            GridView1.DataSource = wheelsAll.DefaultView;
            GridView1.DataBind();
        }
    }


    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    foreach (ListItem chkitem in chkSize.Items)
    //    {
    //        chkitem.Selected = true;
    //    }
    //}

    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in chkSize.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in chkPCD.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in chkOffset.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in chkSeat.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in chkBore.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in chkFinish.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        chkSize.ClearSelection();
        chkPCD.ClearSelection();
        chkOffset.ClearSelection();
        chkSeat.ClearSelection();
        chkFinish.ClearSelection();
        chkBore.ClearSelection();
        Gridview1_Bind();
    }
}