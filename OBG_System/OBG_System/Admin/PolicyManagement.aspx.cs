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
            string policy = HomePageBLO.GetReturnPolicy();
            policy.Replace("<br />", Environment.NewLine);
            TextBox1.Text = policy;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string policy = TextBox1.Text.Replace(Environment.NewLine, "<br />");
        HomePageBLO.UpdateReturnPolicy(policy);
    }
}