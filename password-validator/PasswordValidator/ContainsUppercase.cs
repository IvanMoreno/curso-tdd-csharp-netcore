using System.Text.RegularExpressions;

namespace PasswordValidator;

public class ContainsUppercase : Rule
{
    public override bool SatisfiedBy(string password)
    {
        return Regex.IsMatch(password, "[A-Z]");
    }
}