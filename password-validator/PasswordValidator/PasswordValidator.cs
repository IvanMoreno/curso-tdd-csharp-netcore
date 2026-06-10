using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidator
    {
        private readonly List<Policy> policies;

        private PasswordValidator(List<Policy> policies)
        {
            this.policies = policies;
        }

        public bool IsValid(string password)
        {
            foreach (var policy in policies)
            {
                if (!policy.Satisfies(password))
                {
                    return false;
                }
            }

            return true;
        }

        public static PasswordValidator Default()
        {
            return new PasswordValidator([
                new ContainsUnderscore(), 
                new ContainsUppercase(), 
                new ContainsLowercase(), 
                new IsLongEnough(),
                new ContainsNumber()
            ]);
        }
    }

    public abstract class Policy
    {
        public abstract bool Satisfies(string password);
    }

    public class ContainsUnderscore : Policy
    {
        public override bool Satisfies(string password)
        {
            return password.Contains("_");
        }
    }

    public class ContainsUppercase : Policy
    {
        public override bool Satisfies(string password)
        {
            return Regex.IsMatch(password, "[A-Z]");
        }
    }

    public class ContainsLowercase : Policy
    {
        public override bool Satisfies(string password)
        {
            return Regex.IsMatch(password, "[a-z]");
        }
    }

    public class IsLongEnough : Policy
    {
        public override bool Satisfies(string password)
        {
            return password.Length > 8;
        }
    }

    public class ContainsNumber : Policy
    {
        public override bool Satisfies(string password)
        {
            return Regex.IsMatch(password, "[0-9]");
        }
    }
}