using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;

public partial class Products_wheelall : System.Web.UI.Page
{
    string strProductID = "";
    Wheels wheels = new Wheels();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PopuLateControl();
        strProductID = Request.QueryString["ProductId"];
       // wheels = WheelsBLO.GetAllProducts();
        //lblProductId.Text = wheels.ProductId;
        ImgProduct.ImageUrl = wheels.Image;


    }

    private void PopuLateControl()
    {
        throw new NotImplementedException();
    }
}