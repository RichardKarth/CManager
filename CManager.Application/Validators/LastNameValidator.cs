namespace CManager.Application.Validators;

public class LastNameValidator
{
    public static bool IsValid(string lastName)
    {
        return !string.IsNullOrWhiteSpace(lastName);
    }
}
