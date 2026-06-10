using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    public class PasswordValidatorFactory
    {
        public static PasswordValidator WithAllRules()
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

    public class PasswordValidator
    {
        private readonly List<Rule> rules;

        public PasswordValidator(List<Rule> rules) => this.rules = rules;

        public bool IsValid(string password) => rules.All(policy => policy.SatisfiedBy(password));
    }

    public abstract class Rule
    {
        public abstract bool SatisfiedBy(string password);
    }

    public class ContainsUnderscore : Rule
    {
        public override bool SatisfiedBy(string password)
        {
            return password.Contains('_');
        }
    }

    public class ContainsUppercase : Rule
    {
        public override bool SatisfiedBy(string password)
        {
            return Regex.IsMatch(password, "[A-Z]");
        }
    }

    public class ContainsLowercase : Rule
    {
        public override bool SatisfiedBy(string password)
        {
            return Regex.IsMatch(password, "[a-z]");
        }
    }

    public class IsLongEnough : Rule
    {
        public override bool SatisfiedBy(string password)
        {
            return password.Length > 8;
        }
    }

    public class ContainsNumber : Rule
    {
        public override bool SatisfiedBy(string password)
        {
            return Regex.IsMatch(password, "[0-9]");
        }
    }
}