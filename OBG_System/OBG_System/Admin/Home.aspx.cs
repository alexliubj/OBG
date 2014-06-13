using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_Default : System.Web.UI.Page
{
    int adminID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            MenuItem ms = NavigationMenu.FindItem("View Current Image");
            ms.Selectable = false;

            Bind();
        }
    }

    #region insertImage
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUploadControl.FileName);
        string filenameWithTimeStamp = AppendTimeStamp(filename);

        HomeImage oldHomeImage = new HomeImage();
        if (HomePageBLO.GetHomePageInformation() != null)
        {
            oldHomeImage = HomePageBLO.GetHomePageInformation();
        }

        HomeImage newHomeImage = new HomeImage();
        newHomeImage.Des2 = oldHomeImage.Des1;
        newHomeImage.Image2 = oldHomeImage.Image1;
        newHomeImage.Des1 = Des.Text.ToString().Trim();
        

        if(FileUploadControl.HasFile)
        {
            string imgPath = "~/Pictures/News/" + filenameWithTimeStamp;
            newHomeImage.Image1 = imgPath;
        }
        else
        {

        }

        int update = 0;
        update = HomePageBLO.UpdateImages(newHomeImage);

        if (update > 1)
        {
            if (FileUploadControl.HasFile)
            {
                FileUploadControl.SaveAs(Server.MapPath("~/Pictures/News/") + filenameWithTimeStamp);
            }

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Home Page Image information has been saved.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Saving Home Page Image information failed.');",
                        true);
        }
    }

    protected void BtnCancle_Click(object sender, EventArgs e)
    {
        insertNewImage.Visible = false;
        Des.Text = null;
    }
    #endregion

    #region viewImage
    
    public void Bind()
    {
        HomeImage homeImage = HomePageBLO.GetHomePageInformation();
        Image1.ImageUrl = homeImage.Image1;
        Image2.ImageUrl = homeImage.Image2;
        Des1.Text = homeImage.Des1;
        Des2.Text = homeImage.Des2;
    }

    #endregion

    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        if (e.Item.Text == "View Current Image")
        {
            insertNewImage.Visible = false;
            viewCurrentImage.Visible = true;
            initialImage.Visible = false;
        }
        if (e.Item.Text == "Insert New Image")
        {
            insertNewImage.Visible = true;
            viewCurrentImage.Visible = false;
            initialImage.Visible = false;
        }
        if (e.Item.Text == "Initial Image")
        {
            insertNewImage.Visible = false;
            viewCurrentImage.Visible = false;
            initialImage.Visible = true;
        }

        MenuItem ms = NavigationMenu.FindItem(e.Item.Text);
        if (ms != null)
        {
            ms.Selectable = false;
        }
  
    }

    public static string AppendTimeStamp(string fileName)
    {
        return string.Concat(
            Path.GetFileNameWithoutExtension(fileName),
            DateTime.Now.ToString("yyyyMMddHHmmssfff"),
            Path.GetExtension(fileName)
            );
    }

    #region initialImage
    protected void BtnInitialSave_Click(object sender, EventArgs e)
    {
        string filename1 = Path.GetFileName(FileUpload1.FileName);
        string filename2 = Path.GetFileName(FileUpload2.FileName);
        string filenameWithTimeStamp1 = AppendTimeStamp(filename1);
        string filenameWithTimeStamp2 = AppendTimeStamp(filename2);

        HomeImage homeImage = new HomeImage();
        homeImage.Des1 = initialDes1.Text.ToString().Trim();
        homeImage.Des2 = initialDes2.Text.ToString().Trim();

        if (FileUpload1.HasFile)
        {
            string imgPath1 = "~/Pictures/News/" + filenameWithTimeStamp1;
            homeImage.Image1 = imgPath1;
        }
        else
        {

        }

        if (FileUpload2.HasFile)
        {
            string imgPath2 = "~/Pictures/News/" + filenameWithTimeStamp2;
            homeImage.Image2 = imgPath2;
        }
        else
        {

        }

        int update = 0;
        update = HomePageBLO.InsertImages(homeImage);

        if (update == 1)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Pictures/News/") + filenameWithTimeStamp1);
            }

            if (FileUpload2.HasFile)
            {
                FileUpload2.SaveAs(Server.MapPath("~/Pictures/News/") + filenameWithTimeStamp2);
            }

            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                         "err_msg",
                         "alert('Home Page Image information has been initialed.');",
                         true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
                        "err_msg",
                        "alert('Sorry, Initialing Home Page Image information failed.');",
                        true);
        }
    }
    protected void BtnInitialCancle_Click(object sender, EventArgs e)
    {
        initialImage.Visible = false;
        initialDes1.Text = null;
        initialDes2.Text = null;
    }
    #endregion
}