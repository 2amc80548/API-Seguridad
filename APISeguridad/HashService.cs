using BCrypt.Net;

public class HashService
{
    public string HashPassword(string password)
    {
        [cite_start]
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}