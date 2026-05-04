namespace APISeguridad.Utils;

public class PasswordValidator
{
    public bool IsValid(string password)
    {
        // Regla: Mínimo 12 caracteres y debe contener un símbolo [cite_end]
        if (string.IsNullOrEmpty(password) || password.Length < 12)
            return false;

        bool hasSymbol = password.Any(ch => !char.IsLetterOrDigit(ch));
        return hasSymbol;
    }
}