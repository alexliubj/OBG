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
    private DataSet userDataSet;

    //SqlConnection sqlcon;
    //SqlCommand sqlcom;
    //string strCon = "Data Source=(local);Database=数据库名;Uid=帐号;Pwd=密码";

    protected void Page_Load(object sender, EventArgs e)
    {
        //DataTable usersTable = UserBLO.GetAllUsers();
        //dataSet = new DataSet();
        //dataSet.Tables.Add(usersTable);
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
        //string sqlstr = "delete from 表 where id='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        //sqlcon = new SqlConnection(strCon);
        //sqlcom = new SqlCommand(sqlstr, sqlcon);
        //sqlcon.Open();
        //sqlcom.ExecuteNonQuery();
        //sqlcon.Close();
        int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        UserBLO.RemoveUserById(userID);
        bind();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //sqlcon = new SqlConnection(strCon);
        //string sqlstr = "update 表 set 字段1='"
        //    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim() + "',字段2='"
        //    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim() + "',字段3='"
        //    + ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim() + "' where id='"
        //    + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
        //sqlcom = new SqlCommand(sqlstr, sqlcon);
        //sqlcon.Open();
        //sqlcom.ExecuteNonQuery();
        //sqlcon.Close();
        //GridView1.EditIndex = -1;
        //bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bind();
    }

    public void bind()
    {
        //string sqlstr = "select * from 表";
        //sqlcon = new SqlConnection(strCon);
        //SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
        //DataSet myds = new DataSet();
        //sqlcon.Open();
        //myda.Fill(myds, "表");

        DataTable usersTable = UserBLO.GetAllUsers();
        userDataSet = new DataSet();
        userDataSet.Tables.Add(usersTable);

        GridView1.DataSource = userDataSet;
        GridView1.DataKeyNames = new string[] { "userid" };//主键
        GridView1.DataBind();
       // sqlcon.Close();
    }
}