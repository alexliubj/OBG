using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;

namespace DataAccess
{
    public static class UserDAO
    {
        /// <summary>
        /// 
        ///insert into DBUser 
        ///if success return true;
        /// </summary>
        /// <param name="user">user obj</param>
        /// <returns></returns>
        public static bool Registration(User user)
        {
            bool ret = false;
            return ret;
        }

        /// <summary>
        /// Client login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int ClientLogin(string username, string password)
        {
            int userid = -1;
            return userid;
        }

        /// <summary>
        /// admin login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int AdminLogin(string username, string password)
        {
            int userid = -1;
            return userid;
        }

        /// <summary>
        /// Get user information by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserInfoWithUserId(int userId)
        {
            User retUser = new User();
            return retUser;
        }

        /// <summary>
        /// Active user status by user id 0-inactive/ 1- active / 2- reseved/ 3....
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool AdminActiveUser(int userid)
        {
            bool ret = false;
            return ret;
        }

        /// <summary>
        /// Send reset password request , insert userid ,email and generated key into resert table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ForgetPasswordRequest(string email)
        {
            bool ret = false;
            return ret;
        }

        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool ResetPassword(int userid, string newPassword)
        {
            bool ret = false;
            return ret;
        }
        
        /// <summary>
        /// Chect existing of in rest table
        /// </summary>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool CheckReset(string email, string key)
        {
            bool ret = false;
            return ret;
        }

        /// <summary>
        /// if reset, remove record for resetrecord table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static int RemoveResetRecord(string email)
        {
            int userid = -1;
            return userid;
        }

        public static bool UpdateUserInfo(User user)
        {
            return true;
        }

        /// <summary>
        /// remove a user by userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool RemoveUserById(int userid)
        {
            bool ret = false;
            return ret;
        }

        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            List<User> listUser = new List<User>();
            return listUser;
        }


    }
}
