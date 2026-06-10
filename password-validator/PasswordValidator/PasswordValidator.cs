using System;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            if (!password.Contains("_"))
                return false;
            
            return password.Length > 8;    
        }
    }
}