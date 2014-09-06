using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using OBGModel;
public partial class Products_ReturnPolicy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReturnPolicy retp = HomePageBLO.GetReturnPolicy();

            policy.Text = retp.ReturnPolicy1;

            others.Text = retp.Others;

            match.Text = retp.Price;

            defects.Text = retp.Defects;

            shipping.Text = retp.Shipping;
        }
    }
}