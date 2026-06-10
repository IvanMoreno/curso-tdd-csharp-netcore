using System;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            return password.Length > 8;    
        }
    }
}