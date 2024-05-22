namespace PasswordStrengthApi.Services;

public class PasswordStrengthService
{
    public int EvaluateStrength(string password){
        int score = 0;
        if(password.Length >= 8) score++;
        if(password.Any(char.IsUpper)) score++;
        if(password.Any(char.IsLower)) score++;
        if(password.Any(char.IsDigit)) score++;
        if(password.Any(ch => !char.IsLetterOrDigit(ch))) score++;

        return score;
    }


}