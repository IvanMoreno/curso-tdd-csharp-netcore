using System;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        public bool IsValid(string password)
        {
            return ContainsNumber(password) && IsLongEnough(password) && ContainsUnderscore(password);
        }

        private static bool IsLongEnough(string password)
        {
            return password.Length > 8;
        }

        private static bool ContainsNumber(string password)
        {
            return Regex.IsMatch(password, "[0-9]+$");
        }

        private static bool ContainsUnderscore(string password)
        {
            return password.Contains("_");
        }
    }
}