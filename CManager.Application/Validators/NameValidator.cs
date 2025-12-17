using System.Reflection.Metadata.Ecma335;

namespace CManager.Application.Validators;

public class NameValidator
{
    public static bool IsValid(string name, int minLength = 2)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Trim().Length >= minLength;
    }
}
