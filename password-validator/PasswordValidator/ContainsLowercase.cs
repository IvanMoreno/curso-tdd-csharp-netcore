using System.Text.RegularExpressions;

namespace PasswordValidator;

public class ContainsLowercase : Rule
{
    public override bool SatisfiedBy(string password)
    {
        return Regex.IsMatch(password, "[a-z]");
    }
}