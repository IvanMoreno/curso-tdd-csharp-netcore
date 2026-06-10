namespace PasswordValidator;

public class IsLongEnough : Rule
{
    public override bool SatisfiedBy(string password)
    {
        return password.Length > 8;
    }
}