using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public static class ValidationUtility
    {
        public static bool IsEmailAddress(string email)
        {
            //return System.Text.RegularExpressions.Regex.IsMatch(email,
            //@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9] {1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\)?]$");
            return System.Text.RegularExpressions.Regex.IsMatch(email,
            @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        
        }

        public static bool IPCheck(string IP)
        {
            string num = "(25[0-5]|2[0-4]\\d|[0-1]\\d{2}|[1-9]?\\d)";
            return Regex.IsMatch(IP, ("^" + num + "\\." + num + "\\." + num + "\\." + num + "$"));
        }

        public static bool IsUrl(string str_url)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_url, @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        }
    }
}
