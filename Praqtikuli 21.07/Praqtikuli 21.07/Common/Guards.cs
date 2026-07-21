namespace Praqtikuli_21._07.Common;

public static class Guards
{
    public static void AgainstInvalidLength(int min, int max, string value)
    {
        if (value.Length < min || value.Length > max)
            throw new Exception($"{value} length must be greater than {min} and lower than {max}");
    }

    public static void AgainstOutOfRange(int min, int max, int value)
    {
        if (value < min || value > max)
            throw new Exception($"{value} must be greater than {min} and lower than {max}");
    }

    public static void AgainstInvalidEmail(string email)
    {
        if (!email.Contains("@") || !email.Contains("."))
            throw new Exception($"{email} is not a valid email address");
    }
}