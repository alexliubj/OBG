﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using OBGModel;

public partial class Products_tireall : System.Web.UI.Page
{
    string strProductID = "";
    private DataSet tiresDataSet;
    public static int userID;
    DataTable tireAll = TiresBLO.GetAllTires(userID);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            userID = (int)Session["UserID"];
            if (Session["Permissions"] != null)
            {
                int tirePermission = ((List<int>)(Session["Permissions"]))[1];
                if (tirePermission == 0)
                {
                  //  Response.Write("<script language='javascript'>alert('Your account does not have permission to access this page');</script>");
                   // Server.Transfer("~/Account/UserCenter.aspx", true);
                    TiresFilter.Visible = false;
                    divtire.Visible = false;
                    PermissionDenied.Visible = true;
                }
                else
                {
                    divtire.Visible = true;
                    TiresFilter.Visible = true;
                    
                }
            }
        }
        else
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        if (!IsPostBack)
        {
            GridView2_Bind();
        }
    }
    public void GridView2_Bind()
    {

        DataTable tiresTable = TiresBLO.GetAllTires(userID);
        tiresDataSet = new DataSet();
        tiresDataSet.Tables.Add(tiresTable);

        GridView2.DataSource = tiresDataSet;
        GridView2.DataKeyNames = new string[] { "TireId" };
        GridView2.DataBind();
    }

    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        GridView2_Bind();

    }

    //protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int TireID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
    //    TiresBLO.DeleteTire(TireID);
    //    GridView2_Bind();
    //}

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView2.EditIndex = -1;
        GridView2_Bind();
    }

    protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        GridView2_Bind();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void AddBt_Click(object sender, EventArgs e)
    {
        //Tire tire = new Tire();
        //TiresBLO.CreateNewTire(tire);
        //Response.Redirect("~/ShoppingCart.aspx?ProductId=" + strProductID + "&Num=1");
    }

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClick")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView2.Rows[rowindex];
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
            int tID, qty;
            double price;
            string image;
            string partNo;
            float special;
            special = (float)Convert.ToSingle(((Label)GridView2.Rows[rowindex].FindControl("LBSpecial1")).Text);
            tID = Convert.ToInt32(GridView2.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView2.Rows[rowindex].FindControl("PNLabel")).Text;
            image = ((Image)GridView2.Rows[rowindex].FindControl("Image1")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView2.Rows[rowindex].FindControl("QTYTextBox")).Text);
            //price = Convert.ToDouble(((Label)GridView2.Rows[rowindex].FindControl("PricingLabel")).Text.Substring(1)) * special;
            if ((bool)((Label)GridView2.Rows[rowindex].FindControl("sPriceLabel")).Visible == true)
            { price = Convert.ToDouble(((Label)GridView2.Rows[rowindex].FindControl("sPriceLabel")).Text.Substring(1)); sc.Pricing = price; }
            if ((bool)((Label)GridView2.Rows[rowindex].FindControl("lbPrice")).Visible == true)
            { price = Convert.ToDouble(((Label)GridView2.Rows[rowindex].FindControl("lbPrice")).Text.Substring(1)); sc.Pricing = price; }


            bool flag = false;
            for (int i = 0; i < shoppingcart.Count(); i++)
            {
                if (shoppingcart[i].TireId == tID)
                {
                    shoppingcart[i].Qty += qty;
                    flag = true;
                }
            }

            if (flag == false)
            {
                sc.TireId = tID;
                sc.Qty = qty;
                sc.PartNo = partNo;
                sc.Image = image;
                shoppingcart.Add(sc);
            }

            Session["Cart"] = shoppingcart;

        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        //GridView1.DataBind();
        chk_SelectedIndexChanged(sender, e);
        //GridView2_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        DataTable dataTable = TiresBLO.GetAllTires(userID);

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView2.DataSource = dataView;
            chk_SelectedIndexChanged(sender, e);
            //GridView2.DataBind();
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
        
        String sqlText = string.Empty;
        String sqlFilterSize = string.Empty, sqlFilterBrand = string.Empty, sqlFilterSeason = string.Empty;
        foreach (ListItem item in ChkBrand.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterBrand != string.Empty)
                {
                    sqlFilterBrand += " or " + "Brand = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterBrand += "Brand = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }
        foreach (ListItem item in ChkSize.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterSize != string.Empty)
                {
                    sqlFilterSize += " or " + "Size = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterSize += "Size = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }
        foreach (ListItem item in ChkSeason.Items)
        {
            if (item.Selected)
            {
                if (sqlFilterSeason != string.Empty)
                {
                    sqlFilterSeason += " or " + "Season = " + "'" + item.Text.ToString().Trim() + "'";
                }
                else
                {
                    sqlFilterSeason += "Season = " + "'" + item.Text.ToString().Trim() + "'";
                }
            }
        }


        if (!String.IsNullOrEmpty(sqlFilterBrand))
        {
            sqlText += sorroundWithbrackets(sqlFilterBrand);
        }

        if (!String.IsNullOrEmpty(sqlFilterSize))
        {
            if (String.IsNullOrEmpty(sqlFilterBrand))
            {
                sqlText += sorroundWithbrackets(sqlFilterSize);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterSize);
            }
        }
        if (!String.IsNullOrEmpty(sqlFilterSeason))
        {
            if (String.IsNullOrEmpty(sqlFilterBrand)
              && String.IsNullOrEmpty(sqlFilterSize))
            {
                sqlText += sorroundWithbrackets(sqlFilterSeason);
            }
            else
            {
                sqlText += " and " + sorroundWithbrackets(sqlFilterSeason);
            }
        }
        

      
        tireAll.DefaultView.RowFilter = sqlText;
        GridView2.DataSource = tireAll.DefaultView;
        GridView2.DataBind();
    }

    private string sorroundWithbrackets(string orString)
    {
        return "(" + orString + ")";
    }
    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView2.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView2.PageIndex = 0;
        //GridView2_Bind();
        if (tireAll.DefaultView.RowFilter == null && GridView2.DataSource == null)
        //GridView1.DataSource = wheelsAll.DefaultView;
        //GridView1.DataBind();
        //else
        {
            //GridView1.DataBind();
            GridView2_Bind();
        }
        else
        {
            String sqlText = string.Empty;
            String sqlFilterSize = string.Empty, sqlFilterBrand = string.Empty, sqlFilterSeason = string.Empty;
            foreach (ListItem item in ChkBrand.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterBrand != string.Empty)
                    {
                        sqlFilterBrand += " or " + "Brand = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterBrand += "Brand = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }
            foreach (ListItem item in ChkSize.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterSize != string.Empty)
                    {
                        sqlFilterSize += " or " + "Size = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterSize += "Size = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }
            foreach (ListItem item in ChkSeason.Items)
            {
                if (item.Selected)
                {
                    if (sqlFilterSeason != string.Empty)
                    {
                        sqlFilterSeason += " or " + "Season = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                    else
                    {
                        sqlFilterSeason += "Season = " + "'" + item.Text.ToString().Trim() + "'";
                    }
                }
            }


            if (!String.IsNullOrEmpty(sqlFilterBrand))
            {
                sqlText += sorroundWithbrackets(sqlFilterBrand);
            }

            if (!String.IsNullOrEmpty(sqlFilterSize))
            {
                if (String.IsNullOrEmpty(sqlFilterBrand))
                {
                    sqlText += sorroundWithbrackets(sqlFilterSize);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterSize);
                }
            }
            if (!String.IsNullOrEmpty(sqlFilterSeason))
            {
                if (String.IsNullOrEmpty(sqlFilterBrand)
                  && String.IsNullOrEmpty(sqlFilterSize))
                {
                    sqlText += sorroundWithbrackets(sqlFilterSeason);
                }
                else
                {
                    sqlText += " and " + sorroundWithbrackets(sqlFilterSeason);
                }
            }



            tireAll.DefaultView.RowFilter = sqlText;
            GridView2.DataSource = tireAll.DefaultView;
            GridView2.DataBind();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in ChkBrand.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in ChkSize.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in ChkSeason.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ChkBrand.ClearSelection();
        ChkSize.ClearSelection();
        ChkSeason.ClearSelection();
        GridView2_Bind();
    }
}