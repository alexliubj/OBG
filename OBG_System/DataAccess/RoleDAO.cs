﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccess
{
    public static class RoleDAO
    {

        private static DbHelper db = new DbHelper();

        #region ROLE Managements
        //ROLE Managements

        public static DataTable GetAllRoleList()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT [RoleId]
                                                      ,[RoleName]
                                                      ,[Des]
                                                  FROM [Role]");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }

        public static int CreateNewRole(Role role)
        {
            DbCommand command = db.GetSqlStringCommond(@"INSERT INTO 
                                                            [Role]
                                                       ([RoleName]
                                                       ,[Des])
                                                 VALUES
                                                       (@RoleName
                                                       ,@Des)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@RoleName", role.RoleName),
            new SqlParameter("@Des", role.Des)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int ModifyRoleName(int roleId, string roleName, string description)
        {
            DbCommand command = db.GetSqlStringCommond(@"UPDATE [Role]
                                           SET [RoleName] = @roleName
                                              ,[Des] = @Des
                                         WHERE roleId = @roleId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@roleId", roleId),
            new SqlParameter("@RoleName", roleName),
            new SqlParameter("@Des", description)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteRoleByRoleId(int roleId)
        {
            DbCommand command = db.GetSqlStringCommond(@"delete from role where roleId = @roleId");
            SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@roleId", roleId) };
            command.Parameters.AddRange(paras);
            //should be in transaction


            return db.ExecuteNonQuery(command);
        }

        #endregion ROLE Managements

        //User and Role Managements

        #region User and Role Managements

        public static int AddUserToRole(int userid, int roleId, string des)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            INSERT INTO [UserRole]
                                       ([RoleId]
                                       ,[UserId]
                                       ,[Des])
                                 VALUES
                                       (@RoleId
                                       ,@UserId
                                       ,@Des)");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@RoleId", roleId) , 
            new SqlParameter("@UserId",userid),
            new SqlParameter("@Des",des)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static Role GetRoleByUserId(int userid)
        {
            Role retRole = new Role();
            DbCommand command = db.GetSqlStringCommond(@"
                            select rl.roleId,rl.roleName,rl.des from
                                userRole ur inner join role rl
                                on ur.roleId = rl.roleId
                                where ur.userId = @userid");
            SqlParameter[] paras = new SqlParameter[] {
            new SqlParameter("@userid",userid)};
            command.Parameters.AddRange(paras);
            using (DbDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    retRole.RoleId = reader.GetInt32(0);
                    retRole.RoleName = reader.GetString(1);
                    retRole.Des = reader.GetString(2);
                }
            }
            return retRole;
        }

        public static int UpdateUserRole(int userId, int roleId)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                            UPDATE  [UserRole]
                               SET [RoleId] = @roleId
                             WHERE userid=@userid");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userid", userId) , 
            new SqlParameter("@roleId",roleId)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static int DeleteUserFromRole(int userid, int roleId)
        {
            DbCommand command = db.GetSqlStringCommond(@"
                                                    DELETE [UserRole]
                              WHERE userid=@userid and roleId = @roleId");
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@userid", userid) , 
            new SqlParameter("@roleId",roleId)};
            command.Parameters.AddRange(paras);
            return db.ExecuteNonQuery(command);
        }

        public static DataTable GetAllUsersWithRole()
        {
            DbCommand command = db.GetSqlStringCommond(@"SELECT ur.[uid]
                                                      ,u.[UserId]
                                                      ,u.[UserName]
                                                      ,u.[CompanyName]
                                                      ,u.[FirstName]
                                                      ,u.[LastName],r.rolename,r.roleid, ur.[des]
                                                  FROM [Users] u join [UserRole] ur 
                                                  on u.userid = ur.userid
                                                  join [Role] r
                                                  on ur.roleid = r.roleid");
            DataTable dt = db.ExecuteDataTable(command);
            return dt;
        }
        #endregion User and Role Managements
    }
}
