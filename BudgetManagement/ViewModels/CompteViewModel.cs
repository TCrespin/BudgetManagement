using BudgetManagement.Models;
using BudgetManagement.Models.Table;
using System.Net.Mail;
namespace BudgetManagement.ViewModels;

public class CompteViewModel
{
    User user;
    UserDatabase userDatabase;
    public bool isValidEmail;

    public string? Email
    {
        get => user.Email;
        set
        {
            if (value != null && (isValidEmail = IsValidEmail(value)))
                user.Email = value;
        }
    }

    public string Pseudo
    {
        get => user.Pseudo;
        set => user.Pseudo = value;
    }

    public CompteViewModel(User user, UserDatabase userDatabase)
    {
        this.user = user;
        this.userDatabase = userDatabase;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

}
