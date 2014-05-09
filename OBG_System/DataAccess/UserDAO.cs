using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class UserDAO
    {
        
        private static DbHelper db = new DbHelper();

        /// <summary>
        /// 
        ///insert into DBUser 
        ///if success return true;
        /// </summary>
        /// <param name="user">user obj</param>
        /// <returns></returns>
        public static int Registration(User user)
        {
            DbCommand command = db.GetSqlStringCommond(@"insert into users
                                (userpwd,username,status,email,companyname,phone,shippingAddress,shippingP
                                ostcode,firstname,lastName)
                                values (@userpwd,@username,@status,@email,@companyname,@phone,@shippingAddress,@shippingP
                                ostcode,@firstname,@lastName)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userpwd", DAUtils.MD5(user.Userpwd)),
            new SqlParameter("@username", user.UserName),
            new SqlParameter("@status", user.Status),
            new SqlParameter("@email", user.Email),
            new SqlParameter("@companyname", user.Email),
            new SqlParameter("@phone", user.Phone),
            new SqlParameter("@shippingAddress", user.ShippingAddress),
            new SqlParameter("@shippingPostcode", user.ShippingPostCode),
            new SqlParameter("@firstname", user.FirstName),
             new SqlParameter("@lastName", user.LastName)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Client login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int ClientLogin(string username, string password)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select u.userid from users u inner join userrole r
                            on u.userid = r.userid
                            where u.username = @username
                            and u.userpwd = @pwd
                            and r.roleid = 1");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@username", username),
            new SqlParameter("@pwd", password)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// admin login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int AdminLogin(string username, string password)
        {
            //roleid = 0 // amdin
            //roleid = 1 // customer

            DbCommand command = db.GetSqlStringCommond(@"
                            select u.userid from users u inner join userrole r
                            on u.userid = r.userid
                            where u.username = @username
                            and u.userpwd = @pwd
                            and r.roleid = 0");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@username", username),
            new SqlParameter("@pwd", password)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Get user information by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserInfoWithUserId(int userId)
        {
            // select * from users where userid = 1;

            User retUser = new User();
            DbCommand command = db.GetSqlStringCommond(@"
                                select username,status,email,companyname,
                                phone,billingaddress, billingpostcode,
                                shippingaddress, shippingpostcode,
                                firstname,lastname 
                                from users where userid = @userid");

            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                retUser.UserName = reader.GetString(0);
            }

            return retUser;
        }

        /// <summary>
        /// Active user status by user id 0-inactive/ 1- active / 2- reseved/ 3....
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int AdminActiveUser(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            update users set status = 1 where userid= @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
            
        }

        /// <summary>
        /// Send reset password request , insert userid ,email and generated key into resert table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int ForgetPasswordRequest(string email)
        {
            // get 1st random string 
            string Rand1 = DAUtils.GenerateRandomString(8);

            // get 2nd random string 
            string Rand2 = DAUtils.GenerateRandomString(8);

            // creat full rand string
            string docNum = Rand1 + "-" + Rand2;
            DbCommand command = db.GetSqlStringCommond(@"
                            insert into resetpwds (email,sectkey) values (@email,@key)");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email) , 
            new SqlParameter("@key",docNum)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);

        }
    

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static int ResetPassword(int userid, string newPassword)
        {
            //
            DbCommand command = db.GetSqlStringCommond(@"
                            update users set userpwd = @newpassword where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid),new SqlParameter(
                "@newpassword",newPassword)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);

        }
        
        /// <summary>
        /// Chect existing of in rest table
        /// </summary>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int CheckReset(string email, string key)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            update users set email = @email where sectKey = @sectKey");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email),new SqlParameter(
                "@sectKey",key)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// if reset, remove record for resetrecord table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int RemoveResetRecord(string email)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete resetpwds where 'email' = @email");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateUserInfo(User user)
        {
            DbCommand command = db.GetSqlStringCommond(@"Update users
                                set companyName = @companyname, phone =@phone, shippingAddress=@shippingAddress,
                                shippingPostcode=@shippingPostcode,billingaddress = @billingaddress, billingpostcode = @billingpostcode, firstname = @firstname, lastname = @lastname
                                where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] {
            new SqlParameter("@companyname", user.Email),
            new SqlParameter("@phone", user.Phone),
            new SqlParameter("@shippingAddress", user.ShippingAddress),
            new SqlParameter("@shippingPostcode", user.ShippingPostCode),
            new SqlParameter("@firstname", user.FirstName),
             new SqlParameter("@lastName", user.LastName),
            new SqlParameter("@billingaddress", user.BillAddress),
            new SqlParameter("@billingpostcode", user.BillPostCode)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// remove a user by userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int RemoveUserById(int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete users where userid =@userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUsers()
        {
            DbCommand command = db.GetSqlStringCommond("select * from users");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }
    }
}
