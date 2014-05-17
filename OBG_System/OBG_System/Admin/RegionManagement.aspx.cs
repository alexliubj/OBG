using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_Default : System.Web.UI.Page
{
    private DataSet regionDataSet;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();

        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bind();

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int regionID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        RegionBLO.RemoveShippingById(regionID);
        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    public void bind()
    {

        DataTable regionTable = RegionBLO.GetAllShipping();
        regionDataSet = new DataSet();
        regionDataSet.Tables.Add(regionTable);

        GridView1.DataSource = regionDataSet;
        GridView1.DataKeyNames = new string[] { "regionid" };
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        Shipping region = new Shipping();
        int regionID;
        regionID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        region.RegionId = regionID;
        region.RegionName = RegionName.Text;
        region.RegionPrice = (float)Convert.ToDouble(Price.Text);
        region.DevMethods = DevMethods.Text;

        int update = 0;
        update = RegionBLO.UpdateShipping(region);

        if (update == 1)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Region information has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Region information failed.');",
                        true);
        }
    }
    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        regionInformation.Visible = false;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int regionID;
        regionID = int.Parse(GridView1.SelectedRow.Cells[0].Text);
        Shipping region = new Shipping();

        // region = UserBLO.GetUserInfoWithUserId(userID);
        RegionName.Text = region.RegionName;
        Price.Text = region.RegionPrice.ToString();
        DevMethods.Text = region.DevMethods;

        regionInformation.Visible = true;
        BtnAdd.Visible = false;
        BtnSave.Visible = true;
    }
    protected void btnAddRegion_Click(object sender, EventArgs e)
    {
        RegionName.Text = null;
        Price.Text = null;
        DevMethods.Text = null;

        regionInformation.Visible = true;
        BtnAdd.Visible = true;
        BtnSave.Visible = false;
    }
    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Shipping region = new Shipping();

        region.RegionName = RegionName.Text;
        region.RegionPrice = (float)Convert.ToDouble(Price.Text);
        region.DevMethods = DevMethods.Text;

        int newId = RegionBLO.AddNewShippping(region);

        if (newId > 0)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                            "err_msg",
                            "alert('success.');", true);
            bind();
        }
    }
}