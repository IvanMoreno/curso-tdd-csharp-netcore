namespace PasswordValidator;

public static class PasswordValidatorFactory
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