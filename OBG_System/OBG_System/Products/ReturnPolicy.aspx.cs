using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;

public partial class Products_ReturnPolicy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<string> listPolicy = HomePageBLO.GetReturnPolicy();
            if (listPolicy.Count > 0)
                policy.Text = listPolicy[0];
            if (listPolicy.Count > 1)
                others.Text = listPolicy[1];
        }
    }
}