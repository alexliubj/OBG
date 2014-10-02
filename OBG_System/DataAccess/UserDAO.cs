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
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"INSERT INTO [OBG_].[dbo].[Users]
                                                               ([UserPwd]
                                                               ,[UserName]
                                                               ,[Status]
                                                               ,[Email]
                                                               ,[CompanyName]
                                                               ,[Phone]
                                                               ,[BillingHouseNo]
                                                               ,[BillingPostCode]
                                                               ,[ShippingHouseNo]
                                                               ,[ShippingPostCode]
                                                               ,[FirstName]
                                                               ,[LastName]
                                                               ,[ShippingStreet]
                                                               ,[ShippingCity]
                                                               ,[ShippingPro]
                                                               ,[BillingStreet]
                                                               ,[BillingCity]
                                                               ,[BillingPro]
                                                               ,[IsSameAddress]
                                                               ,[RegionId])
                                                        values (@userpwd,
                                                                @username,
                                                                @status,
                                                                @email,
                                                                @companyname,
                                                                @phone,
                                                                @BillingHouseNo,
                                                                @BillingPostCode,
                                                                @ShippingHouseNo,
                                                                @ShippingPostCode,
                                                                @firstname,
                                                                @lastName,
                                                                @ShippingStreet,
                                                                @ShippingCity,
                                                                @ShippingPro,
                                                                @BillingStreet,
                                                                @BillingCity,
                                                                @BillingPro,
                                                                @IsSameAddress,
                                                                @RegionId); Select @@IDENTITY");
                    SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userpwd", DAUtils.MD5(user.Userpwd)),
            new SqlParameter("@username", user.UserName),
            new SqlParameter("@status", user.Status),
            new SqlParameter("@email", user.Email),
            new SqlParameter("@companyname", user.CompanyName),
            new SqlParameter("@phone", user.Phone),
            new SqlParameter("@BillingHouseNo", user.BillingHouseNo),
            new SqlParameter("@BillingPostCode", user.BillPostCode),
            new SqlParameter("@ShippingHouseNo", user.ShippingHouseNo),
            new SqlParameter("@ShippingPostCode", user.ShippingPostCode),
            new SqlParameter("@firstname", user.FirstName),
            new SqlParameter("@lastName", user.LastName),
            new SqlParameter("@ShippingStreet", user.ShippingStreet),
            new SqlParameter("@ShippingCity", user.ShippingCity),
            new SqlParameter("@ShippingPro", user.ShippingProvince),
            new SqlParameter("@BillingStreet", user.BillingStreet),
            new SqlParameter("@BillingCity", user.BillingCity),
            new SqlParameter("@BillingPro", user.BillingProvince),
            new SqlParameter("@IsSameAddress", user.IsSameAddress),
            new SqlParameter("@RegionId", user.RegionId)};
                    command.Parameters.AddRange(paras);
                    int ret = Convert.ToInt32(db.ExecuteScalar(command, t));
                    DbCommand command2 = db.GetSqlStringCommond(@"
                            INSERT INTO [UserRole]
                                       ([RoleId]
                                       ,[UserId]
                                       ,[Des])
                                 VALUES
                                       (@RoleId
                                       ,@UserId
                                       ,@Des)");
                    SqlParameter[] paras2 = new SqlParameter[] { 
                new SqlParameter("@RoleId", 1) , 
            new SqlParameter("@UserId",ret),
            new SqlParameter("@Des",@"user registration")};
                    command2.Parameters.AddRange(paras2);
                    db.ExecuteNonQuery(command2, t);


                    DbCommand command3 = db.GetSqlStringCommond(@"INSERT INTO [Discount]
                                                   ([UserId]
                                                   ,[wheelsRate],[tiresRate],[accRate])
                                             VALUES
                                                   (@UserId
                                                   ,@wheelsRate,@tiresRate,@accRate)");
                    SqlParameter[] paras3 = new SqlParameter[] {
                        new SqlParameter("@UserId", ret) ,
            new SqlParameter("@wheelsRate",1.0f),
            new SqlParameter("@tiresRate",1.0f),
            new SqlParameter("@accRate",1.0f)};
                    command3.Parameters.AddRange(paras3);
                    db.ExecuteNonQuery(command3, t);

                    DbCommand command4 = db.GetSqlStringCommond(@"INSERT INTO [Permission]
                                                   ([UserId]
                                                   ,[WheelPermission]
                                                   ,[TirePermission]
                                                   ,[AccPermission])
                                             VALUES
                                                   (@UserId
                                                   ,@WheelPermission
                                                   ,@TirePermission
                                                   ,@AccPermission)");
                    SqlParameter[] paras4 = new SqlParameter[] {
                        new SqlParameter("@UserId", ret) ,
                        new SqlParameter("@WheelPermission",1),
                        new SqlParameter("@TirePermission",1),
                        new SqlParameter("@AccPermission",1),};
                    command4.Parameters.AddRange(paras4);
                    db.ExecuteNonQuery(command4, t);

                    t.Commit();
                    return ret;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

        public static LoginRet ClientEmailLogin(string email, string password)
        {
            LoginRet loginRet = new LoginRet();
            loginRet.UserId = -1;
            DbCommand command = db.GetSqlStringCommond(@"
                            select u.userid,u.status from users u inner join userrole r
                            on u.userid = r.userid
                            where u.email = @email
                            and u.userpwd = @pwd
                            and r.roleid = 1");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email),
            new SqlParameter("@pwd", DAUtils.MD5(password))};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    loginRet.UserId = reader.GetInt32(0);
                    if (reader.GetInt32(1) == 0)
                    {
                        loginRet.Us = LoginRet.UserStatus.inactive;
                    }
                    else
                    {
                        loginRet.Us = LoginRet.UserStatus.active;
                    }
                    loginRet.Rs = LoginRet.RoleStatus.Customer;
                }
            }
            return loginRet;
        }

        /// <summary>
        /// Client login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginRet ClientLogin(string username, string password)
        {
            LoginRet loginRet = new LoginRet();
            loginRet.UserId = -1;
            DbCommand command = db.GetSqlStringCommond(@"
                            select u.userid,u.status from users u inner join userrole r
                            on u.userid = r.userid
                            where u.username = @username
                            and u.userpwd = @pwd
                            and r.roleid = 1");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@username", username),
            new SqlParameter("@pwd", DAUtils.MD5(password))};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    loginRet.UserId = reader.GetInt32(0);
                    if (reader.GetInt32(1) == 0)
                    {
                        loginRet.Us = LoginRet.UserStatus.inactive;
                    }
                    else
                    {
                        loginRet.Us = LoginRet.UserStatus.active;
                    }
                    loginRet.Rs = LoginRet.RoleStatus.Customer;
                }
            }
            return loginRet;
        }

        /// <summary>
        /// admin login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginRet AdminLogin(string username, string password)
        {
            //roleid = 0 // amdin
            //roleid = 1 // customer
            //UserId = -1 // fail
            LoginRet loginRet = new LoginRet();
            loginRet.UserId = -1;

            DbCommand command = db.GetSqlStringCommond(@"
                            select u.userid,u.status from users u inner join userrole r
                            on u.userid = r.userid
                            where u.username = @username
                            and u.userpwd = @pwd
                            and r.roleid = 0");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@username", username),
            new SqlParameter("@pwd", DAUtils.MD5(password))};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {

                while (reader.Read())
                {
                    loginRet.UserId = reader.GetInt32(0);
                    if (reader.GetInt32(1) == 0)
                    {
                        loginRet.Us = LoginRet.UserStatus.inactive;
                    }
                    else
                    {
                        loginRet.Us = LoginRet.UserStatus.active;
                    }
                    loginRet.Rs = LoginRet.RoleStatus.Admin;
                }

            }

            return loginRet;
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
                                SELECT [UserName]
                                      ,[Status]
                                      ,[Email]
                                      ,[CompanyName]
                                      ,[Phone]
                                      ,[BillingHouseNo]
                                      ,[BillingPostCode]
                                      ,[ShippingHouseNo]
                                      ,[ShippingPostCode]
                                      ,[FirstName]
                                      ,[LastName]
                                      ,[ShippingStreet]
                                      ,[ShippingCity]
                                      ,[ShippingPro]
                                      ,[BillingStreet]
                                      ,[BillingCity]
                                      ,[BillingPro]
                                      ,[IsSameAddress]
                                      ,[RegionId]
                                from users where userid = @userid");

            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {

                while (reader.Read())
                {
                    retUser.UserName = reader.GetString(0);
                    retUser.Status = reader.GetInt32(1);
                    retUser.Email = reader.GetString(2);
                    retUser.CompanyName = reader.GetString(3);
                    retUser.Phone = reader.GetString(4);


                    if (!reader.IsDBNull(5))
                    {
                        retUser.BillingHouseNo = reader.GetString(5);
                    }
                    else
                    {
                        retUser.BillingHouseNo = string.Empty;
                    }
                    if (!reader.IsDBNull(6))
                    {
                        retUser.BillPostCode = reader.GetString(6);
                    }
                    else
                    {
                        retUser.BillPostCode = "";
                    }
                    if (reader.IsDBNull(7) == false)
                    {
                        retUser.ShippingHouseNo = reader.GetString(7);
                    }
                    else
                    {
                        retUser.ShippingHouseNo = "";
                    }
                    if (reader.IsDBNull(8) == false)
                    {
                        retUser.ShippingPostCode = reader.GetString(8);
                    }
                    else
                    {
                        retUser.ShippingPostCode = "";
                    }

                    
                    retUser.FirstName = reader.GetString(9);
                    retUser.LastName = reader.GetString(10);

                    if (reader.IsDBNull(11) == false)
                    {
                        retUser.ShippingStreet = reader.GetString(11);
                    }
                    else
                    {
                        retUser.ShippingStreet = "";
                    }
                    if (reader.IsDBNull(12) == false)
                    {
                        retUser.ShippingCity = reader.GetString(12);
                    }
                    else
                    {
                        retUser.ShippingCity = "";
                    }
                    if (reader.IsDBNull(13) == false)
                    {
                        retUser.ShippingProvince = reader.GetString(13);
                    }
                    else
                    {
                        retUser.ShippingProvince = "";
                    }
                    if (reader.IsDBNull(14) == false)
                    {
                        retUser.BillingStreet = reader.GetString(14);
                    }
                    else
                    {
                        retUser.BillingStreet = "";
                    }
                    if (reader.IsDBNull(15) == false)
                    {
                        retUser.BillingCity = reader.GetString(15);
                    }
                    else
                    {
                        retUser.BillingCity = "";
                    }
                    if (reader.IsDBNull(16) == false)
                    {
                        retUser.BillingProvince = reader.GetString(16);
                    }
                    else
                    {
                        retUser.BillingProvince = "";
                    }
                    if (reader.IsDBNull(17) == false)
                    {
                        retUser.IsSameAddress = reader.GetInt32(17) == 0 ? true : false;
                    }
                    else
                    {
                        retUser.IsSameAddress = false;
                    }
                    if (reader.IsDBNull(18) == false)
                    {
                        retUser.RegionId = reader.GetInt32(18);
                    }
                    else
                    {
                        retUser.RegionId = 0;
                    }
                }
            }
            return retUser;
        }

        /// <summary>
        /// Active user status by user id 0-inactive/ 1- active / 2- reseved/ 3....
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int AdminActiveUser(int userid, int status)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            update users set status = @userstatus where userid= @userid");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userid", userid) ,
            new SqlParameter("@userstatus",status)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        /// <summary>
        /// Send reset password request , insert userid ,email and generated key into resert table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string ForgetPasswordRequest(string email)
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
            if (db.ExecuteNonQuery(command) > 0)
            {
                return docNum;
            }
            else
            {
                return "";
            }
        }

        public static int CheckUserNameExists(string username)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select count(*) from users where username = @username");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@username", username) };
            command.Parameters.AddRange(paras);
            return (int)db.ExecuteScalar(command);

        }

        public static int CheckEmailExists(string email)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            select count(*) from users where email = @email");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email) };
            command.Parameters.AddRange(paras);
            return (int)db.ExecuteScalar(command);
        }

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static int ResetPassword(string email, string newPassword)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            update users set userpwd = @newpassword where email = @email");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email),new SqlParameter(
                "@newpassword",DAUtils.MD5(newPassword))};
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
            int uid = -1;
            DbCommand command = db.GetSqlStringCommond(@"
                            select * from resetpwds where email = @email and sectKey = @sectKey");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email),new SqlParameter(
                "@sectKey",key)};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    uid = reader.GetInt32(0);
                }
            }
            return uid;
        }

        /// <summary>
        /// if reset, remove record for resetrecord table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int RemoveResetRecord(string email)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete resetpwds where email = @email");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email) };
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int UpdateUserInfo(User user)
        {
            DbCommand command = db.GetSqlStringCommond(@"Update users
                                set status = @status, userName = @userName, companyName = @companyname, phone =@phone,
                               [BillingHouseNo] = @BillingHouseNo
                              ,[BillingPostCode] = @BillingPostCode
                              ,[ShippingHouseNo] = @ShippingHouseNo
                              ,[ShippingPostCode] = @ShippingPostCode
                              ,[FirstName] = @FirstName
                              ,[LastName] = @LastName
                              ,[ShippingStreet] = @ShippingStreet
                              ,[ShippingCity] = @ShippingCity
                              ,[ShippingPro] = @ShippingPro
                              ,[BillingStreet] = @BillingStreet
                              ,[BillingCity] = @BillingCity
                              ,[BillingPro] = @BillingPro
                              ,[IsSameAddress] = @IsSameAddress
                              ,[RegionId] = @RegionId
                                where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] {
            new SqlParameter("@userid", user.Userid),
            new SqlParameter("@username", user.UserName),
            new SqlParameter("@status", user.Status),
            new SqlParameter("@email", user.Email),
            new SqlParameter("@companyname", user.CompanyName),
            new SqlParameter("@phone", user.Phone),
            new SqlParameter("@BillingHouseNo", user.BillingHouseNo),
            new SqlParameter("@BillingPostCode", user.BillPostCode),
            new SqlParameter("@ShippingHouseNo", user.ShippingHouseNo),
            new SqlParameter("@ShippingPostCode", user.ShippingPostCode),
            new SqlParameter("@firstname", user.FirstName),
            new SqlParameter("@lastName", user.LastName),
            new SqlParameter("@ShippingStreet", user.ShippingStreet),
            new SqlParameter("@ShippingCity", user.ShippingCity),
            new SqlParameter("@ShippingPro", user.ShippingProvince),
            new SqlParameter("@BillingStreet", user.BillingStreet),
            new SqlParameter("@BillingCity", user.BillingCity),
            new SqlParameter("@BillingPro", user.BillingProvince),
            new SqlParameter("@IsSameAddress", user.IsSameAddress),
            new SqlParameter("@RegionId", user.RegionId)};
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
            using (Trans t = new Trans())
            {
                try
                {
                    DbCommand command = db.GetSqlStringCommond(@"delete users where userid =@userid");
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userid) };
                    command.Parameters.AddRange(paras);
                    db.ExecuteNonQuery(command,t);
                    DbCommand command2 = db.GetSqlStringCommond(@"delete from discount where userId = @userid");
                    SqlParameter[] paras2 = new SqlParameter[] { new SqlParameter("@userid", userid) };
                    command2.Parameters.AddRange(paras2);
                    int ret = db.ExecuteNonQuery(command2,t);
                    t.Commit();
                    return ret;
                }
                catch
                {
                    t.RollBack();
                    return -1;
                }
            }
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUsers()
        {
            DbCommand command = db.GetSqlStringCommond("select * from users order by UserId DESC");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static DataTable GetAllUsersWithTheirRoleName()
        {

            DbCommand command = db.GetSqlStringCommond(@"SELECT [UserId]
                                                      ,u.[UserPwd]
                                                      ,u.[UserName]
                                                      ,u.[Status]
                                                      ,u.[Email]
                                                      ,u.[CompanyName]
                                                      ,u.[Phone]
                                                      ,u.[BillingHouseNo]
                                                      ,u.[BillingPostCode]
                                                      ,u.[ShippingHouseNo]
                                                      ,u.[ShippingPostCode]
                                                      ,u.[FirstName]
                                                      ,u.[LastName]
                                                      ,u.[ShippingStreet]
                                                      ,u.[ShippingCity]
                                                      ,u.[ShippingPro]
                                                      ,u.[BillingStreet]
                                                      ,u.[BillingCity]
                                                      ,u.[BillingPro]
                                                      ,u.[IsSameAddress]
                                                      ,u.[RegionId],
                                                       r.rolename
                                                      FROM [Users] u join [UserRole] ur 
                                                      on u.userid = ur.userid
                                                      join [Role] r
                                                      on ur.roleid = r.roleid");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;

        }

        public static DataTable GetAllUsersWithTheirRegionName()
        {

            DbCommand command = db.GetSqlStringCommond(@"SELECT [UserId]
                                                      ,u.[UserPwd]
                                                      ,u.[UserName]
                                                      ,u.[Status]
                                                      ,u.[Email]
                                                      ,u.[CompanyName]
                                                      ,u.[Phone]
                                                      ,u.[BillingHouseNo]
                                                      ,u.[BillingPostCode]
                                                      ,u.[ShippingHouseNo]
                                                      ,u.[ShippingPostCode]
                                                      ,u.[FirstName]
                                                      ,u.[LastName]
                                                      ,u.[ShippingStreet]
                                                      ,u.[ShippingCity]
                                                      ,u.[ShippingPro]
                                                      ,u.[BillingStreet]
                                                      ,u.[BillingCity]
                                                      ,u.[BillingPro]
                                                      ,u.[IsSameAddress]
                                                      ,u.[RegionId],
                                                       s.regionname
                                                      FROM [Users] u join [Shipping] s 
                                                      on u.regionid = s.regionid");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;

        }

        /// <summary>
        /// Update user passwor with old user password
        /// </summary>
        /// <param name="oldPwd"></param>
        /// <param name="newPwd"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int UpdatePassword(string oldPwd, string newPwd, int userid)
        {
            DbCommand command = db.GetSqlStringCommond(@"update users set userPwd = @newPwd where 
                                                userId = @userId and userPwd = @oldPwd");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userId", userid),
            new SqlParameter("@newPwd", DAUtils.MD5(newPwd)),
            new SqlParameter("@oldPwd", DAUtils.MD5(oldPwd))};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int GetUserIDByEmail(string email)
        {
            int userID = -1;
            DbCommand command = db.GetSqlStringCommond(@"
                            select userid from users
                            where email = @email");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@email", email)};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
            }
            return userID;
        }


        public static string GetCompanyByUserId(int userId)
        {
            //int rName = 0;
            string company = ""; 
            DbCommand command = db.GetSqlStringCommond(@"SELECT companyname FROM users where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    //rName = reader.GetInt32(0);
                    company = reader.GetString(0);
                }
            }
            //return rName;
            return company;
        }

        public static string GetFNByUserID(int userId)
        {
            //int rName = 0;
            string fn = "";
            DbCommand command = db.GetSqlStringCommond(@"SELECT Firstname FROM users where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    //rName = reader.GetInt32(0);
                    fn = reader.GetString(0);
                }
            }
            //return rName;
            return fn;
        }
        public static string GetLNByUserID(int userId)
        {
            //int rName = 0;
            string ln = "";
            DbCommand command = db.GetSqlStringCommond(@"SELECT lastname FROM users where userid = @userid");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@userid", userId) };
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    //rName = reader.GetInt32(0);
                    ln = reader.GetString(0);
                }
            }
            //return rName;
            return ln;
        }
    }
}
