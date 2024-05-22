using System.Text.Json.Serialization;

namespace PasswordStrengthApi.Models;

public class PasswordDTO
{
    [JsonPropertyName("password")]
    public string? Password { get; set; }
}