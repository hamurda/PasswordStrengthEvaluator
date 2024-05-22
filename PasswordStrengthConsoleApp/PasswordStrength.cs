using System.Text.Json.Serialization;

public class PasswordStrength
{
    [JsonPropertyName("strength")]
    public int Strength {get; set;}
}