
using System.Net.Mail;

namespace CManager.Application.Validators;

public class EmailValidator
{
    public static bool IsValid(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) 
        {
            return false;
        }
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false; 
        }

    }
}
