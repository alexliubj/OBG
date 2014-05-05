﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OBGModel;
using DataAccess;

namespace BusinessLogic
{
    public class UserBLO
    {
        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="user">user obj</param>
        /// <returns></returns>
        public static bool Registration(User user)
        {
            return UserDAO.Registration(user);
        }

        /// <summary>
        /// Admin register a New user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool AdminRegistration(User user)
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
        public static int ClientLogin(string username, string password)
        {
            return UserDAO.ClientLogin(username, password);
        }

        /// <summary>
        /// admin login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int AdminLogin(string username, string password)
        {
            return UserDAO.AdminLogin(username, password);
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
        public static bool AdminActiveUser(int userid)
        {
            return UserDAO.AdminActiveUser(userid);
        }

        /// <summary>
        /// Send reset password request , insert userid ,email and generated key into resert table
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ForgetPasswordRequest(string email)
        {
            return UserDAO.ForgetPasswordRequest(email);
            
        }
        /// <summary>
        /// reset password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public static bool ResetPaswword(int userid, string newPassword)
        {
            return UserDAO.ResetPassword(userid, newPassword);
        }

        /// <summary>
        /// Chect existing of in rest table
        /// </summary>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int ValideCheckRequest(string email, string key)
        {
            if (UserDAO.CheckReset(email, key)) // 
            {
                return UserDAO.RemoveResetRecord(email);
            }
            else
            {
                return -1; // not found record
            }
        }


        /// <summary>
        /// update userinfomation
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UpdateUserInfo(User user)
        {
            return UserDAO.UpdateUserInfo(user);
        }

        /// <summary>
        /// remove a user by userid
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool RemoveUserById(int userid)
        {
            return UserDAO.RemoveUserById(userid);
        }


        /// <summary>
        /// Get All users
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            return UserDAO.GetAllUsers();
        }
    }
}
