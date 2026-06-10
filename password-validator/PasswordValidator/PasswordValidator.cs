using System;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (!password.Contains("_"))
                return false;

            if (!Regex.IsMatch(password, "[0-9]+$"))
                return false;
            
            return password.Length > 8;    
        }
    }
}