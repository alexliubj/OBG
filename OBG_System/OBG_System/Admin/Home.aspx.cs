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
    protected void Page_Load(object sender, EventArgs e)
    {
        Bind();
    }

    #region insertImage
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        string filename = Path.GetFileName(FileUploadControl.FileName);

        HomeImage oldHomeImage = new HomeImage();
        oldHomeImage = HomePageBLO.GetHomePageInformation();

        HomeImage newHomeImage = new HomeImage();
        newHomeImage.Des2 = oldHomeImage.Des1;
        newHomeImage.Image2 = oldHomeImage.Image1;
        newHomeImage.Des1 = Des.Text.ToString().Trim();
        

        if(FileUploadControl.HasFile)
        {
            string imgPath = "~/Pictures/News/" + filename;
            newHomeImage.Image1 = imgPath;
        }
        else
        {

        }

        int update = 0;
        update = HomePageBLO.UpdateImages(newHomeImage);

        if (update == 1)
        {
            if (FileUploadControl.HasFile)
            {
                FileUploadControl.SaveAs(Server.MapPath("~/Pictures/News/") + filename);
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
        }
        if (e.Item.Text == "Insert New Image")
        {
            insertNewImage.Visible = true;
            viewCurrentImage.Visible = false;
        }
        MenuItem ms = NavigationMenu.FindItem(e.Item.Text);
        if (ms != null)
        {
            ms.Selectable = false;
        }

    }
}