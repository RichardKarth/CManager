
namespace CManager.Application.Validators;

public class PhoneNumberValidator
{
    public static bool isValid(string phoneNumber)
    {
        if(string.IsNullOrEmpty(phoneNumber)) return false;
        var trimmed = phoneNumber.Replace(" ", string.Empty);

        if(trimmed.Length < 9 || trimmed.Length > 15)
        {
            return false; 
        }
        return trimmed.All(char.IsDigit);
    }
}
