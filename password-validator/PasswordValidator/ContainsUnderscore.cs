namespace PasswordValidator;

public class ContainsUnderscore : Rule
{
    public override bool SatisfiedBy(string password)
    {
        return password.Contains('_');
    }
}