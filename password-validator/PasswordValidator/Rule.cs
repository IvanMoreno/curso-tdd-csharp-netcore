namespace PasswordValidator;

public abstract class Rule
{
    public abstract bool SatisfiedBy(string password);
}