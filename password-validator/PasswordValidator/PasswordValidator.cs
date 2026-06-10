using System.Collections.Generic;
using System.Linq;

namespace PasswordValidator
{
    public class PasswordValidator(List<Rule> rules)
    {
        public bool IsValid(string password) => rules.All(rule => rule.SatisfiedBy(password));
    }
}