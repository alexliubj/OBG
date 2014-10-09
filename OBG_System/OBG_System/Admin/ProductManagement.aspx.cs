﻿using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class Admin_Default : System.Web.UI.Page
{
    private DataSet wheelsDataSet;
    private DataSet tiresDataSet;
    private DataSet accessoriesDataSet;
    //private HttpPostedFile postedFile = null;
    int adminID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        MenuItem ms = new MenuItem();

        if (Session["AdminID"] != null)
        {
            adminID = (int)Session["AdminID"];
        }
        else
        {
            Response.Redirect("~/Admin/Login.aspx");
        }

        if (!IsPostBack)
        {
            ms = NavigationMenu.FindItem("Wheels");
            ms.Selected = true;

            Gridview1_Bind();
            GridView2_Bind();
            GridView3_Bind();

            //if (String.IsNullOrEmpty(GridView1.SortExpression)) GridView1.Sort("ProductId", SortDirection.Descending);

            //if (String.IsNullOrEmpty(GridView2.SortExpression)) GridView2.Sort("TireId", SortDirection.Descending);

            //if (String.IsNullOrEmpty(GridView3.SortExpression)) GridView3.Sort("AccId", SortDirection.Descending);
        }
    }
    #region ViewAllWheels
    public void Gridview1_Bind()
    {

        DataTable wheelsTable = WheelsBLO.GetAllProducts();
        wheelsDataSet = new DataSet();
        wheelsDataSet.Tables.Add(wheelsTable);

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
        wheelInformation.Visible = false;
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // int productID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        // //get product by ID
        //// Wheels wheels = WheelsBLO
        // user.Userid = userID;
        // user.UserName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString().Trim();
        // DropDownList ddl = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1"));
        // if (ddl.SelectedItem.Text == "active")
        // {
        //     user.Status = 1;
        // }
        // else if (ddl.SelectedItem.Text == "inactive")
        // {
        //     user.Status = 0;
        // }
        // user.Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text.ToString().Trim();
        // user.CompanyName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("TextBox5"))).Text.ToString().Trim();
        // user.Phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("TextBox1"))).Text.ToString().Trim();
        // UserBLO.UpdateUserInfo(user);

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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (GridView1.SelectedIndex > -1)
        {
            GridView1.SelectedIndex = -1;
        }
        Gridview1_Bind();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = WheelsBLO.GetAllProducts();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            //dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
            dataView.Sort = e.SortExpression + " " + "DESC";
            GridView1.DataSource = dataView;
            GridView1.DataBind();
        }
    }

    #endregion

    #region WheelDetailInformation

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string filename = null;
        string filenameWithTimeStamp = null;
        Wheels wheel = new Wheels();
        int productID;
        productID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        wheel.ProductId = productID;
        wheel.Bore = Bore.Text.ToString().Trim();
        wheel.Brand = Brand.Text.ToString().Trim();
        wheel.PartNO = PartNo.Text.ToString().Trim();
        wheel.Finish = Finish.Text.ToString().Trim();

        if (FileUploadControl.HasFile)
        {
            filename = Path.GetFileName(FileUploadControl.FileName);
            filenameWithTimeStamp = AppendTimeStamp(filename);
            string imgPath = "~/Pictures/" + filenameWithTimeStamp;
            wheel.Image = imgPath;
        }
        else
        {
            DataTable wheelsTable = WheelsBLO.GetAllProducts();
            wheelsTable.PrimaryKey = new DataColumn[] { wheelsTable.Columns["ProductID"] };
            DataRow foundRow = wheelsTable.Rows.Find(productID);
            wheel.Image = foundRow[1].ToString();
        }

        wheel.Offset = Offset.Text.ToString().Trim();
        wheel.Onhand = Onhand.Text.ToString().Trim();
        wheel.Pcd = Pcd.Text.ToString().Trim();
        wheel.Price = (float)double.Parse(Price.Text.ToString().Trim());
        wheel.Seat = Seat.Text.ToString().Trim();
        wheel.Size = Size.Text.ToString().Trim();
        wheel.Style = Style.Text.ToString().Trim();
        wheel.Weight = Weight.Text.ToString().Trim();
        wheel.Des = Des.Text.ToString().Trim();

        string special = Special.Text.ToString().Trim();
        Match mtch = Regex.Match(special, @"^-*[0-9,\.]+$");
        if (mtch.Success)
        {
            wheel.Special = (float)double.Parse(special);
        }

        int update = 0;

        List<Vehicle> listVehicle = new List<Vehicle>();

        for (int i = 0; i < CheckBoxListVehicle.Items.Count; i++)
        {
            if (CheckBoxListVehicle.Items[i].Selected == true)
            {
                Vehicle vehicle = new Vehicle();
                vehicle.VehicleId = int.Parse(CheckBoxListVehicle.Items[i].Value.ToString());
                //vehicle.VehicleName = CheckBoxListVehicle.Items[i].Text.ToString();
                listVehicle.Add(vehicle);
            }
        }

        update = WheelsBLO.UpdateProduct(wheel, listVehicle);

        if (update == 1)
        {
            if (FileUploadControl.HasFile)
            {
                FileUploadControl.SaveAs(Server.MapPath("~/Pictures/") + filenameWithTimeStamp);
            }
            Gridview1_Bind();
            Image1.ImageUrl = ((Image)(GridView1.SelectedRow.Cells[0].FindControl("Image1"))).ImageUrl;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Wheel has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Wheel information failed.');",
                        true);
        }
    }
    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        wheelInformation.Visible = false;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBoxListVehicle.DataBind();
        int productID;
        DataTable wheelsVehicles;
        List<string> vehicleIDs = new List<string>();
        productID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        Wheels wheel = new Wheels();

        Bore.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label10"))).Text;
        Brand.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label4"))).Text;
        PartNo.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label14"))).Text;
        Finish.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label7"))).Text;
        Image1.ImageUrl = ((Image)(GridView1.SelectedRow.Cells[0].FindControl("Image1"))).ImageUrl;
        Offset.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label8"))).Text;
        Onhand.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label12"))).Text;
        Pcd.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label6"))).Text;
        Price.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label13"))).Text;
        Seat.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label9"))).Text;
        Size.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label5"))).Text;
        Style.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label3"))).Text;
        Weight.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label11"))).Text;
        Des.Text = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label15"))).Text;

        string special = ((Label)(GridView1.SelectedRow.Cells[0].FindControl("Label16"))).Text;
        double num = double.Parse(special.Replace("%", "")) / 100;
        Special.Text = num.ToString();


        wheelsVehicles = WheelsBLO.GetAllWheelsVehiclesByWheelsId(productID);

        foreach (DataRow dtRow in wheelsVehicles.Rows)
        {
            vehicleIDs.Add(dtRow["vehicleID"].ToString());
        }

        //uncheck all
        for (int i = 0; i < CheckBoxListVehicle.Items.Count; i++)
        {
            CheckBoxListVehicle.Items[i].Selected = false;
        }

        //check vehicle which contains in datatable wheelsVehicles
        foreach (string vehicleID in vehicleIDs)
        {
            for (int i = 0; i < CheckBoxListVehicle.Items.Count; i++)
            {
                if (CheckBoxListVehicle.Items[i].Value == vehicleID)
                {
                    CheckBoxListVehicle.Items[i].Selected = true;
                }
            }
        }

        wheelInformation.Visible = true;

        BtnAdd.Visible = false;
        BtnSave.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Bore.Text = null;
        Brand.Text = null;
        PartNo.Text = null;
        Finish.Text = null;
        Image1.ImageUrl = null;
        Offset.Text = null;
        Onhand.Text = null;
        Pcd.Text = null;
        Price.Text = null;
        Seat.Text = null;
        Size.Text = null;
        Style.Text = null;
        Weight.Text = null;
        Des.Text = null;
        Special.Text = null;
        //uncheck all
        for (int i = 0; i < CheckBoxListVehicle.Items.Count; i++)
        {
            CheckBoxListVehicle.Items[i].Selected = false;
        }

        wheelInformation.Visible = true;

        BtnAdd.Visible = true;
        BtnSave.Visible = false;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Wheels wheel = new Wheels();

        wheel.Bore = Bore.Text.ToString().Trim();
        wheel.Brand = Brand.Text.ToString().Trim();
        wheel.PartNO = PartNo.Text.ToString().Trim();
        wheel.Finish = Finish.Text.ToString().Trim();

        string filename = Path.GetFileName(FileUploadControl.FileName);
        string filenameWithTimeStamp = AppendTimeStamp(filename);
        string imgPath = "~/Pictures/" + filenameWithTimeStamp;
        wheel.Image = imgPath;

        wheel.Offset = Offset.Text.ToString().Trim();
        wheel.Onhand = Onhand.Text.ToString().Trim();
        wheel.Pcd = Pcd.Text.ToString().Trim();
        wheel.Price = (float)double.Parse(Price.Text.ToString().Trim());
        wheel.Seat = Seat.Text.ToString().Trim();
        wheel.Size = Size.Text.ToString().Trim();
        wheel.Style = Style.Text.ToString().Trim();
        wheel.Weight = Weight.Text.ToString().Trim();
        wheel.Des = Des.Text.ToString().Trim();

        string special = Special.Text.ToString().Trim();
        Match mtch = Regex.Match(special, @"^-*[0-9,\.]+$");
        if (mtch.Success)
        {
            wheel.Special = (float)double.Parse(special);
        }

        List<Vehicle> listVehicle = new List<Vehicle>();

        for (int i = 0; i < CheckBoxListVehicle.Items.Count; i++)
        {
            if (CheckBoxListVehicle.Items[i].Selected == true)
            {
                Vehicle vehicle = new Vehicle();
                vehicle.VehicleId = int.Parse(CheckBoxListVehicle.Items[i].Value.ToString());
                //vehicle.VehicleName = CheckBoxListVehicle.Items[i].Text.ToString();
                listVehicle.Add(vehicle);
            }
        }

        int update = WheelsBLO.AddNewProduct(wheel, listVehicle);

        if (update > 0)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    //string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/Pictures/") + filenameWithTimeStamp);
                    // StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    // StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            Gridview1_Bind();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('New Wheel has been created.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Creating Wheel failed.');",
                        true);
        }
    }

    protected void CheckBoxListVehicle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    #endregion

    #region ViewAllTires
    public void GridView2_Bind()
    {

        DataTable tiresTable = TiresBLO.GetAllTires();
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

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int TireID = Convert.ToInt32(GridView2.DataKeys[e.RowIndex].Value.ToString());
        TiresBLO.DeleteTire(TireID);
        GridView2_Bind();
        DivTireInformation.Visible = false;
    }

    protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // int productID = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[0].Text);
        // //get product by ID
        //// Wheels wheels = WheelsBLO
        // user.Userid = userID;
        // user.UserName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].FindControl("TextBox2"))).Text.ToString().Trim();
        // DropDownList ddl = (DropDownList)(GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1"));
        // if (ddl.SelectedItem.Text == "active")
        // {
        //     user.Status = 1;
        // }
        // else if (ddl.SelectedItem.Text == "inactive")
        // {
        //     user.Status = 0;
        // }
        // user.Email = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].FindControl("TextBox4"))).Text.ToString().Trim();
        // user.CompanyName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].FindControl("TextBox5"))).Text.ToString().Trim();
        // user.Phone = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].FindControl("TextBox1"))).Text.ToString().Trim();
        // UserBLO.UpdateUserInfo(user);

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

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        if (GridView2.SelectedIndex > -1)
        {
            GridView2.SelectedIndex = -1;
        }
        GridView2_Bind();
    }

    protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = TiresBLO.GetAllTires();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            //dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
            dataView.Sort = e.SortExpression + " " + "DESC";
            GridView2.DataSource = dataView;
            GridView2.DataBind();
        }
    }
    #endregion

    #region TireDetailInformation
    protected void BtnCancelTire_Click(object sender, EventArgs e)
    {
        DivTireInformation.Visible = false;
    }
    protected void BtnSaveTire_Click(object sender, EventArgs e)
    {
        string filename = null;
        string filenameWithTimeStamp = null;
        Tire tire = new Tire();
        int tireID;
        tireID = int.Parse(GridView2.SelectedRow.Cells[0].Text);
        tire.TireId = tireID;
        tire.PartNo = TirePartNo.Text.ToString().Trim();
        tire.Size = TireSize.Text.ToString().Trim();
        tire.Pricing = (float)double.Parse(TirePrice.Text.ToString().Trim());
        tire.Season = TireSeason.Text.ToString().Trim();

        string special = TireSpecial.Text.ToString().Trim();
        Match mtch = Regex.Match(special, @"^-*[0-9,\.]+$");
        if (mtch.Success)
        {
            tire.Special = (float)double.Parse(special);
        }

        if (TireFileUploadControl.HasFile)
        {
            filename = Path.GetFileName(TireFileUploadControl.FileName);
            filenameWithTimeStamp = AppendTimeStamp(filename);
            string imgPath = "~/Pictures/" + filenameWithTimeStamp;
            tire.Image = imgPath;
        }
        else
        {
            DataTable tiresTable = TiresBLO.GetAllTires();
            tiresTable.PrimaryKey = new DataColumn[] { tiresTable.Columns["TireID"] };
            DataRow foundRow = tiresTable.Rows.Find(tireID);
            tire.Image = foundRow[2].ToString();
        }

        tire.Brand = TireBrand.Text.ToString().Trim();
        tire.Des = TireDes.Text.ToString().Trim();

        int update = 0;
        update = TiresBLO.UpdateTire(tire);


        if (update == 1)
        {
            if (TireFileUploadControl.HasFile)
            {
                TireFileUploadControl.SaveAs(Server.MapPath("~/Pictures/") + filenameWithTimeStamp);
            }
            GridView2_Bind();
            TireImage.ImageUrl = ((Image)(GridView2.SelectedRow.Cells[0].FindControl("Image1"))).ImageUrl;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Tire has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Tire information failed.');",
                        true);
        }
    }
    protected void BtnAddTire_Click(object sender, EventArgs e)
    {
        Tire tire = new Tire();

        tire.PartNo = TirePartNo.Text.ToString().Trim();
        tire.Size = TireSize.Text.ToString().Trim();
        tire.Pricing = (float)double.Parse(TirePrice.Text.ToString().Trim());
        tire.Season = TireSeason.Text.ToString().Trim();

        string filename = Path.GetFileName(TireFileUploadControl.FileName);
        string filenameWithTimeStamp = AppendTimeStamp(filename);
        string imgPath = "~/Pictures/" + filenameWithTimeStamp;
        tire.Image = imgPath;

        tire.Brand = TireBrand.Text.ToString().Trim();
        tire.Des = TireDes.Text.ToString().Trim();

        string special = TireSpecial.Text.ToString().Trim();
        Match mtch = Regex.Match(special, @"^-*[0-9,\.]+$");
        if (mtch.Success)
        {
            tire.Special = (float)double.Parse(special);
        }

        int update = TiresBLO.CreateNewTire(tire);

        if (update == 1)
        {
            if (TireFileUploadControl.HasFile)
            {
                try
                {
                    TireFileUploadControl.SaveAs(Server.MapPath("~/Pictures/") + filenameWithTimeStamp);
                }
                catch (Exception ex)
                {

                }
            }
            GridView2_Bind();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('New Tire has been created.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Creating Tire failed.');",
                        true);
        }
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TirePartNo.Text = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label2"))).Text;
        TireSize.Text = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label3"))).Text;
        TirePrice.Text = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label4"))).Text;
        TireSeason.Text = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label5"))).Text;
        TireImage.ImageUrl = ((Image)(GridView2.SelectedRow.Cells[0].FindControl("Image1"))).ImageUrl;
        TireBrand.Text = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label6"))).Text;
        TireDes.Text = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label7"))).Text;

        string special = ((Label)(GridView2.SelectedRow.Cells[0].FindControl("Label8"))).Text;
        double num = double.Parse(special.Replace("%", "")) / 100;
        TireSpecial.Text = num.ToString();


        DivTireInformation.Visible = true;

        BtnAddTire.Visible = false;
        BtnSaveTire.Visible = true;
    }

    protected void BtnAddNewTire_Click(object sender, EventArgs e)
    {
        TirePartNo.Text = null;
        TireSize.Text = null;
        TirePrice.Text = null;
        TireSeason.Text = null;
        TireImage.ImageUrl = null;
        TireBrand.Text = null;
        TireDes.Text = null;
        TireSpecial.Text = null;

        DivTireInformation.Visible = true;

        BtnAddTire.Visible = true;
        BtnSaveTire.Visible = false;
    }
    #endregion

    #region ViewAllAccessories
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

    protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int AccID = Convert.ToInt32(GridView3.DataKeys[e.RowIndex].Value.ToString());
        AccessoryBLO.DeleteOneAccessory(AccID);
        GridView3_Bind();
        DivAccInformation.Visible = false;
    }

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

    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        if (GridView3.SelectedIndex > -1)
        {
            GridView3.SelectedIndex = -1;
        }
        GridView3_Bind();
    }

    protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = AccessoryBLO.GetAllAccessories();

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            // dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
            dataView.Sort = e.SortExpression + " " + "DESC";
            GridView3.DataSource = dataView;
            GridView3.DataBind();
        }
    }
    #endregion

    #region AccDetailInformation
    protected void BtnCancelAcc_Click(object sender, EventArgs e)
    {
        DivAccInformation.Visible = false;
    }
    protected void BtnSaveAcc_Click(object sender, EventArgs e)
    {
        string filename = null;
        string filenameWithTimeStamp = null;
        Accessories acc = new Accessories();
        int accID;
        accID = int.Parse(GridView3.SelectedRow.Cells[0].Text);
        acc.AccId = accID;
        acc.PartNo = AccPartNo.Text.ToString().Trim();
        acc.Pricing = (float)double.Parse(AccPrice.Text.ToString().Trim());
        acc.Name = AccName.Text.ToString().Trim();

        string special = AccSpecial.Text.ToString().Trim();
        Match mtch = Regex.Match(special, @"^-*[0-9,\.]+$");
        if (mtch.Success)
        {
            acc.Special = (float)double.Parse(special);
        }

        if (AccFileUploadControl.HasFile)
        {
            filename = Path.GetFileName(AccFileUploadControl.FileName);
            filenameWithTimeStamp = AppendTimeStamp(filename);
            string imgPath = "~/Pictures/" + filenameWithTimeStamp;
            acc.Img = imgPath;
        }
        else
        {
            DataTable accsTable = AccessoryBLO.GetAllAccessories();
            accsTable.PrimaryKey = new DataColumn[] { accsTable.Columns["AccID"] };
            DataRow foundRow = accsTable.Rows.Find(accID);
            acc.Img = foundRow[2].ToString();
        }

        acc.Brand = AccBrand.Text.ToString().Trim();
        acc.Des = AccDes.Text.ToString().Trim();

        int update = 0;
        update = AccessoryBLO.UpdateAccessory(acc);


        if (update == 1)
        {
            if (AccFileUploadControl.HasFile)
            {
                AccFileUploadControl.SaveAs(Server.MapPath("~/Pictures/") + filenameWithTimeStamp);
            }
            GridView3_Bind();
            AccImage.ImageUrl = ((Image)(GridView3.SelectedRow.Cells[0].FindControl("Image1"))).ImageUrl;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Accessory has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Accessory information failed.');",
                        true);
        }
    }
    protected void BtnAddAcc_Click(object sender, EventArgs e)
    {
        Accessories acc = new Accessories();

        acc.PartNo = AccPartNo.Text.ToString().Trim();
        acc.Pricing = (float)double.Parse(AccPrice.Text.ToString().Trim());
        acc.Name = AccName.Text.ToString().Trim();

        string filename = Path.GetFileName(AccFileUploadControl.FileName);
        string filenameWithTimeStamp = AppendTimeStamp(filename);
        string imgPath = "~/Pictures/" + filenameWithTimeStamp;
        acc.Img = imgPath;

        acc.Brand = AccBrand.Text.ToString().Trim();
        acc.Des = AccDes.Text.ToString().Trim();

        string special = AccSpecial.Text.ToString().Trim();
        Match mtch = Regex.Match(special, @"^-*[0-9,\.]+$");
        if (mtch.Success)
        {
            acc.Special = (float)double.Parse(special);
        }


        int update = AccessoryBLO.CreateNewAccessory(acc);

        if (update == 1)
        {
            if (AccFileUploadControl.HasFile)
            {
                try
                {
                    AccFileUploadControl.SaveAs(Server.MapPath("~/Pictures/") + filenameWithTimeStamp);
                }
                catch (Exception ex)
                {

                }
            }
            GridView3_Bind();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('New Accessory has been created.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Creating Accessory failed.');",
                        true);
        }
    }

    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {
        AccPartNo.Text = ((Label)(GridView3.SelectedRow.Cells[0].FindControl("Label2"))).Text;
        AccName.Text = ((Label)(GridView3.SelectedRow.Cells[0].FindControl("Label7"))).Text;
        AccPrice.Text = ((Label)(GridView3.SelectedRow.Cells[0].FindControl("Label5"))).Text;
        AccImage.ImageUrl = ((Image)(GridView3.SelectedRow.Cells[0].FindControl("Image1"))).ImageUrl;
        AccBrand.Text = ((Label)(GridView3.SelectedRow.Cells[0].FindControl("Label6"))).Text;
        AccDes.Text = ((Label)(GridView3.SelectedRow.Cells[0].FindControl("Label4"))).Text;

        string special = ((Label)(GridView3.SelectedRow.Cells[0].FindControl("Label8"))).Text;
        double num = double.Parse(special.Replace("%", "")) / 100;
        AccSpecial.Text = num.ToString();

        DivAccInformation.Visible = true;

        BtnAddAcc.Visible = false;
        BtnSaveAcc.Visible = true;
    }

    protected void BtnAddNewAcc_Click(object sender, EventArgs e)
    {
        AccPartNo.Text = null;
        AccName.Text = null;
        AccPrice.Text = null;
        AccBrand.Text = null;
        AccImage.ImageUrl = null;
        AccDes.Text = null;
        AccSpecial.Text = null;

        DivAccInformation.Visible = true;

        BtnAddAcc.Visible = true;
        BtnSaveAcc.Visible = false;
    }
    #endregion

    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "Wheels")
        {
            divWheel.Visible = true;
            divTire.Visible = false;
            divAcc.Visible = false;
        }
        if (e.Item.Text == "Tires")
        {
            divWheel.Visible = false;
            divTire.Visible = true;
            divAcc.Visible = false;
        }
        if (e.Item.Text == "Accessories")
        {
            divWheel.Visible = false;
            divTire.Visible = false;
            divAcc.Visible = true;
        }

        MenuItem ms = NavigationMenu.FindItem(e.Item.Text);
        if (ms != null)
        {
            ms.Selected = true;
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

    #region upload image

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        //    if(FileUploadControl.HasFile)
        //{
        //    try
        //    {
        //        if(FileUploadControl.PostedFile.ContentType == "image/jpeg")
        //        {
        //            if(FileUploadControl.PostedFile.ContentLength < 102400)
        //            {
        //                string filename = Path.GetFileName(FileUploadControl.FileName);
        //                FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
        //                StatusLabel.Text = "Upload status: File uploaded!";
        //            }
        //            else
        //                StatusLabel.Text = "Upload status: The file has to be less than 100 kb!";
        //        }
        //        else
        //            StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
        //    }
        //    catch(Exception ex)
        //    {
        //        StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        //    }
    }

    //protected void btnPreviewImage_Click(object sender, EventArgs e) 
    //{
    //    //bug: after click preview, the image would not upload, cause FileUploadControl.HasFile=false
    //    if (FileUploadControl.HasFile)   
    //     {   
    //         string path = Server.MapPath("TempImages");   

    //         FileInfo oFileInfo = new FileInfo(
    //              FileUploadControl.PostedFile.FileName);
    //         string fileName = oFileInfo.Name;

    //         string fullFileName = path + "\\" + fileName;
    //         string imagePath = "TempImages/" + fileName;

    //         if (!Directory.Exists(path))
    //         {
    //             Directory.CreateDirectory(path);
    //         }

    //       // postedFile= FileUploadControl.PostedFile;
    //        FileUploadControl.PostedFile.SaveAs(fullFileName);
    //        //flag = true;

    //        Image1.ImageUrl = imagePath;
    //     }
    //}

    //protected void FileUploadControl_Load(object sender, EventArgs e)
    //{
    //    btnPreviewImage_Click(this, null);
    //}

    #endregion

    public static string AppendTimeStamp(string fileName)
    {
        return string.Concat(
            Path.GetFileNameWithoutExtension(fileName),
            DateTime.Now.ToString("yyyyMMddHHmmssfff"),
            Path.GetExtension(fileName)
            );
    }

    protected void dropDownRecordsPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView1.PageIndex = 0;
        Gridview1_Bind();
        //if (String.IsNullOrEmpty(GridView1.SortExpression)) GridView1.Sort("ProductId", SortDirection.Descending);
    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

    protected void dropDownRecordsPerPage2_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView2.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView2.PageIndex = 0;
        GridView2_Bind();

        //if (String.IsNullOrEmpty(GridView2.SortExpression)) GridView2.Sort("TireId", SortDirection.Descending);
    }

    protected void GridView2_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

    protected void dropDownRecordsPerPage3_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView3.PageSize = int.Parse(((DropDownList)sender).SelectedValue);

        GridView3.PageIndex = 0;
        GridView3_Bind();
        //if (String.IsNullOrEmpty(GridView3.SortExpression)) GridView3.Sort("AccId", SortDirection.Descending);
    }

    protected void GridView3_PreRender(object sender, EventArgs e)
    {
        var pagerRow = (sender as GridView).BottomPagerRow;
        if (pagerRow != null)
        {
            pagerRow.Visible = true;
        }
    }

}
