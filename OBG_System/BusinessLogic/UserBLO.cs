using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;
using System.Data;
namespace BusinessLogic
{
    public class UserBLO
    {
        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="user">user obj</param>
        /// <returns></returns>
        public static int Registration(User user)
        {
            return UserDAO.Registration(user);
        }

        public static int UpdatePassword(string oldPwd, string newPwd, int userid)
        {
            return UserDAO.UpdatePassword(oldPwd, newPwd, userid);
        }

        public static LoginRet ClientEmailLogin(string email, string password)
        {
            return UserDAO.ClientEmailLogin(email, password);
        }

        /// <summary>
        /// Admin register a New user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int AdminRegistration(User user)
        {
            user.Status = 1; // set as active
            return UserDAO.Registration(user);
        }

        /// <summary>
        /// Client login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginRet ClientLogin(string username, string password)
        {
            return UserDAO.ClientLogin(username, password);
        }

        /// <summary>
        /// admin login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static LoginRet AdminLogin(string username, string password)
        {
            return UserDAO.AdminLogin(username, password);
        }


        public static bool CheckUserNameExists(string username)
        {
            if (UserDAO.CheckUserNameExists(username) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool CheckEmailExists(string email)
        {
            if (UserDAO.CheckEmailExists(email) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Get user information by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static User GetUserInfoWithUserId(int userId)
        {
            return UserDAO.GetUserInfoWithUserId(userId);
        }

        /// <summary>
        /// Active user status by user id 0-inactive/ 1- active / 2- reseved/ 3....
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int AdminActiveUserStatus(int userid , int status)
        {
            return UserDAO.AdminActiveUser(userid, status);
        }

        /// <summary>
        /// Send reset password request , insert userid ,email and generated key into resert table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string ForgetPasswordRequest(string email)
        {
            return UserDAO.ForgetPasswordRequest(email);
            
        }
        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static int ResetPassword(string email, string newPassword)
        {
            return UserDAO.ResetPassword(email, newPassword);
        }

        /// <summary>
        /// Chect existing of in rest table
        /// </summary>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int ValideCheckRequest(string email, string key)
        {
            if (UserDAO.CheckReset(email, key) > 0) // 
            {
                return UserDAO.RemoveResetRecord(email);
            }
            else
            {
                return -1; // not found record
            }
        }

        /// <summary>
        /// A role name as a column in return datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUsersWithTheirRoleName()
        {
            return UserDAO.GetAllUsersWithTheirRoleName();
        }

        /// <summary>
        /// A region name as a column in return datatable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUsersWithTheirRegionName()
        {
            return UserDAO.GetAllUsersWithTheirRegionName();
        }

        /// <summary>
        /// update userinfomation
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int UpdateUserInfo(User user)
        {
            return UserDAO.UpdateUserInfo(user);
        }

        /// <summary>
        /// remove a user by userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static int RemoveUserById(int userid)
        {
            return UserDAO.RemoveUserById(userid);
        }


        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllUsers()
        {
            return UserDAO.GetAllUsers();
        }

        public static int GetUserIDByEmail(string email)
        {
            return UserDAO.GetUserIDByEmail(email);
        }
    }
}
