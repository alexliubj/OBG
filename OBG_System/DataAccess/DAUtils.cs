using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public static class DAUtils
    {
        /// <summary>
        /// MD5 Encryption
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string MD5(string plainText)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5CSP = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] testEncrypt = System.Text.Encoding.Unicode.GetBytes(plainText);
            byte[] resultEncrypt = md5CSP.ComputeHash(testEncrypt);
            return System.Text.Encoding.Unicode.GetString(resultEncrypt);
        }

        private static Random random = new Random((int)DateTime.Now.Ticks);

        /// <summary>
        /// Generate a random string according to size
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GenerateRandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

    }
}