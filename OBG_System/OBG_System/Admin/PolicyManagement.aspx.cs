using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using OBGModel;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Admin_PolicyManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReturnPolicy retp = new ReturnPolicy();
            retp = HomePageBLO.GetReturnPolicy();
           
                string policy = retp.ReturnPolicy1.Replace("<br />", Environment.NewLine);
                TextBox1.Text = policy;
                string otherPolicy = retp.Others.Replace("<br />", Environment.NewLine);
                TextBox2.Text = otherPolicy;
                defectsTxt.Text = retp.Defects.Replace("<br />", Environment.NewLine);
                shippingTxt.Text = retp.Shipping.Replace("<br />", Environment.NewLine);
                matchTxt.Text = retp.Price.Replace("<br />", Environment.NewLine);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReturnPolicy retp = new ReturnPolicy();
        retp.ReturnPolicy1 = TextBox1.Text.Replace(Environment.NewLine, "<br />");
        retp.Others = TextBox2.Text.Replace(Environment.NewLine, "<br />");
        retp.Defects = defectsTxt.Text.Replace(Environment.NewLine, "<br />");
        retp.Shipping = shippingTxt.Text.Replace(Environment.NewLine, "<br />");
        retp.Price = matchTxt.Text.Replace(Environment.NewLine, "<br />");
        HomePageBLO.UpdateReturnPolicy(retp);
    }
}