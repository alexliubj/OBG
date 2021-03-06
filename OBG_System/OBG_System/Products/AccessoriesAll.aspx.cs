﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using OBGModel;

public partial class Products_accAll : System.Web.UI.Page
{
    private DataSet AccDataSet;
    int userID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            userID = (int)Session["UserID"];
            if (Session["Permissions"] != null)
            {
                int accPermission = ((List<int>)(Session["Permissions"]))[2];
                if (accPermission == 0)
                {
                    //Response.Write("<script language='javascript'>alert('Your account does not have permission to access this page');</script>");
                    //Server.Transfer("~/Account/UserCenter.aspx", true);
                    TiresFilter.Visible = false;
                    divacc.Visible = false;
                    PermissionDenied.Visible = true;
                }
                else
                {
                    TiresFilter.Visible = true;
                    divacc.Visible = true;
                }
            }
        }
        else
        {

            Response.Redirect("~/Account/Login.aspx");
        }
        if (!IsPostBack)
        {
            GridView6_Bind();
        }
    }
    public void GridView6_Bind()
    {

        DataTable tiresTable = AccessoryBLO.GetAllAccessories(userID);
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
        chk_SelectedIndexChanged(sender, e);
        //GridView6_Bind();
    }

    protected void GridView6_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dataTable = GridView1.DataSource as DataTable;
        DataTable dataTable = AccessoryBLO.GetAllAccessories(userID);

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GridView6.DataSource = dataView;
            chk_SelectedIndexChanged(sender, e);
            //GridView6.DataBind();
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
        DataTable accAll = AccessoryBLO.GetAllAccessories(userID);
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

    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyButtonClick")
        {
            //Get rowindex            
            int rowindex = Convert.ToInt32(e.CommandArgument);
            //Get Row           
            GridViewRow gvr = GridView6.Rows[rowindex];

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
            string name,des;
            float special;
            special = (float)Convert.ToSingle(((Label)GridView6.Rows[rowindex].FindControl("LBSpecial1")).Text);
            pID = Convert.ToInt32(GridView6.DataKeys[rowindex].Value.ToString());
            partNo = ((Label)GridView6.Rows[rowindex].FindControl("PNLabel")).Text;
            image = ((Image)GridView6.Rows[rowindex].FindControl("Image1")).ImageUrl;
            qty = Convert.ToInt32(((TextBox)GridView6.Rows[rowindex].FindControl("QTYTextBox")).Text);
            //price = Convert.ToDouble(((Label)GridView6.Rows[rowindex].FindControl("PricingLabel")).Text.Substring(1)) * special;
            if ((bool)((Label)GridView6.Rows[rowindex].FindControl("sPriceLabel")).Visible == true)
            { price = Convert.ToDouble(((Label)GridView6.Rows[rowindex].FindControl("sPriceLabel")).Text.Substring(1)); sc.Pricing = price; }
            if ((bool)((Label)GridView6.Rows[rowindex].FindControl("lbPrice")).Visible == true)
            { price = Convert.ToDouble(((Label)GridView6.Rows[rowindex].FindControl("lbPrice")).Text.Substring(1)); sc.Pricing = price; }
            
            name = ((Label)GridView6.Rows[rowindex].FindControl("NameLabel")).Text;

            bool flag = false;
            for (int i = 0; i < shoppingcart.Count(); i++)
            {
                if (shoppingcart[i].AccId == pID)
                {
                    shoppingcart[i].Qty += qty;
                    flag = true;
                }
            }

            if (flag == false)
            {
                sc.AccId = pID;
                sc.Qty = qty;
                sc.PartNo = partNo;
                sc.Image = image;
                sc.productName = name;
                shoppingcart.Add(sc);
            }

            Session["Cart"] = shoppingcart;
        }
    }

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView6.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView6.PageIndex = 0;
        //GridView6_Bind();
        DataTable accAll = AccessoryBLO.GetAllAccessories(userID);
        if (accAll.DefaultView.RowFilter == null && GridView6.DataSource == null)
        //GridView1.DataSource = wheelsAll.DefaultView;
        //GridView1.DataBind();
        //else
        {
            //GridView1.DataBind();
            GridView6_Bind();
        }
        else
        {
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach (ListItem chkitem in ChkName.Items)
        {
            chkitem.Selected = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ChkName.ClearSelection();
        GridView6_Bind();
    }
}