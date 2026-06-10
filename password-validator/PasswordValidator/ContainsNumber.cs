using System.Text.RegularExpressions;

namespace PasswordValidator;

public class ContainsNumber : Rule
{
    public override bool SatisfiedBy(string password)
    {
        return Regex.IsMatch(password, "[0-9]");
    }
}